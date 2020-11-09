//頁面切換
using UnityEngine;
using System.Collections;

public class PageChangeScript : MonoBehaviour {

	//宣告變數------------------------------------------------
	//現在平台編號
	public static int PageNumber = 0;
	//資源池
	public ObjectPool GameDetailpool;
	//TopBar_UI
	public TopBar TopBarUI;
	//BottomBar_UI
	public BottomBar BottomUI;
	//SearchPage
	public GameObject SearchPageGameObject;

	// Update is called once per frame
	void Update () {
		//按下空白鍵，將遊戲資料物件顯示出來
		if (Input.GetKeyDown(KeyCode.Space)) {
			GameDetailpool.GetBullet ();
		}

	}


	//副程式(按扭):切換平台
	public void PageChange(int Number){
		
		//設定現在平台編號
		PageNumber = Number;
		//設定資料
		GameDetailpool.PageChangeData(PageNumber);
		//設定TopBar_UI
		TopBarUI.UpDate_TopBar_UI();
		//設定Bottom_UI
		BottomUI.Update_ButtomBar(Number);
		//如果為搜尋頁面，顯示搜尋欄
		if(Number >= 10) SearchPageGameObject.SetActive(true);
	}

}//PageChangeScript
