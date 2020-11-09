//遊戲重新開始銷毀舊關卡物件
using UnityEngine;
using System.Collections;

public class GameResart : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (UnityChanControll.GameRestartBool) {
			Destroy (gameObject);
		}
	}
}
