using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {left, right};

public abstract class RotationController: ModelController
{
	
	private Direction _dir;
	
	public override void Action(){
		if(_dir == Direction.left){
			_controlle.rotateLeft(0.3f);
		}else{
			_controlle.rotateRight(0.3f);
		}
	}
	
	public void setDirection(Direction d){
		_dir = d;
	}
}