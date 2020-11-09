//執行存檔讀檔
using UnityEngine;
using System.Collections;

public class SaveGameExecutive : MonoBehaviour {

	//儲存資料物件
	public static SavaGame Sav = new SavaGame ();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}


	//副程式:存檔
	public static void DoSave(){
		//記錄現在資料
		//數獨陣列
		for(int i=0; i<Main_Executive.Sudoku_Array.Length; i++){
			Sav.Sudoku_Nober [i] = Main_Executive.Sudoku_Array [i].Get_Sudoku_Nober ();
			Sav.Sudoku_Number [i] = Main_Executive.Sudoku_Array [i].Get_Sudoku_Number ();
			Sav.Sudoku_Bool [i] = Main_Executive.Sudoku_Array [i].Get_Sudoku_Bool ();
		}
		//狀態表(1:遊戲中 2:選擇數字中 3:檢查中 4:遊戲完成 5:暫停)
		Sav.State_Nubmer = Main_Executive.State_Nubmer;
		//題庫題目編號
		Sav.Question_Number = Main_Executive.Question_Number;
		//遊戲時間
		Sav.GameTime = Main_Executive.GameTime;
		//使用輸入條是哪1個數獨陣列
		Sav.Use_Input_Bar_Number = Input_Bar.Use_Input_Bar_Number;
		//答案是否正確 true:正確 fasle:不正確
		Sav.Check_Bool = Main_Executive.Check_Bool;
		//動畫編號
		Sav.Animation_Number = Animation_Controll.Animation_Number;
		//表示非初次執行
		Sav.First_Executive = false;
		//音樂是否播放 true:播放 false:暫停
		Sav.MusicBool = Music_Controll.PlayBool;
		//將Sav儲存的資料變為字串，存進Savefile_1
		PlayerPrefs.SetString("Savefile_1" , JsonUtility.ToJson(Sav));
		//print (PlayerPrefs.GetString("Savefile_1") + "\n儲存完畢");
	}//DoSave

	//副程式:讀檔
	public static void DoLoad(){
		//將Savefile_1儲存的資料放入Sav
		JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("Savefile_1"),Sav);

		//數獨陣列
		for(int i=0; i<Main_Executive.Sudoku_Array.Length; i++){
			Main_Executive.Sudoku_Array [i].Set_Sudoku_Nober (Sav.Sudoku_Nober [i]);
			Main_Executive.Sudoku_Array [i].Set_Sudoku_Number (Sav.Sudoku_Number[i]);
			Main_Executive.Sudoku_Array [i].Set_Sudoku_Bool (Sav.Sudoku_Bool[i]);
		}
		//狀態表(1:遊戲中 2:選擇數字中 3:檢查中 4:遊戲完成 5:暫停)
		Main_Executive.State_Nubmer = Sav.State_Nubmer;
		//題庫題目編號
		Main_Executive.Question_Number = Sav.Question_Number;
		//遊戲時間
		Main_Executive.GameTime = Sav.GameTime;
		//使用輸入條是哪1個數獨陣列
		Input_Bar.Use_Input_Bar_Number = Sav.Use_Input_Bar_Number ; 
		//答案是否正確 true:正確 fasle:不正確
		Main_Executive.Check_Bool = Sav.Check_Bool;
		//執行一次副程式
		Main_Executive.Use_Bool = false;
		//表示非初次執行
		Sav.First_Executive = false;
		//音樂是否播放 true:播放 false:暫停
		Music_Controll.PlayBool = Sav.MusicBool;
		//動畫編號
		Animation_Controll.Animation_Number = Sav.Animation_Number;

		//print ("載入完畢");
	}//DoLoad


}
