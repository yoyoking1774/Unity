//類別:遊戲資料儲存
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;


public class SavaGame {

	//宣告變數*********************************

	//編號
	public  int[] Sudoku_Nober = new int[81];
	//數字
	public  int[] Sudoku_Number = new int[81];
	//是否為參考數字 true:是 false:不是
	public  bool[] Sudoku_Bool = new bool[81];
	//狀態表(1:遊戲中 2:選擇數字中 3:檢查中 4:遊戲完成 5:暫停)
	public  int State_Nubmer = 0;
	//題庫題目編號
	public  int Question_Number = 0;
	//遊戲時間
	public  float GameTime = 0.0f;
	//使用輸入條是哪1個數獨陣列，依照陣列編號(預設0表示第1個)
	public  int Use_Input_Bar_Number = 0;
	//答案是否正確 true:正確 fasle:不正確
	public  bool Check_Bool = false;
	//動畫播放編號
	public int Animation_Number = 0;
	//是否初次執行 true:是初次執行 false:不是初次執行
	public bool First_Executive = true;
	//音樂是否播放 true:播放 false:暫停
	public bool MusicBool = true;

}//SavaGame

