using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class ARMaster : MonoBehaviour
{
    
    public ModelManager _modelManager;
    public AugmentedImageDatabase _trackedImageDatabase;

    private Dictionary<int, AugmentedModel> _spawnedModels;

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

        List<AugmentedImage> trackedImages = new List<AugmentedImage>();
        Session.GetTrackables<AugmentedImage>(trackedImages, TrackableQueryFilter.Updated);

        foreach(AugmentedImage img in trackedImages)
        {
            
            if(img.TrackingState == TrackingState.Tracking) 
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