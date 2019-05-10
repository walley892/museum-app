using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {left, right};

public abstract class RotationController: ModelController
{
	
	private Direction _dir;
	
	public override void Action(){

        if (_dir == Direction.left){
			_controlle.rotateLeft(0.3f);
		}
        else {
			_controlle.rotateRight(0.3f);
		}
        
	}
	
	public void setDirection(Direction d){
		_dir = d;
	}

    public void setPositionAndRotation()
    {
        /*
        Vector3 modelVec = _controlle.transform.position;

        Vector2 projection = new Vector3(modelVec.x, modelVec.z);

        float angle = Vector2.Dot(projection, new Vector2(1, 0));

        if (_dir == Direction.left)
            angle += Mathf.PI / 2;
        else
            angle -= Mathf.PI / 2;

        Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));

        gameObject.transform.forward = modelVec;
        gameObject.transform.position = pos;
        */
    }

}