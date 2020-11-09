//物件自轉
using UnityEngine;
using System.Collections;

public class ObjectRotating : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 5, 0);   //物體自轉
	}

	//物件觸發事件
	void OnTriggerEnter(Collider UnityChanTrigger){
		//如果碰到UnityChan就銷毀自己
		if (UnityChanTrigger.tag == "UnityChan") {
			Destroy (gameObject);
		}
	}//物件觸發事件


}
