using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class test : MonoBehaviour
{
    
    void Start()
    {
        
        ModelManager m = new LocalModelManager("artifacts/");
        GameObject g = m.createModel(0);
        //g.GetComponent<Renderer>().material.SetTexture("_MainTex", m.getTexture(0));
        //obj.GetComponent<Renderer>().material.SetTexture("_MainTex", m.getTexture(0));
    }

    
    void Update()
    {
        
    }
}
