//發射器
using UnityEngine;
using System.Collections;

public class Printer : MonoBehaviour {

	//宣告變數----------------------------------------
	//遊戲資料物件物件池
	//public ObjectPool GameDetailpool;
	//public Game_DataBase UseDataBase;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//按下空白鍵，將遊戲資料物件顯示出來
		if (Input.GetKeyDown (KeyCode.Space)) {
			//GameDetailpool.GetBullet ();
		}


	}
}
