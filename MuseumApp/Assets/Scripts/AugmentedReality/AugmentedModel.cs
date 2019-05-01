using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore;

public enum Buttons {Left, Right}

public class AugmentedModel : ModelController
{
    private Transform _base;

    private int _modelId;

    private float _yRot;

    GameObject controlMenu;

    GameObject _controlPrefab;

    void Start()
    {

        gameObject.transform.parent = _base;
        gameObject.transform.localRotation = Quaternion.identity;
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.localScale = Vector3.one;

        setControlle(this);

        _yRot = gameObject.transform.localRotation.eulerAngles.y;
    }
    public override void Action()
    {
        if(controlMenu == null)
        {
            spawnControlls();
        }
        else
        {
            unspawnControlls();
        }

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
    
    public void scale(float amt)
    {
        gameObject.transform.localScale += Vector3.one*amt;
    }

	public void spawnControlls()
    {
        controlMenu = new GameObject();

        Canvas canv = controlMenu.AddComponent<Canvas>();
        canv.renderMode = RenderMode.ScreenSpaceOverlay;
        controlMenu.AddComponent<CanvasScaler>();
        controlMenu.AddComponent<GraphicRaycaster>();
        spawnButton(Buttons.Left);
        //spawnButton(Buttons.Right);
	}

    public void spawnButton(Buttons b)
    {
        GameObject buttonObj = new GameObject();
        buttonObj.transform.parent = controlMenu.transform;

        buttonObj.name = "Button Object";

        Button button = buttonObj.AddComponent<Button>();


        if (b == Buttons.Left)
        {
            button.onClick.AddListener(() => rotateLeft(5));
        }
        else
        {
            button.onClick.AddListener(() => rotateRight(5));
        }

        GameObject textObj = new GameObject();
        textObj.name = "Button";
        textObj.transform.parent = buttonObj.transform.parent;
        
        Text text = textObj.AddComponent<Text>();

        text.text = "Right";

        if (b == Buttons.Left)
        {
            text.text = "Left";
        }

        text.font = (Font)Resources.Load("fonts/Roboto-Regular");
        text.fontSize = 200;


        Vector3 pos = new Vector3(300, -500, -300);
        
        if(b == Buttons.Left)
        {
            pos = new Vector3(-100, -500, 0);
        }

        RectTransform rectTransform;

        rectTransform = buttonObj.AddComponent<RectTransform>();
        rectTransform.localPosition = pos;
        rectTransform.sizeDelta = new Vector2(800, 400);

        rectTransform = textObj.GetComponent<RectTransform>();
        rectTransform.localPosition = pos;
        rectTransform.sizeDelta = new Vector2(800, 400);
    }
     
    void placeControlls()
    {

    }
	
	public void unspawnControlls(){
        Destroy(controlMenu);
        controlMenu = null;
	}

}