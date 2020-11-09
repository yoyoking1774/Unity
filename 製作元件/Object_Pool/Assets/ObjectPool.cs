/*
1.資源Pool?
將一定數量的對象預先存儲在資源池中，當需要的時候使用，而不是每次都實例化一個對象，不用的時候再放回。
例如一款射擊類遊戲，需要不斷的發射子彈，如果每發射一顆子彈，都要實例化一個對象，隨後再銷燬對象，再實例化對象，必然會消耗較大的內存。
如果預先就將子彈實例化出一定的數量，並保存在彈夾中，發射的時候，取出來發射，不用的時候，再放回彈夾。
如此反覆利用，可以避免頻繁實例化和銷燬帶來的性能消耗。這裏的彈夾的概念就是資源池模式！

2.製作方法?
在遊戲開始時，預先實例化30枚子彈在場景中，並且隱藏起來。當坦克發射子彈的時候，顯示子彈。
當子彈碰撞到物體爆炸時，將其隱藏起來。
假設30枚子彈在同一時刻都在場景中使用（該遊戲規模較小，30枚子彈足夠了，但存在子彈不夠的情況），則實例化新的子彈，提供使用。
*/
//類別:物件池
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

	//宣告變數-------------------------------
	//預設生成30顆子彈
	public int count = 30;
	//子彈物件
	public GameObject bulletPrefab;
	//儲存生成的子彈
	private List<GameObject> bulletList = new  List<GameObject>();
	//發射器
	public GameObject Printer;

	//程式啟動初始化-------------------------
	private void Awake(){
		//生成子彈
		InitPool();
	}//Awake


	//副程式:初始化資源池
	private void InitPool(){
		for (int i = 0; i < count; i++)
			CreatBullet ();
	}//InitPool

	//副程式:子彈生成
	private GameObject CreatBullet(){
		//物件go生成為物件bulletPrefab(Instantiate(生成的物件,物件位置,物件旋轉值))
		GameObject go = Instantiate (bulletPrefab , Printer.transform.position , Printer.transform.rotation) as GameObject;
		//將生成的物件go加入到List中
		bulletList.Add (go);
		//設定生成在哪個物件下
		go.transform.SetParent (transform);
		//設定為隱藏
		go.SetActive (false);
		//回傳物件go
		return go;
	}//CreatBullet

	//副程式:使用子彈
	public GameObject GetBullet(){
		//如果List還有剩餘的子彈
		for (int i = 0; i < bulletList.Count; i++) {
			if (bulletList[i].activeInHierarchy == false) {
				//顯示子彈
				bulletList [i].SetActive (true);
				//設定生成在哪個物件下
				bulletList [i].transform.SetParent (transform);
				//回傳使用的子彈
				return bulletList [i];
			} 
		}

		//如果List沒有剩餘的子彈，生成新的子彈
		return CreatBullet ();

	}//GetBullet

	//副程式:回收子彈(回收成功回傳true，反之回傳false)
	public  bool PutBack(GameObject go){
		
		if (bulletList.Contains (go)) {
			//設定回收後子彈的位置
			go.transform.position = Printer.transform.position;
			//設定回收後子彈的旋轉值
			go.transform.rotation = Printer.transform.rotation;
			//隱藏子彈
			go.SetActive (false);

			//收回成功
			return true;
		}//if (bulletList.Contains (go))

		//收回失敗
		return false;
	}//PutBack


}//ObjectPool
