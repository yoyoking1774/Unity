//搜尋功能
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SearchPage : MonoBehaviour {

	//宣告變數----------------------------------------------------------------
	//搜尋到幾筆資料
	private int Searched_Data_Number = 0; 
	//搜尋字串
	private string Input_Search_string = null;
	//搜尋平台(預設為PS平台)
	private int Search_Platform_Number = 0;
	//資源池
	public ObjectPool GameDetailpool;
	//遊戲資料
	GameDetail_Class GameClass;

	//宣告UI------------------------------------------------------------------
	//SearchPage
	public GameObject SearchPageGameObject;
	//開始搜尋按鈕
	public Button Do_Search_Button;
	//BottomBar
	public BottomBar BottomBar_UI; 

	//宣告資料庫--------------------------------------------------------------
	public Game_DataBase UseDataBase = new Game_DataBase();



	//(按扭)副程式:開始搜尋
	public void Do_Search(){
		
		switch (Search_Platform_Number) {
		case 0:
			//搜尋全部平台
			SearchAllDataBase ();
			break;
		default:
			//因為預設PS平台為0，需將Dropdown傳回的數值-1
			Search_Platform_Number = Search_Platform_Number - 1;
			//搜尋單一平台
			SearchDataBase ();
			break;
		}//switch

		//開啟搜尋平台按扭
		BottomBar_UI.Search_Button.interactable = true;
		//停用開始搜尋按扭
		Do_Search_Button.interactable = false;
		//隱藏搜尋欄
		//SearchPageGameObject.SetActive(false);
	}

	//(Input_Field)副程式:接收輸入的資料
	public void EnterSearch(Text enterText){
		//取得使用者輸入的字串
		Input_Search_string = enterText.text;
		//啟用搜尋按扭
		Do_Search_Button.interactable = true;
	}//EnterSearch

	//(Dropdown)副程式:設定Dropdown
	public void Set_Dropdown(int PageNumber){
		Search_Platform_Number = PageNumber;
	}//Set_Dropdown


	//副程式:搜尋資料庫符合的資料(單一平台)
	public void SearchDataBase(){
		//每次搜尋都是從找到0筆資料開始
		Searched_Data_Number = 0;
		//判斷資料是否載入
		UseDataBase.is_Load_Data(Search_Platform_Number);

		//開始搜尋
		for (int i = UseDataBase.Call_Data_Number (Search_Platform_Number) - 1; i >= 0; i--) {
			//用是否包含中文或英文的輸入來判斷
			if (UseDataBase.Call_Name (Search_Platform_Number, i).IndexOf (Input_Search_string) >= 0 || UseDataBase.Call_EName (Search_Platform_Number, i).IndexOf (Input_Search_string) >= 0) {
				//使用遊戲資料物件(搜尋)
				GameDetailpool.SearchGetGameDetail_Class (Search_Platform_Number, i, Searched_Data_Number);
				//搜尋到幾筆資料 + 1
				Searched_Data_Number = Searched_Data_Number + 1;
			}//if
		}//for_i
			
	}//SearchDataBase

	//副程式:搜尋資料庫符合的資料(全部平台)
	public void SearchAllDataBase(){
		//每次搜尋都是從找到0筆資料開始
		Searched_Data_Number = 0;
		//載入所有平台資料
		UseDataBase.Load_All_Data();
	
		//開始搜尋
		for(int i=0; i<UseDataBase.Platform_Number; i++){
			for (int j = UseDataBase.Call_Data_Number (i) - 1; j >= 0; j--) {
			//用是否包含中文或英文的輸入來判斷
				if (UseDataBase.Call_Name (i, j).IndexOf (Input_Search_string) >= 0 || UseDataBase.Call_EName (i, j).IndexOf (Input_Search_string) >= 0) {
					//使用遊戲資料物件(搜尋)
					GameDetailpool.SearchGetGameDetail_Class (i, j, Searched_Data_Number);
					//搜尋到幾筆資料 + 1
					Searched_Data_Number = Searched_Data_Number + 1;

				}//if
			}//for_j
		}//for_i

	}//SearchAllDataBase


}//SearchPage
