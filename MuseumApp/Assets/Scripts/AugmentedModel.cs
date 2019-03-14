using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class AugmentedModel : MonoBehaviour
{
    private AugmentedImage _image;
    private int _modelId;
    
    public void Initalize(AugmentedImage img, int modelId)
    {
        _image = img;
        _modelId = modelId;
    }

    
    void Start()
    {
        Anchor anc = _image.CreateAnchor(_image.CenterPose);
        gameObject.transform.localPosition = Vector3.zero;
    }

    
    void Update()
    {
        if (_image == null || _image.TrackingState != TrackingState.Tracking)
        {
            return;
        }

        //gameObject.transform.position = Vector3.zero;
    }


}
