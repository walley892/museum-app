using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class AugmentedModel : ModelController
{
    private Transform _base;

    private int _modelId;

    private float _yRot;

	GameObject[] _controlls;
	
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
        if(_controlls == null)
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
    
	public void spawnControlls(){
		_controlls = new GameObject[2];
		_controlls[0] = GameObject.CreatePrimitive(PrimitiveType.Cube);
		_controlls[1] = GameObject.CreatePrimitive(PrimitiveType.Cube);
        RotationController c1 = _controlls[0].AddComponent<RotationController>();
        c1.setDirection(Direction.left);
        c1.setControlle(this);
        RotationController c2 = _controlls[1].AddComponent<RotationController>();
        c2.setDirection(Direction.right);
        c2.setControlle(this);
		
	}
	
	public void unspawnControlls(){
		GameObject.Destroy(_controlls[0]);
		GameObject.Destroy(_controlls[1]);
		_controlls = null;
	}
	
}
