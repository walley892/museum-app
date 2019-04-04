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
        gameObject.transform.localScale = Vector3.one;
    }

    
    void Update()
    {
        
    }

    public void setBase(Trackable b)
    {
        _base = b;
    }

    public void setModelId(int modelId)
    {
        _modelId = modelId;
    }
}
