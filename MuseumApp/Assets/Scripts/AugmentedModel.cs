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
        Anchor anc = _image.CreateAnchor(_image.CenterPose);

        gameObject.transform.parent = anc.transform;
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.localScale = Vector3.one * 0.1f;
    }

    
    void Update()
    {
        
    }

    static AugmentedModel spawnAugmentedModel(Trackable b, int modelId)
    {
        _base = b;
        _modelId = modelId;

        GameObject obj = new GameObject();
        AugmentedModel model = obj.AddComponent<AugmentedModel>();

        return model;
    }
}
