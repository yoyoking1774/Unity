//輸入條
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Input_Bar : MonoBehaviour {

	//宣告變數*************************************************
	//使用輸入條是哪1個數獨陣列，依照陣列編號(預設0表示第1個)
	public static int Use_Input_Bar_Number = 0;

	//滑鼠進入按扭音效
	//public 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	//(按鈕)副程式:輸入數字
	public void Button_Input_Number(int Number){
		//改變指定的數獨陣列的數字
		Main_Executive.Sudoku_Array [Use_Input_Bar_Number].Set_Sudoku_Number (Number);
		//回復狀態為遊戲中
		Main_Executive.State_Nubmer = 1;
		//執行改變Button狀態
		Main_Executive.Use_Bool = false;
		//播放輸入條下降動畫
		Animation_Controll.Animation_Number = 2;
		//儲存資料
		SaveGameExecutive.DoSave ();
	}//Button_Input_Number

	//(按鈕)副程式:清除數字
	public void Button_Clean_Input_Number(){
		//改變指定的數獨陣列的數字為0，表示沒數字
		Main_Executive.Sudoku_Array [Use_Input_Bar_Number].Set_Sudoku_Number (0);
		//回復狀態為遊戲中
		Main_Executive.State_Nubmer = 1;
		//執行改變Button狀態
		Main_Executive.Use_Bool = false;
		//播放輸入條下降動畫
		Animation_Controll.Animation_Number = 2;
		//儲存資料
		SaveGameExecutive.DoSave ();
	}//Button_Clean_Input_Number

	//(按鈕)副程式:取消輸入
	public void Button_Chancel_Input_Bar(){
		//回復狀態為遊戲中
		Main_Executive.State_Nubmer = 1;
		//執行改變Button狀態
		Main_Executive.Use_Bool = false;
		//播放輸入條下降動畫
		Animation_Controll.Animation_Number = 2;
		//儲存資料
		SaveGameExecutive.DoSave ();
	}//Button_Chancel_Input_Bar




}//Input_Bar
