//執行主程式
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Main_Executive : MonoBehaviour {

	//宣告變數*********************************************************************
	//數獨陣列
	public static Sudoku[] Sudoku_Array = new Sudoku[81];
	//狀態表(1:遊戲中 2:選擇數字中 3:檢查中 4:遊戲完成 5:暫停)
	public static int State_Nubmer = 1;
	//是否生成完數獨陣列 true:生成完 false:未生成
	bool Create_Sudoku_Array_Bool = false;
	//執行一次副程式用 true:使用 false:不使用
	public static bool Use_Bool = false;


	//答案是否正確 true:正確 fasle:不正確
	public static bool Check_Bool = false;

	//題庫題目編號
	public static int Question_Number = 0;

	//遊戲時間
	public static float GameTime = 0.0f;

	//迴圈用
	int i;

	//宣告UI***********************************************************************
	//暫停遊戲物件
	public GameObject GameEnd_Object;
	//暫停遊戲按鈕
	public Button GameEnd_Button;
	//恢復遊戲按鈕
	public Button ReGame_Button;
	//GameEndText
	public Text GameEndText;
	//遊戲時間
	public Text GameTimeText;

	//數獨按鈕
	public Button[] Sudoku_Button = new Button[81]; 
	//數獨Text
	public Text[] Sudoku_Text = new Text[81];

	//輸入數字按鈕
	public Button[] Input_Button = new Button[9];
	//清除數字按鈕
	public Button Clean_Input_Button;
	//取消輸入按鈕
	public Button Chancel_Input_Button;

	//檢查答案按鈕
	public Button Check_Button;

	// Use this for initialization
	void Start () {
		
		for ( i = 0; i < Sudoku_Array.Length; i++) {
			//生成數獨陣列
			Sudoku_Array [i] = new Sudoku (i, i * 5, false);
		}//for

		//生成題目
		Create_Sudoku_Question.Create_Question();
		//生成完數獨陣列
		Create_Sudoku_Array_Bool = true;

		//將Savefile_1儲存的資料放入Sav
		JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("Savefile_1"),SaveGameExecutive.Sav);
		//讀取資料(如果不是初次執行程式)
		if(SaveGameExecutive.Sav.First_Executive == false)SaveGameExecutive.DoLoad ();

		//刷新畫面
		State_Button ();

	}//Start
	
	// Update is called once per frame
	void Update () {

		//如果生成完數獨陣列
		if (Create_Sudoku_Array_Bool == true) {
			//檢查答案(全對)
			if (State_Nubmer == 3 && Check_Bool == true) {
				print ("完成");
				//出現暫停選單
				GamePause_Button();
				//防止重複檢查答案
				State_Nubmer = 4;
				//防止使用者是在完成畫面結束遊戲，用於儲存
				State_Nubmer = 3;
				//GameEndText顯示訊息:遊戲完成
				GameEndText.text = "遊戲完成";
				//顯示遊戲已花時間
				GameTimeText.text = "已花時間\n" + (int)GameTime + "秒";
				//恢復遊戲按鈕設為不可用
				ReGame_Button.interactable = false;
				//改變數獨陣列和輸入條的按鈕
				State_Button ();
				//執行一次副程式
				Use_Bool = false;
				//存檔
				SaveGameExecutive.DoSave();
				//防止重複檢查答案
				State_Nubmer = 4;
			}//if(State_Nubmer == 3 && Check_Bool == true)
			//檢查答案(有錯誤)
			else if(State_Nubmer == 3 && Check_Bool == false && !Use_Bool){
				print ("未完成");
				//出現暫停選單
				GamePause_Button();
				//GameEndText顯示訊息:未答對
				GameEndText.text = "未答對";
				//顯示遊戲已花時間
				GameTimeText.text = "已花時間\n" + (int)GameTime + "秒";
				//檢查按鈕設為不可用
				Check_Button.interactable = false;
				//恢復成遊戲中
				State_Nubmer = 3;
				//執行一次副程式
				Use_Bool = false;
				//存檔
				SaveGameExecutive.DoSave();
			}//else if(State_Nubmer == 3 && Check_Bool == false && !Use_Bool)
			//暫停中
			else if(State_Nubmer == 5 && !Use_Bool){
				//出現暫停選單
				GamePause_Button();
				//GameEndText顯示訊息:未答對
				GameEndText.text = "遊戲暫停";
				//顯示遊戲已花時間
				GameTimeText.text = "已花時間\n" + (int)GameTime + "秒";
				//暫停選單出現
				GameEnd_Object.SetActive(true);
				//暫停遊戲按鈕設為不可用
				GameEnd_Button.interactable = false;
				//狀態:暫停中
				State_Nubmer = 5;
				//執行一次副程式
				Use_Bool = false;
			}//else if(State_Nubmer == 5  && !Use_Bool)


			//改變狀態
			if (!Use_Bool) {
				//刷新畫面
				State_Button ();
				//執行一次副程式
				Use_Bool = true;
			}//if_!Use_Bool 
				
			//計算遊戲時間(如果狀態為遊戲中或選擇數字中)
			if(State_Nubmer == 1 || State_Nubmer == 2)GameTime += Time.deltaTime;

			if (Input.GetKeyDown (KeyCode.S) && (State_Nubmer == 1 || State_Nubmer == 2)) 
				SaveGameExecutive.DoSave ();
			
			if (Input.GetKeyDown (KeyCode.L) && (State_Nubmer == 1 || State_Nubmer == 2)) 
				SaveGameExecutive.DoLoad ();
			

		}//if_Create_Sudoku_Array_Bool

	}//Update

	//副程式:印出數獨陣列的數字
	public void Show_Sudoku_Number(){
		for (int i = 0; i < Sudoku_Array.Length; i++) {
			//如果數獨陣列的數字不為0，表示為不是空白、是參考數字
			if (Sudoku_Array [i].Get_Sudoku_Number () != 0) {
				//文字顏色
				Sudoku_Text [i].text = Sudoku_Array [i].Get_Sudoku_Number () + "";
				//外框
				Sudoku_Button [i].image.color = new Color32 (133,133,133,255);

				//參考數字顏色、外框顏色
				if (Sudoku_Array [i].Get_Sudoku_Bool () == true) {
					//數字
					Sudoku_Text [i].color = new Color32 (125, 0, 0, 255);
					//外框
					Sudoku_Button [i].image.color = new Color32 (188,68,68,255);

				}//if (Sudoku_Array [i].Get_Sudoku_Bool () == true) 
			}//if (Sudoku_Array [i].Get_Sudoku_Number () != 0)
			//如果數獨陣列的數字為0，表示為空白
			else {
				Sudoku_Text [i].text = " ";
				//不是參考數字顏色
				Sudoku_Text [i].color = new Color32 (0, 0, 0, 255);
				//外框
				Sudoku_Button [i].image.color = new Color32 (133,133,133,255);
			}//else

		}//for_i
	}//Show_Sudoku_Number

	//副程式:改變數獨陣列和輸入條的按鈕
	public void State_Button(){
		
		for (int i = 0; i < Sudoku_Array.Length; i++) {
			//狀態:遊戲中，將數獨陣列的按鈕設為可用、輸入條的按鈕設為不可用、檢查按鈕設為可用
			if (State_Nubmer == 1) {
				Sudoku_Button [i].interactable = true;
				Check_Button.interactable = true;
				if(i < 9)Input_Button [i].interactable = false;
				Clean_Input_Button.interactable = false;
				Chancel_Input_Button.interactable = false;
				//恢復遊戲按鈕設為可用
				ReGame_Button.interactable = true;
				//將選擇的數獨陣列改變顏色，回復到未選擇的顏色
				Sudoku_Button[Input_Bar.Use_Input_Bar_Number].image.color = new Color32(133,133,133,255);

			}//if 
			//狀態:選擇數字中，將數獨陣列的按鈕設為不可用、輸入條的按鈕設為可用、檢查按鈕設為不可用
			else if (State_Nubmer == 2) {
				Sudoku_Button [i].interactable = false;
				Check_Button.interactable = false;
				if(i < 9)Input_Button [i].interactable = true;
				Clean_Input_Button.interactable = true;
				Chancel_Input_Button.interactable = true;
				//恢復遊戲按鈕設為可用
				ReGame_Button.interactable = true;
				//將選擇的數獨陣列改變顏色，讓使用者知道是選擇哪一個
				Sudoku_Button[Input_Bar.Use_Input_Bar_Number].image.color = new Color32(0,0,0,255);

			}//else_if
			//狀態:遊戲結束或暫停遊戲，數獨陣列的按鈕設為不可用、輸入條的按鈕設為不可用、檢查按鈕設為不可用
			else if(State_Nubmer == 3 || State_Nubmer == 5){
				Sudoku_Button [i].interactable = false;
				Check_Button.interactable = false;
				if(i < 9)Input_Button [i].interactable = false;
				Clean_Input_Button.interactable = false;
				Chancel_Input_Button.interactable = false;

			}//else
		}//for
			
		//印出數獨陣列的數字
		Show_Sudoku_Number ();

		//因為會被上一行的Show_Sudoku_Number把外框變為白色所以要多加下面這一行來變成選擇時的顏色
		if (State_Nubmer == 2) {			
			//將選擇的數獨陣列改變顏色，讓使用者知道是選擇哪一個
			Sudoku_Button [Input_Bar.Use_Input_Bar_Number].image.color = new Color32 (0, 0, 0, 255);
			//提示格
			HintColor(Input_Bar.Use_Input_Bar_Number);
		}
	}//State_Button

	//(按鈕)副程式:開啟Input_Bar
	public void Use_Input_Bar(int Sudoku_Nober){
		//如果按下的按扭不是參考數字
		if (Sudoku_Array [Sudoku_Nober].Get_Sudoku_Bool () == false) {
			//改變現在狀態:選擇數字中
			State_Nubmer = 2;
			//播放輸入條上升動畫
			Animation_Controll.Animation_Number = 1;
			//設定Input_Bar是哪一個數獨陣列在使用
			Input_Bar.Use_Input_Bar_Number = Sudoku_Nober;
			//執行改變Button狀態
			Use_Bool = false;
			//存檔
			SaveGameExecutive.DoSave();
		}//if_(Sudoku_Array [Sudoku_Nober].Get_Sudoku_Bool () == false)
	}//Use_Input_Bar

	//(按鈕)副程式:檢查答案
	public void Button_Check(){
		//改變現在狀態:檢查中
		State_Nubmer = 3;
		//執行一次副程式
		Use_Bool = false;
		//檢查
		Check_Bool = Answer_Check.Check ();
	}

	//(按鈕)副程式:暫停
	public void GamePause_Button(){
		//改變現在狀態:暫停中
		State_Nubmer = 5;
		//執行一次副程式
		Use_Bool = false;
		//GameEndText顯示訊息:遊戲暫停
		GameEndText.text = "遊戲暫停";
		//顯示遊戲已花時間
		GameTimeText.text = "已花時間\n" + (int)GameTime + "秒";
		//暫停選單出現
		GameEnd_Object.SetActive(true);
		//暫停遊戲按鈕設為不可用
		GameEnd_Button.interactable = false;
		//執行一次副程式
		Use_Bool = false;
		//儲存資料
		SaveGameExecutive.DoSave ();
	}//Game_Button
		
	//(按鈕)副程式:重新開始遊戲
	public  void ReStartGame(){
		//改變狀態:遊戲中
		State_Nubmer = 1;
		//生成題目
		Create_Sudoku_Question.Create_Question();
		//改變數獨陣列和輸入條的按鈕
		State_Button ();
		//執行一次副程式
		Use_Bool = true;
		//暫停選單消失
		GameEnd_Object.SetActive(false);
		//暫停遊戲按鈕設為可用
		GameEnd_Button.interactable = true;
		//遊戲時間重新計算
		GameTime = 0.0f;
		//執行一次副程式
		Use_Bool = false;
		//儲存資料
		SaveGameExecutive.DoSave ();
	}//ReStartGame

	//(按鈕)副程式:恢復遊戲
	public  void ReGame(){
		//改變狀態:遊戲中
		State_Nubmer = 1;
		//播放輸入條下降動畫
		Animation_Controll.Animation_Number = 2;
		//改變數獨陣列和輸入條的按鈕
		State_Button ();
		//執行一次副程式
		Use_Bool = true;
		//暫停選單出現
		GameEnd_Object.SetActive(false);
		//暫停遊戲按鈕設為可用
		GameEnd_Button.interactable = true;
	}//ReGame

	//(按鈕)副程式:結束遊戲
	public void QuitGame(){
		Application.Quit();
	}

	//副程式:跟選擇的格子相關的格子
	void HintColor(int Sudoku_Nober){

		//直向--------------------------------
		//第一行
		if (Sudoku_Nober == 0 || Sudoku_Nober == 3 || Sudoku_Nober == 6 || Sudoku_Nober == 27 || Sudoku_Nober == 30 || Sudoku_Nober == 33 || Sudoku_Nober == 54 || Sudoku_Nober == 57 || Sudoku_Nober == 60) {
			Sudoku_Button [0].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [3].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [6].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [27].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [30].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [33].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [54].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [57].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [60].image.color = new Color32 (0, 0, 0, 255);
		}
		//第二行
		else if (Sudoku_Nober == 1 || Sudoku_Nober == 4 || Sudoku_Nober == 7 || Sudoku_Nober == 28 || Sudoku_Nober == 31 || Sudoku_Nober == 34 || Sudoku_Nober == 55 || Sudoku_Nober == 58 || Sudoku_Nober == 61) {
			Sudoku_Button [1].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [4].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [7].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [28].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [31].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [34].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [55].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [58].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [61].image.color = new Color32 (0, 0, 0, 255);
		}
		//第三行
		else if (Sudoku_Nober == 2 || Sudoku_Nober == 5 || Sudoku_Nober == 8 || Sudoku_Nober == 29 || Sudoku_Nober == 32 || Sudoku_Nober == 35 || Sudoku_Nober == 56 || Sudoku_Nober == 59 || Sudoku_Nober == 62) {
			Sudoku_Button [2].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [5].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [8].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [29].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [32].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [35].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [56].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [59].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [62].image.color = new Color32 (0, 0, 0, 255);
		}
		//第四行
		else if (Sudoku_Nober == 9 || Sudoku_Nober == 12 || Sudoku_Nober == 15 || Sudoku_Nober == 36 || Sudoku_Nober == 39 || Sudoku_Nober == 42 || Sudoku_Nober == 63 || Sudoku_Nober == 66 || Sudoku_Nober == 69) {
			Sudoku_Button [9].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [12].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [15].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [36].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [39].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [42].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [63].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [66].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [69].image.color = new Color32 (0, 0, 0, 255);
		}
		//第五行
		else if (Sudoku_Nober == 10 || Sudoku_Nober == 13 || Sudoku_Nober == 16 || Sudoku_Nober == 37 || Sudoku_Nober == 40 || Sudoku_Nober == 43 || Sudoku_Nober == 64 || Sudoku_Nober == 67 || Sudoku_Nober == 70) {
			Sudoku_Button [10].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [13].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [16].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [37].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [40].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [43].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [64].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [67].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [70].image.color = new Color32 (0, 0, 0, 255);
		}
		//第六行
		else if (Sudoku_Nober == 11 || Sudoku_Nober == 14 || Sudoku_Nober == 17 || Sudoku_Nober == 38 || Sudoku_Nober == 41 || Sudoku_Nober == 44 || Sudoku_Nober == 65 || Sudoku_Nober == 68 || Sudoku_Nober == 71) {
			Sudoku_Button [11].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [14].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [17].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [38].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [41].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [44].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [65].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [68].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [71].image.color = new Color32 (0, 0, 0, 255);
		}
		//第七行
		else if (Sudoku_Nober == 18 || Sudoku_Nober == 21 || Sudoku_Nober == 24 || Sudoku_Nober == 45 || Sudoku_Nober == 48 || Sudoku_Nober == 51 || Sudoku_Nober == 72 || Sudoku_Nober == 75 || Sudoku_Nober == 78) {
			Sudoku_Button [18].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [21].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [24].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [45].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [48].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [51].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [72].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [75].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [78].image.color = new Color32 (0, 0, 0, 255);
		}
		//第八行
		else if (Sudoku_Nober == 19 || Sudoku_Nober == 22 || Sudoku_Nober == 25 || Sudoku_Nober == 46 || Sudoku_Nober == 49 || Sudoku_Nober == 52 || Sudoku_Nober == 73 || Sudoku_Nober == 76 || Sudoku_Nober == 79) {
			Sudoku_Button [19].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [22].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [25].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [46].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [49].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [52].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [73].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [76].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [79].image.color = new Color32 (0, 0, 0, 255);
		}
		//第九行
		else if (Sudoku_Nober == 20 || Sudoku_Nober == 23 || Sudoku_Nober == 26 || Sudoku_Nober == 47 || Sudoku_Nober == 50 || Sudoku_Nober == 53 || Sudoku_Nober == 74 || Sudoku_Nober == 77 || Sudoku_Nober == 80) {
			Sudoku_Button [20].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [23].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [26].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [47].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [50].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [53].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [74].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [77].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [80].image.color = new Color32 (0, 0, 0, 255);
		}

		//橫向-----------------------------------------------------
		//第一列
		if (Sudoku_Nober == 0 || Sudoku_Nober == 1 || Sudoku_Nober == 2 || Sudoku_Nober == 9 || Sudoku_Nober == 10 || Sudoku_Nober == 11 || Sudoku_Nober == 18 || Sudoku_Nober == 19 || Sudoku_Nober == 20) {
			Sudoku_Button [0].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [1].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [2].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [9].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [10].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [11].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [18].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [19].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [20].image.color = new Color32 (0, 0, 0, 255);
		}
		//第二列
		else if (Sudoku_Nober == 3 || Sudoku_Nober == 4 || Sudoku_Nober == 5 || Sudoku_Nober == 12 || Sudoku_Nober == 13 || Sudoku_Nober == 14 || Sudoku_Nober == 21 || Sudoku_Nober == 22 || Sudoku_Nober == 23) {
			Sudoku_Button [3].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [4].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [5].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [12].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [13].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [14].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [21].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [22].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [23].image.color = new Color32 (0, 0, 0, 255);
		}
		//第三列
		else if (Sudoku_Nober == 6 || Sudoku_Nober == 7 || Sudoku_Nober == 8 || Sudoku_Nober == 15 || Sudoku_Nober == 16 || Sudoku_Nober == 17 || Sudoku_Nober == 24 || Sudoku_Nober == 25 || Sudoku_Nober == 26) {
			Sudoku_Button [6].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [7].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [8].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [15].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [16].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [17].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [24].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [25].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [26].image.color = new Color32 (0, 0, 0, 255);
		}
		//第四列
		else if (Sudoku_Nober == 27 || Sudoku_Nober == 28 || Sudoku_Nober == 29 || Sudoku_Nober == 36 || Sudoku_Nober == 37 || Sudoku_Nober == 38 || Sudoku_Nober == 45 || Sudoku_Nober == 46 || Sudoku_Nober == 47) {
			Sudoku_Button [27].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [28].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [29].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [36].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [37].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [38].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [45].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [46].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [47].image.color = new Color32 (0, 0, 0, 255);
		}
		//第五列
		else if (Sudoku_Nober == 30 || Sudoku_Nober == 31 || Sudoku_Nober == 32 || Sudoku_Nober == 39 || Sudoku_Nober == 40 || Sudoku_Nober == 41 || Sudoku_Nober == 48 || Sudoku_Nober == 49 || Sudoku_Nober == 50) {
			Sudoku_Button [30].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [31].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [32].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [39].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [40].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [41].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [48].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [49].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [50].image.color = new Color32 (0, 0, 0, 255);
		}
		//第六列
		else if (Sudoku_Nober == 33 || Sudoku_Nober == 34 || Sudoku_Nober == 35 || Sudoku_Nober == 42 || Sudoku_Nober == 43 || Sudoku_Nober == 44 || Sudoku_Nober == 51 || Sudoku_Nober == 52 || Sudoku_Nober == 53) {
			Sudoku_Button [33].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [34].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [35].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [42].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [43].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [44].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [51].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [52].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [53].image.color = new Color32 (0, 0, 0, 255);
		}
		//第七列
		else if (Sudoku_Nober == 54 || Sudoku_Nober == 55 || Sudoku_Nober == 56 || Sudoku_Nober == 63 || Sudoku_Nober == 64 || Sudoku_Nober == 65 || Sudoku_Nober == 72 || Sudoku_Nober == 73 || Sudoku_Nober == 74) {
			Sudoku_Button [54].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [55].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [56].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [63].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [64].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [65].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [72].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [73].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [74].image.color = new Color32 (0, 0, 0, 255);
		}
		//第八列
		else if (Sudoku_Nober == 57 || Sudoku_Nober == 58 || Sudoku_Nober == 59 || Sudoku_Nober == 66 || Sudoku_Nober == 67 || Sudoku_Nober == 68 || Sudoku_Nober == 75 || Sudoku_Nober == 76 || Sudoku_Nober == 77) {
			Sudoku_Button [57].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [58].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [59].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [66].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [67].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [68].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [75].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [76].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [77].image.color = new Color32 (0, 0, 0, 255);
		}
		//第九列
		else if (Sudoku_Nober == 60 || Sudoku_Nober == 61 || Sudoku_Nober == 62 || Sudoku_Nober == 69 || Sudoku_Nober == 70 || Sudoku_Nober == 71 || Sudoku_Nober == 78 || Sudoku_Nober == 79 || Sudoku_Nober == 80) {
			Sudoku_Button [60].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [61].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [62].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [69].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [70].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [71].image.color = new Color32 (0, 0, 0, 255);

			Sudoku_Button [78].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [79].image.color = new Color32 (0, 0, 0, 255);
			Sudoku_Button [80].image.color = new Color32 (0, 0, 0, 255);
		}

	}//HintColor

		
}//Main_Executive
