//動態顯示訊息
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Input_Mwssage : MonoBehaviour {

	string ssss;
	float Timee;
	int a = 1;
	string Message_String_Image;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Timee += Time.deltaTime;
		if (Timee > 1.5f) {
			/*//Message_Text測試
			ssss = "第" + a + "筆";
			Message_Text.Input_String (ssss);
			a = a + 1;
			Timee = 0.0f;*/

			//Message_Text_Image測試
			ssss = "第" + a + "筆";
			//圖片名稱
			Message_String_Image = "BreadStore_01";
			Message_Text_Image.Input_String_Image (ssss , Message_String_Image);
			a = a + 1;
			Timee = 0.0f;

		}//if

	}//Update
}
