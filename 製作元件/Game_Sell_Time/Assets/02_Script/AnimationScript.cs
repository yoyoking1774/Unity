//Animation(動畫)腳本
using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {



	//副程式:GameObjectSet(true)
	public void Set_GameObject_Active_true(){
		this.gameObject.SetActive (true);
	}//Set_GameObject_Active_true
		
	//副程式:GameObjectSet(false)
	public void Set_GameObject_Active_false(){
		this.gameObject.SetActive (false);
	}//Set_GameObject_Active_false



}//AnimationScript
