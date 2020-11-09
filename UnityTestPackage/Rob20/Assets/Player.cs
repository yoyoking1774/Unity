//玩家端
/*
[SyncVar]
把Server端的參數同步到Client
[Command]
被標記的方法在Client被呼叫，Server上執行
[ClientRpc]
被標記的方法在Server被呼叫，Client上執行
isServer
執行環境是否為Server
isClient
執行環境是否為Client
isLoaclPlayer
執行環境是否是本機玩家
*/
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

//主程式===================================================================================================
public class Player : NetworkBehaviour
{
	//玩家的流程=============================================================================================
	public enum Process
	{
		start,  //遊戲初始化
		action, //自己的回合
		wait,   //對方的回合
		end     //遊戲結束
	}

	//宣告變數=================================================================================================
	public Image ImgPlayer1;  //玩家1圖案
	public Image ImgPlayer2;  //玩家2圖案
	GM gm;                    //設定Serve

	//[SyncVar]會同步Server端的Player.cs的參數到Client端=========================================================
	[SyncVar]
	public Process process = Process.start;

	[SyncVar]
	public string SysMsg;  //SysMsg是用來接收Server傳送過來的訊息用的

	public Button btnAddOne;  //按鈕: 數字加1
	public Button btnAddTwo;  //按鈕: 數字加2
	public Text txtMunber;    //玩家畫面數字
	public Text txtSysMsg;    //玩家畫面訊息

	[SyncVar]
	public int Munber;       //同步Server端與Client端的Munber這個變數

	//Start(抓到所有的物件實體)===================================================================================================================
	void Start()
	{
		if (isServer)
		{
			gm = GameObject.Find("GM").GetComponent<GM>();
			gm.Login(this);
		}

		if (isLocalPlayer)
		{
			txtSysMsg = GameObject.Find("txtSysMsg").GetComponent<Text>();
			txtMunber = GameObject.Find("txtMunber").GetComponent<Text>();   
			btnAddOne = GameObject.Find("btn1").GetComponent<Button>();
			btnAddTwo = GameObject.Find("btn2").GetComponent<Button>();
			btnAddOne.onClick.AddListener(() => CmdAddMunbers(1)); //onClick.AddListener()會把場景上的按鈕的onClicke事件與CmdAddMunbers()方法綁定
			btnAddTwo.onClick.AddListener(() => CmdAddMunbers(2)); //onClick.AddListener()會把場景上的按鈕的onClicke事件與CmdAddMunbers()方法綁定
		}

	}//Start結束===================================================================================================================
		
	//Update===================================================================================================================
	void Update()
	{
		if (isServer)
			Munber = gm.Mumber; //把數字抓回Server端的Player.cs
		
		if (isLocalPlayer)
		{
			txtSysMsg.text = SysMsg;             //更新玩家畫面的訊息
			txtMunber.text = Munber.ToString();  //更新玩家畫面的數字
		}
	}//Update結束===================================================================================================================

	//顯示玩家圖案=============================================================================================================================
	[ClientRpc]
	public void RpcSetPlayer(int id)
	{
		if (isLocalPlayer)
		{
			switch (id)
			{
			case 1:
				ImgPlayer1.gameObject.SetActive(true);
				break;
			case 2:
				ImgPlayer2.gameObject.SetActive(true);
				break;
			}
		}
	}

	//玩家加入遊戲================================================================================================================
	[Command]
	public void CmdAddMunbers(int addMun)
	{
		if (process == Process.action)
			gm.AddMunber(addMun);
	}

	public void SetProcess(Process process)
	{
		this.process = process;
	}



}//主程式結束=====================================================================================================================================