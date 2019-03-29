using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class AugmentedModel : MonoBehaviour
{
    private Trackable _base;
    private int _modelId;
    
    void Start()
    {
        Anchor anc = _base.CreateAnchor(_base.GetCenterPose());

        gameObject.transform.parent = anc.transform;
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.localScale = Vector3.one * 0.1f;
    }

    
    void Update()
    {
        
    }

    void setBase(Trackable b)
    {
        _base = b;
    }

    void setModelId(int modelId)
    {
        _modelId = modelId;
    }

    public static AugmentedModel spawnAugmentedModel(Trackable b, int modelId)
    {
        

        GameObject obj = new GameObject();
        AugmentedModel model = obj.AddComponent<AugmentedModel>();

        model.setBase(b);
        model.setModelId(modelId);


        return model;
    }
}
