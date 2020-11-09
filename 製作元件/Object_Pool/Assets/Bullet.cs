//類別:子彈
using UnityEngine;
using System.Collections;
using System.Timers;
public class Bullet : MonoBehaviour {

	//宣告屬性----------------------------------------
	//收回Pool時間
	private float Time_Ds;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//移動
		gameObject.transform.position += new Vector3(0.1f,0,0);

		//計算生成時間
		Time_Ds += Time.deltaTime;

		//如果生成時間 > 1秒
		if (Time_Ds > 1.0f) {
			//回到Printer底下的ObjectPool
			GameObject.Find( "Printer" ).GetComponent<ObjectPool>().PutBack( gameObject ); 
			//生成時間歸0
			Time_Ds = 0.0f;
		}//if (Time_Ds > 1.0f)
	}//Update


}//Bullet
