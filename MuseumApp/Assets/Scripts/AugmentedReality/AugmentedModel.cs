using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class AugmentedModel : MonoBehaviour
{
    private Transform _base;

    private int _modelId;

    private float _yRot;

    void Start()
    {

        gameObject.transform.parent = _base;
        gameObject.transform.localRotation = Quaternion.identity;
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.localScale = Vector3.one;

        _yRot = gameObject.transform.localRotation.eulerAngles.y;
    }

    
    void Update()
    {
        
    }

    public void setBase(Trackable b)
    {
        _base = b.CreateAnchor(b.GetCenterPose()).transform;
    }

    public void setBase(Transform t)
    {
        _base = t;
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
