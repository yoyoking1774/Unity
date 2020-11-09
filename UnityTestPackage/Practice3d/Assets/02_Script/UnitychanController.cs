//UnityChan動畫控制
using UnityEngine;
using System.Collections;

public class UnitychanController : MonoBehaviour {

	//宣告變數
	private Animator UnityChanSelf;                //動畫控制器
	public bool Runbool,RunLbool,RunRbool,Jumpbool,Winbool,Losebool; //動畫狀態


	// Use this for initialization
	void Start () {
		//動畫綁定
		UnityChanSelf = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//更新人物動畫 SetBool(控制器中的參數的名稱,C#中的名稱) 將控制器中的參數的值 設定為 C#中的值
		UnityChanSelf.SetBool("RunBool",Runbool);
		//更新人物動畫 SetBool(控制器中的參數的名稱,C#中的名稱) 將控制器中的參數的值 設定為 C#中的值
		UnityChanSelf.SetBool("RunLBool",RunLbool);
		//更新人物動畫 SetBool(控制器中的參數的名稱,C#中的名稱) 將控制器中的參數的值 設定為 C#中的值
		UnityChanSelf.SetBool("RunRBool",RunRbool);
		//
		UnityChanSelf.SetBool("JumpBool",Jumpbool);
		//
		UnityChanSelf.SetBool("WinBool",Winbool);
		//
		UnityChanSelf.SetBool("LoseBool",Losebool);
	
	}
}
