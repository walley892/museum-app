using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class AugmentedModel : MonoBehaviour
{
    private Trackable _base;

    private int _modelId;

    private float _yRot;

    void Start()
    {
        Anchor anc = _base.CreateAnchor(_base.GetCenterPose());
        
        gameObject.transform.parent = anc.transform;
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.localScale = Vector3.one;

        _yRot = 0;
    }

    
    void Update()
    {
        rotateLeft(0.7f);
    }

    public void setBase(Trackable b)
    {
        _base = b;
    }

    public void setModelId(int modelId)
    {
        _modelId = modelId;
    }

    public void rotateLeft(float degs)
    {
        _yRot += degs;
        gameObject.transform.localRotation = Quaternion.Euler(0, _yRot, 0);
    }

    public void rotateRight(float degs)
    {
        rotateLeft(-degs);
    }


}
