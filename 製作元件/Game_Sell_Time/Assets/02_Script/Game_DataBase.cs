//遊戲資料庫
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game_DataBase : MonoBehaviour {

	//宣告資料屬性------------------------------------------------------
	//現在平台數量
	public int Platform_Number = 6;
	//資料是否載入 true:載入 false:未載入================
	//PS平台
	public bool PS_Load_Bool = false;
	//Xbox平台
	public bool Xbox_Load_Bool = false;
	//PC平台
	public bool PC_Load_Bool = false;
	//Nintendo平台
	public bool Nintendo_Load_Bool = false;
	//Android平台
	public bool Android_Load_Bool = false;
	//ios平台
	public bool ios_Load_Bool = false;

	//PS平台======================
	//資料數
	private int PS_Data_Number = 50; 
	//遊戲圖片
	private List<Sprite> PS_Image = new List<Sprite>();
	//遊戲名稱
	private List<string> PS_Name = new List<string>();
	//遊戲英文名稱
	private List<string> PS_EName = new List<string>();
	//遊戲語言
	private List<string> PS_Language = new List<string>();
	//遊戲日期
	private List<string> PS_Date = new List<string>();

	//Xbox平台====================
	//資料數
	private int Xbox_Data_Number = 40; 
	//遊戲圖片
	private List<Sprite> Xbox_Image = new List<Sprite>();
	//遊戲名稱
	private List<string> Xbox_Name = new List<string>();
	//遊戲英文名稱
	private List<string> Xbox_EName = new List<string>();
	//遊戲語言
	private List<string> Xbox_Language = new List<string>();
	//遊戲日期
	private List<string> Xbox_Date = new List<string>();

	//PC平台======================
	//資料數
	private int PC_Data_Number = 50; 
	//遊戲圖片
	private List<Sprite> PC_Image = new List<Sprite>();
	//遊戲名稱
	private List<string> PC_Name = new List<string>();
	//遊戲英文名稱
	private List<string> PC_EName = new List<string>();
	//遊戲語言
	private List<string> PC_Language = new List<string>();
	//遊戲日期
	private List<string> PC_Date = new List<string>();

	//Nintendo平台================
	//資料數
	private int Nintendo_Data_Number = 50; 
	//遊戲圖片
	private List<Sprite> Nintendo_Image = new List<Sprite>();
	//遊戲名稱
	private List<string> Nintendo_Name = new List<string>();
	//遊戲英文名稱
	private List<string> Nintendo_EName = new List<string>();
	//遊戲語言
	private List<string> Nintendo_Language = new List<string>();
	//遊戲日期
	private List<string> Nintendo_Date = new List<string>();

	//Android平台================
	//資料數
	private int Android_Data_Number = 50; 
	//遊戲圖片
	private List<Sprite> Android_Image = new List<Sprite>();
	//遊戲名稱
	private List<string> Android_Name = new List<string>();
	//遊戲英文名稱
	private List<string> Android_EName = new List<string>();
	//遊戲語言
	private List<string> Android_Language = new List<string>();
	//遊戲日期
	private List<string> Android_Date = new List<string>();

	//ios平台================
	//資料數
	private int ios_Data_Number = 50; 
	//遊戲圖片
	private List<Sprite> ios_Image = new List<Sprite>();
	//遊戲名稱
	private List<string> ios_Name = new List<string>();
	//遊戲英文名稱
	private List<string> ios_EName = new List<string>();
	//遊戲語言
	private List<string> ios_Language = new List<string>();
	//遊戲日期
	private List<string> ios_Date = new List<string>();

	//測試用
	//public Sprite TestImage;

	/*
		讀取資料
	*/

	//副程式:讀取資料:PS
	public void Load_PS_Data(){
		//從最新的一筆資料開始放入
		for (int i = PS_Data_Number-1; i >= 0 ; i--) {
			//遊戲圖片
			PS_Image.Add ((Sprite)Resources.Load<Sprite>("PS"));
			//遊戲名稱
			PS_Name.Add ("人中之龍" + i);
			//遊戲英文名稱
			PS_EName.Add("Yakuza" + i);
			//遊戲語言
			PS_Language.Add ("語言" + i);
			//遊戲日期
			PS_Date.Add ("2018\n" + i + "/05");
		}

		//PS資料已載入
		PS_Load_Bool = true;
	}//Load_PS_Data

	//副程式:讀取資料:Xbox
	public void Load_Xbox_Data(){
		//從最新的一筆資料開始放入
		for (int i = Xbox_Data_Number-1; i >= 0 ; i--) {
			//遊戲圖片
			Xbox_Image.Add ((Sprite)Resources.Load<Sprite>("xbox")); 
			//遊戲名稱
			Xbox_Name.Add ("最後一之戰" + i);
			//遊戲英文名稱
			Xbox_EName.Add ("Halo" + i);
			//遊戲語言
			Xbox_Language.Add ("英語言" + i);
			//遊戲日期
			Xbox_Date.Add ("2018\n" + i + "/08");
		}

		//Xbox資料已載入
		Xbox_Load_Bool = true;
	}//Load_Xbox_Data

	//副程式:讀取資料:PC
	public void Load_PC_Data(){
		//從最新的一筆資料開始放入
		for (int i = PC_Data_Number-1; i >= 0 ; i--) {
			//遊戲圖片
			PC_Image.Add ((Sprite)Resources.Load<Sprite>("PC")); 
			//遊戲名稱
			PC_Name.Add ("黑暗靈魂" + i);
			//遊戲英文名稱
			PC_EName.Add ("Steam" + i);
			//遊戲語言
			PC_Language.Add ("中語言" + i);
			//遊戲日期
			PC_Date.Add ("2018\n" + i + "/11");
		}

		//PC資料已載入
		PC_Load_Bool = true;
	}//Load_PC_Data

	//副程式:讀取資料:Nintendo
	public void Load_Nintendo_Data(){
		//從最新的一筆資料開始放入
		for (int i = Nintendo_Data_Number-1; i >= 0 ; i--) {
			//遊戲圖片
			Nintendo_Image.Add ((Sprite)Resources.Load<Sprite>("Nintendo")); 
			//遊戲名稱
			Nintendo_Name.Add ("瑪莉歐" + i);
			//遊戲英文名稱
			Nintendo_EName.Add ("Mario" + i);
			//遊戲語言
			Nintendo_Language.Add ("日語言" + i);
			//遊戲日期
			Nintendo_Date.Add ("2018\n" + i + "/14");
		}

		//Nintendo資料已載入
		Nintendo_Load_Bool = true;
	}//Load_Nintendo_Data

	//副程式:讀取資料:Android
	public void Load_Android_Data(){
		//從最新的一筆資料開始放入
		for (int i = Android_Data_Number-1; i >= 0 ; i--) {
			//遊戲圖片
			Android_Image.Add ((Sprite)Resources.Load<Sprite>("Nintendo")); 
			//遊戲名稱
			Android_Name.Add ("安卓" + i);
			//遊戲英文名稱
			Android_EName.Add ("Android" + i);
			//遊戲語言
			Android_Language.Add ("Java語言" + i);
			//遊戲日期
			Android_Date.Add ("2018\n" + i + "/17");
		}

		//Android資料已載入
		Android_Load_Bool = true;
	}//Load_Android_Data

	//副程式:讀取資料:ios
	public void Load_ios_Data(){
		//從最新的一筆資料開始放入
		for (int i = ios_Data_Number-1; i >= 0 ; i--) {
			//遊戲圖片
			ios_Image.Add ((Sprite)Resources.Load<Sprite>("Nintendo")); 
			//遊戲名稱
			ios_Name.Add ("愛鳳" + i);
			//遊戲英文名稱
			ios_EName.Add ("iPhone" + i);
			//遊戲語言
			ios_Language.Add ("美語言" + i);
			//遊戲日期
			ios_Date.Add ("2018\n" + i + "/20");
		}

		//ios資料已載入
		ios_Load_Bool = true;
	}//Load_ios_Data

	//副程式:讀取全部平台資料
	public void Load_All_Data(){
		//PS平台
		if (PS_Load_Bool == false)Load_PS_Data ();
		//Xbox平台
		if (Xbox_Load_Bool == false)Load_Xbox_Data ();
		//PC平台
		if (PC_Load_Bool == false)Load_PC_Data ();
		//Nintendo平台
		if (Nintendo_Load_Bool == false)Load_Nintendo_Data ();
		//Android平台
		if (Android_Load_Bool == false)Load_Android_Data ();
		//ios平台
		if (ios_Load_Bool == false)Load_ios_Data();
	}

	//副程式:判斷資料是否載入
	public void is_Load_Data(int PageNumber){
		switch (PageNumber) {
		//PS
		case 0:
			//如果資料未載入則載入資料
			if (PS_Load_Bool == false)
				Load_PS_Data ();
			break;
			//Xbox
		case 1:
			//如果資料未載入則載入資料
			if (Xbox_Load_Bool == false)
				Load_Xbox_Data ();
			break;
			//PC
		case 2: 
			//如果資料未載入則載入資料
			if (PC_Load_Bool == false)
				Load_PC_Data ();
			break;
			//Nintendo
		case 3: 
			//如果資料未載入則載入資料
			if (Nintendo_Load_Bool == false)
				Load_Nintendo_Data ();
			break;
			//Android
		case 4:
			//如果資料未載入則載入資料
			if (Android_Load_Bool == false)
				Load_Android_Data ();
			break;
			//ios
		case 5:
			//如果資料未載入則載入資料
			if (ios_Load_Bool == false)
				Load_ios_Data ();
			break;
			//如果沒有，回傳PS資料數量
		default:
			//如果資料未載入則載入資料
			if (PS_Load_Bool == false)
				Load_PS_Data ();
			break;
		}//switch
	}//is_Load_Data

	/*
		回傳資料
	*/
	//副程式:回傳資料數量
	public int Call_Data_Number(int PageNubmer){
		switch (PageNubmer) {
		//PS
		case 0:
			return PS_Data_Number;
			break;
		//Xbox
		case 1:
			return Xbox_Data_Number;
			break;
		//PC
		case 2: 
			return PC_Data_Number;
			break;
		//Nintendo
		case 3: 
			return Nintendo_Data_Number;
			break;
		//Android
		case 4:
			return Android_Data_Number;
			break;
			//ios
		case 5:
			return ios_Data_Number;
			break;
		//如果沒有，回傳PS資料數量
		default:
			return PS_Data_Number;
			break;
		}
	}//Call_Data_Number

	//副程式:回傳資料(圖片)
	public Sprite Call_Image(int PageNubmer , int DataNumber){
		switch (PageNubmer) {
		//PS
		case 0:
			return PS_Image[DataNumber];
			break;
			//Xbox
		case 1:
			return Xbox_Image[DataNumber];
			break;
			//PC
		case 2: 
			return PC_Image[DataNumber];
			break;
			//Nintendo
		case 3: 
			return Nintendo_Image[DataNumber];
			break;
			//Android
		case 4:
			return Android_Image[DataNumber];
			break;
			//ios
		case 5:
			return ios_Image[DataNumber];
			break;
			//如果沒有，回傳PS圖片
		default:
			return PS_Image[DataNumber];
			break;
		}
	}//Call_Image

	//副程式:回傳資料(名稱)
	public string Call_Name(int PageNubmer , int DataNumber){
		switch (PageNubmer) {
		//PS
		case 0:
			return PS_Name[DataNumber];
			break;
			//Xbox
		case 1:
			return Xbox_Name[DataNumber];
			break;
			//PC
		case 2: 
			return PC_Name[DataNumber];
			break;
			//Nintendo
		case 3: 
			return Nintendo_Name[DataNumber];
			break;
			//Android
		case 4:
			return Android_Name[DataNumber];
			break;
			//ios
		case 5:
			return ios_Name[DataNumber];
			break;
			//如果沒有，回傳PS名稱
		default:
			return PS_Name[DataNumber];
			break;
		}
	}//Call_Name

	//副程式:回傳資料(英文名稱)
	public string Call_EName(int PageNubmer , int DataNumber){
		switch (PageNubmer) {
		//PS
		case 0:
			return PS_EName[DataNumber];
			break;
			//Xbox
		case 1:
			return Xbox_EName[DataNumber];
			break;
			//PC
		case 2: 
			return PC_EName[DataNumber];
			break;
			//Nintendo
		case 3: 
			return Nintendo_EName[DataNumber];
			break;
			//Android
		case 4:
			return Android_EName[DataNumber];
			break;
			//ios
		case 5:
			return ios_EName[DataNumber];
			break;
			//如果沒有，回傳PS英文名稱
		default:
			return PS_EName[DataNumber];
			break;
		}
	}//Call_Name

	//副程式:回傳資料(語言)
	public string Call_Language(int PageNubmer , int DataNumber){
		switch (PageNubmer) {
		//PS
		case 0:
			return PS_Language[DataNumber];
			break;
			//Xbox
		case 1:
			return Xbox_Language[DataNumber];
			break;
			//PC
		case 2: 
			return PC_Language[DataNumber];
			break;
			//Nintendo
		case 3: 
			return Nintendo_Language[DataNumber];
			break;
			//Android
		case 4:
			return Android_Language[DataNumber];
			break;
			//ios
		case 5:
			return ios_Language[DataNumber];
			break;
			//如果沒有，回傳PS語言
		default:
			return PS_Language[DataNumber];
			break;
		}
	}//Call_Language

	//副程式:回傳資料(日期)
	public string Call_Date(int PageNubmer , int DataNumber){
		switch (PageNubmer) {
		//PS
		case 0:
			return PS_Date[DataNumber];
			break;
			//Xbox
		case 1:
			return Xbox_Date[DataNumber];
			break;
			//PC
		case 2: 
			return PC_Date[DataNumber];
			break;
			//Nintendo
		case 3: 
			return Nintendo_Date[DataNumber];
			break;
			//Android
		case 4:
			return Android_Date[DataNumber];
			break;
			//ios
		case 5:
			return ios_Date[DataNumber];
			break;
			//如果沒有，回傳PS日期
		default:
			return PS_Date[DataNumber];
			break;
		}
	}//Call_Date


}//Game_DataBase
