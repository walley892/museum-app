using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class ARMaster : MonoBehaviour
{
    private bool _spawned;
    // Start is called before the first frame update
    void Start()
    {
        _spawned = false;
    }

    // Update is called once per frame
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
                if (!_spawned)
                {
                    AugmentedModel.spawnAugmentedModel(img, 0);
                    
                    _spawned = true;
                }
            }
        }
    }
}
