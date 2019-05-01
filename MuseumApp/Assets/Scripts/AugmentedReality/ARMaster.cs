using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class ARMaster : MonoBehaviour
{
    
    public ModelManager _modelManager;
    public AugmentedImageDatabase _trackedImageDatabase;

    private Dictionary<int, AugmentedModel> _spawnedModels;

    private AugmentedModel _activeModel;

    void setModelManager(ModelManager m)
    {
        _modelManager = m;
    }

    void Start()
    {
        _spawnedModels = new Dictionary<int, AugmentedModel>();
        setModelManager(new LocalModelManager("artifacts/"));
        int[] modelIds = _modelManager.availableModelIds();
        
        for(int i = 0; i < modelIds.Length; ++i)
        {
            Texture2D img = _modelManager.getTrackedImage(modelIds[i]);
            string name = "" + modelIds[i];
            _trackedImageDatabase.AddImage(name, img, 1);
        }
        
    }

    
    void Update()
    {
        
        if(Session.Status != SessionStatus.Tracking)
        {
            return;
        }

        checkImagesAndSpawnModels();
        handleTouchInput();
    }

    public void handleTouchInput()
    {
        foreach(Touch touch in Input.touches)
        {

            if(touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject g = hit.collider.gameObject;
                    
                    AugmentedModel m = g.GetComponent<AugmentedModel>();

                    if(m != null)
                    {
                        _activeModel = m;
                    }
                }

            }
            
            if(touch.phase == TouchPhase.Moved)
            {
                if(_activeModel != null)
                {
                    float rotAmt = touch.deltaPosition.x;

                    float scaleAmt = touch.deltaPosition.y;

                    if (Mathf.Abs(rotAmt) > Mathf.Abs(scaleAmt))
                        _activeModel.rotateRight(rotAmt * touch.deltaTime);
                    else
                        _activeModel.scale(scaleAmt * touch.deltaTime * 0.001f);
                }
            }

            if(touch.phase == TouchPhase.Ended)
            {
                _activeModel = null;
            }

        }
    }

    public void checkImagesAndSpawnModels()
    {
        List<AugmentedImage> trackedImages = new List<AugmentedImage>();
        Session.GetTrackables<AugmentedImage>(trackedImages, TrackableQueryFilter.Updated);

        foreach (AugmentedImage img in trackedImages)
        {

            if (img.TrackingState == TrackingState.Tracking)
            {

                int modelId = int.Parse(img.Name);

                if (!_spawnedModels.ContainsKey(modelId))
                {

                    AugmentedModel m = spawnAugmentedModel(modelId, img);

                    _spawnedModels.Add(modelId, m);
                }
            }
        }
    }

    public AugmentedModel spawnAugmentedModel(int modelId, Trackable b)
    {
        
        GameObject obj = _modelManager.createModel(modelId, true);
        AugmentedModel model = obj.AddComponent<AugmentedModel>();
        model.setBase(b);
        model.setModelId(modelId);

        return model;
    }
}