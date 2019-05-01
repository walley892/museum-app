using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore;

public class test : MonoBehaviour
{
    
    void Start()
    {
        /*
        ModelManager m = new LocalModelManager("artifacts/");
        GameObject g = m.createModel(0);
        var sz = g.GetComponent<MeshRenderer>().bounds.extents;

        GameObject g1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        g1.transform.parent = g.transform;
        g1.transform.localPosition = Vector3.zero;
        g1.transform.localPosition += sz.z*g1.transform.right;
        g1.transform.localScale *= sz.z / 2;
        */
        //g.GetComponent<Renderer>().material.SetTexture("_MainTex", m.getTexture(0));
        //obj.GetComponent<Renderer>().material.SetTexture("_MainTex", m.getTexture(0));
        RectTransform rectTransform;

        GameObject controlMenu = new GameObject();

        Canvas canv = controlMenu.AddComponent<Canvas>();
        canv.renderMode = RenderMode.ScreenSpaceOverlay;
        controlMenu.AddComponent<CanvasScaler>();
        controlMenu.AddComponent<GraphicRaycaster>();


        // Text
        GameObject leftButton = new GameObject();
        leftButton.name = "lb";
        leftButton.transform.parent = controlMenu.transform;
        leftButton.AddComponent<Button>().onClick.AddListener(() => foo());

        
        GameObject lbt = new GameObject();
        lbt.name = "lbt";
        lbt.transform.parent = leftButton.transform;

        Text lbText = lbt.AddComponent<Text>();
        lbText.font = (Font)Resources.Load("fonts/Roboto-Regular");
        lbText.text = "wobble";
        lbText.fontSize = 100;

        // Text position
        
        rectTransform = leftButton.AddComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.sizeDelta = new Vector2(400, 200);

        rectTransform =  lbt.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.sizeDelta = new Vector2(400, 200);

    }
    public void foo()
    {
        Application.Quit();
        print("foo");
    }
    
    void Update()
    {
        
    }
}
