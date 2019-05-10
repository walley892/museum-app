using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ModelController: MonoBehaviour
{
	public AugmentedModel _controlle;

	public abstract void Action();
	
	public void setControlle(AugmentedModel m){
		_controlle = m;
	}
}