/*
1.資源Pool?
將一定數量的對象預先存儲在資源池中，當需要的時候使用，而不是每次都實例化一個對象，不用的時候再放回。
例如一款射擊類遊戲，需要不斷的發射遊戲資料物件，如果每發射一顆遊戲資料物件，都要實例化一個對象，隨後再銷燬對象，再實例化對象，必然會消耗較大的內存。
如果預先就將遊戲資料物件實例化出一定的數量，並保存在彈夾中，發射的時候，取出來發射，不用的時候，再放回彈夾。
如此反覆利用，可以避免頻繁實例化和銷燬帶來的性能消耗。這裏的彈夾的概念就是資源池模式！

2.製作方法?
在遊戲開始時，預先實例化30枚遊戲資料物件在場景中，並且隱藏起來。當坦克發射遊戲資料物件的時候，顯示遊戲資料物件。
當遊戲資料物件碰撞到物體爆炸時，將其隱藏起來。
假設30枚遊戲資料物件在同一時刻都在場景中使用（該遊戲規模較小，30枚遊戲資料物件足夠了，但存在遊戲資料物件不夠的情況），則實例化新的遊戲資料物件，提供使用。
*/
//類別:物件池
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ObjectPool : MonoBehaviour {

	//宣告變數-------------------------------
	//預設生成30個遊戲資料物件
	public int count = 30;
	//遊戲資料物件物件
	public GameObject bulletPrefab;
	//遊戲資料
	GameDetail_Class GameClass;
	//儲存生成的遊戲資料物件
	private List<GameObject> bulletList = new  List<GameObject>();
	//發射器
	public GameObject Printer;
	//現在遊戲資料物件數量，因為是從0號開始生成所以是30-1=29
	public static int Now_Amount = 29;
	//讀取圖片
	public Sprite im;
	public Sprite im_Xbox;

	//資料庫
	public Game_DataBase UseDataBase = new Game_DataBase();

	//程式啟動初始化-------------------------
	private void Awake(){
		//預設讀取資料:PS
		UseDataBase.Load_PS_Data ();
		UseDataBase.Load_Xbox_Data ();
		//生成遊戲資料物件
		InitPool();
	}//Awake


	//副程式:初始化資源池
	private void InitPool(){
		for (int i = 0; i < count; i++) 
			CreatBullet (PageChangeScript.PageNumber , i);
	}//InitPool

	//副程式:遊戲資料物件生成
	private GameObject CreatBullet(int PageNumber , int DataNubmer){
		
		//物件go生成為物件bulletPrefab(Instantiate(生成的物件,物件位置,物件旋轉值))
		GameObject go = Instantiate (bulletPrefab , (Printer.transform.position - new Vector3(0.0f , (DataNubmer*4.0f) , 0.0f)), Printer.transform.rotation) as GameObject;
		//抓取go底下的GameDetail_Class腳本
		GameClass = go.GetComponent<GameDetail_Class>();
		//設定UI
		GameClass.Set_All_Detail (UseDataBase.Call_Image(PageNumber , DataNubmer), UseDataBase.Call_Name(PageNumber , DataNubmer), UseDataBase.Call_EName(PageNumber , DataNubmer), UseDataBase.Call_Language(PageNumber , DataNubmer),  UseDataBase.Call_Date(PageChangeScript.PageNumber , DataNubmer));
		//將生成的物件go加入到List中
		bulletList.Add (go);
		//設定生成在哪個物件下
		go.transform.SetParent (transform);
		//設定為開啟
		go.SetActive (true);
		//設定資料的大小
		go.transform.localScale = Vector3.one;
		//回傳物件go
		return go;

	}//CreatBullet

	//副程式:使用遊戲資料物件
	public GameObject GetBullet(){
		//如果資料庫沒有資料，不回傳任何資料
		if(Now_Amount >= UseDataBase.Call_Data_Number(PageChangeScript.PageNumber)-1) return null;

		//如果List還有剩餘的遊戲資料物件
		for (int i = 0; i < bulletList.Count; i++) {
			if (bulletList[i].activeInHierarchy == false) {
				//顯示遊戲資料物件
				bulletList [i].SetActive (true);
				//設定生成在哪個物件下
				bulletList [i].transform.SetParent (transform);
				//回傳使用的遊戲資料物件
				return bulletList [i];
			} 
		}

		//現在資料數量
		Now_Amount = Now_Amount + 1;
		//如果List沒有剩餘的遊戲資料物件，生成新的遊戲資料物件
		return CreatBullet (PageChangeScript.PageNumber , Now_Amount);

	}//GetBullet

	//副程式:搜尋時使用遊戲資料物件
	public GameObject SearchGetGameDetail_Class(int PageNumber , int DataNubmer , int SerachDataNumber){
		
		//如果List還有剩餘的遊戲資料物件
		if ( SerachDataNumber <= Now_Amount && bulletList [SerachDataNumber].activeInHierarchy == false ) {
			//顯示遊戲資料物件
			bulletList [SerachDataNumber].SetActive (true);
			//設定生成在哪個物件下
			bulletList [SerachDataNumber].transform.SetParent (transform);
			//抓取go底下的GameDetail_Class腳本
			GameClass = bulletList [SerachDataNumber].GetComponent<GameDetail_Class> ();
			//設定UI
			GameClass.Set_All_Detail (UseDataBase.Call_Image(PageNumber , DataNubmer), UseDataBase.Call_Name(PageNumber , DataNubmer), UseDataBase.Call_EName(PageNumber , DataNubmer), UseDataBase.Call_Language(PageNumber , DataNubmer),  UseDataBase.Call_Date(PageNumber , DataNubmer));

			//回傳使用的遊戲資料物件
			return bulletList [SerachDataNumber];
		}


		//現在資料數量
		Now_Amount = Now_Amount + 1;
		//如果List沒有剩餘的遊戲資料物件，生成新的遊戲資料物件
		return CreatBullet (PageNumber , DataNubmer);

	}//SearchGetGameDetail_Class

	//副程式:回收遊戲資料物件(回收成功回傳true，反之回傳false)
	public void PutBack(){
		for (int i = 0; i <= Now_Amount; i++) {
			bulletList [i].SetActive (false);
		}
	
	}//PutBack
		
	//副程式:頁面資料切換(int 平台編號)
	public void PageChangeData(int PageNumber){
		//回收所有遊戲資料物件
		PutBack();
		//更新所有的遊戲資料物件
		for(int i=0; i<=Now_Amount; i++){
			//如果超過資料庫擁有的資料則跳出
			if(i >= UseDataBase.Call_Data_Number(PageNumber)) break;

			switch (PageNumber){
			//PS平台
			case 0:
				//顯示遊戲資料物件
				bulletList [i].SetActive (true);
				//抓取go底下的GameDetail_Class腳本
				GameClass = bulletList [i].GetComponent<GameDetail_Class> ();
				//設定UI
				GameClass.Set_All_Detail (UseDataBase.Call_Image (PageNumber, i), UseDataBase.Call_Name (PageNumber, i), UseDataBase.Call_EName (PageNumber, i), UseDataBase.Call_Language (PageNumber, i), UseDataBase.Call_Date (PageNumber, i));
				break;
			//Xbox平台
			case 1: 
				//讀取xbox資料
				UseDataBase.is_Load_Data(PageNumber);
				//顯示遊戲資料物件
				bulletList [i].SetActive (true);
				//顯示遊戲資料物件
				bulletList [i].SetActive (true);
				//抓取go底下的GameDetail_Class腳本
				GameClass = bulletList [i].GetComponent<GameDetail_Class> ();
				//設定UI
				GameClass.Set_All_Detail (UseDataBase.Call_Image (PageNumber, i), UseDataBase.Call_Name (PageNumber, i), UseDataBase.Call_EName (PageNumber, i), UseDataBase.Call_Language (PageNumber, i), UseDataBase.Call_Date (PageNumber, i));
				break;
			//PC平台
			case 2: 
				//讀取PC資料
				UseDataBase.is_Load_Data(PageNumber);
				//顯示遊戲資料物件
				bulletList [i].SetActive (true);
				//抓取go底下的GameDetail_Class腳本
				GameClass = bulletList [i].GetComponent<GameDetail_Class> ();
				//設定UI
				GameClass.Set_All_Detail (UseDataBase.Call_Image (PageNumber, i), UseDataBase.Call_Name (PageNumber, i), UseDataBase.Call_EName (PageNumber, i), UseDataBase.Call_Language (PageNumber, i), UseDataBase.Call_Date (PageNumber, i));
				break;
			//Nintendo平台
			case 3:
				//讀取Nintendo資料
				UseDataBase.is_Load_Data(PageNumber);
				//顯示遊戲資料物件
				bulletList [i].SetActive (true);
				//抓取go底下的GameDetail_Class腳本
				GameClass = bulletList [i].GetComponent<GameDetail_Class> ();
				//設定UI
				GameClass.Set_All_Detail (UseDataBase.Call_Image (PageNumber, i), UseDataBase.Call_Name (PageNumber, i), UseDataBase.Call_EName (PageNumber, i), UseDataBase.Call_Language (PageNumber, i), UseDataBase.Call_Date (PageNumber, i));
				break;
				//Android平台
			case 4:
				//讀取Android資料
				UseDataBase.is_Load_Data(PageNumber);
				//顯示遊戲資料物件
				bulletList [i].SetActive (true);
				//抓取go底下的GameDetail_Class腳本
				GameClass = bulletList [i].GetComponent<GameDetail_Class> ();
				//設定UI
				GameClass.Set_All_Detail (UseDataBase.Call_Image (PageNumber, i), UseDataBase.Call_Name (PageNumber, i), UseDataBase.Call_EName (PageNumber, i), UseDataBase.Call_Language (PageNumber, i), UseDataBase.Call_Date (PageNumber, i));
				break;
				//Nintendo平台
			case 5:
				//讀取ios資料
				UseDataBase.is_Load_Data(PageNumber);
				//顯示遊戲資料物件
				bulletList [i].SetActive (true);
				//抓取go底下的GameDetail_Class腳本
				GameClass = bulletList [i].GetComponent<GameDetail_Class> ();
				//設定UI
				GameClass.Set_All_Detail (UseDataBase.Call_Image (PageNumber, i), UseDataBase.Call_Name (PageNumber, i), UseDataBase.Call_EName (PageNumber, i), UseDataBase.Call_Language (PageNumber, i), UseDataBase.Call_Date (PageNumber, i));
				break;
			//Search頁面
			default:
				if (bulletList [i].activeInHierarchy == true) {
					//隱藏遊戲資料物件
					bulletList [i].SetActive (false);
				}//bulletList [i].activeInHierarchy == true
				break;
			}//switch
		}//for(int i=0; i<bulletList.Count; i++)
	}//PageChangeData

}//ObjectPool
