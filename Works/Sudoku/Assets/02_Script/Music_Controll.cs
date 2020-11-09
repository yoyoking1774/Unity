//音樂控制
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Music_Controll : MonoBehaviour {

	//宣告變數------------------------------------------
	//音樂播放狀態 true:開啟 false:關閉
	public static bool PlayBool = true;
	//執行一次程式 true:未執行 false:執行
	bool Use_Bool = false;

	//宣告UI-------------------------------------------
	//音樂按鈕
	public Button Music_Button;
	//背景音樂
	public AudioSource BackGround_Music;

	// Update is called once per frame
	void Update () {
		if (!Use_Bool) {
			if (PlayBool) {
				BackGround_Music.Play ();
				//原本顏色
				Music_Button.image.color = new Color32 (255, 255, 255, 255);
			} else {
				//透明色
				Music_Button.image.color = new Color32 (255, 255, 255, 125);
				BackGround_Music.Pause ();
			}

			Use_Bool = true;
		}//if (!Use_Bool)
	}//Update
	 
	//副程式:音樂控制
	public void Music_Change(){
		//播放音樂
		if (PlayBool == false) {
			//播放音樂
			PlayBool = true;
			//執行一次程式
			Use_Bool = false;
			//原本顏色
			Music_Button.image.color = new Color32 (255, 255, 255, 255);
			//儲存資料
			SaveGameExecutive.DoSave ();
		}
		//暫停音樂
		else {
			//暫停音樂
			PlayBool = false;
			//執行一次程式
			Use_Bool = false;
			//透明色
			Music_Button.image.color = new Color32 (255, 255, 255, 125);
			//儲存資料
			SaveGameExecutive.DoSave ();
		}
	}//Play_Music





}//Music_Controll
