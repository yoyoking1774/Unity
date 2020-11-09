//發射器
using UnityEngine;
using System.Collections;

public class Printer : MonoBehaviour {

	//宣告變數----------------------------------------
	//子彈物件池
	public ObjectPool bulletpool;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//按下空白鍵，將子彈顯示出來
		if (Input.GetKeyDown (KeyCode.Space))
			bulletpool.GetBullet();
	}
}
