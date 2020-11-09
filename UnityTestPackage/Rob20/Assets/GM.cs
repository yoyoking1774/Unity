//Serve端
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
using System.Collections;
using System.Collections.Generic;


//主程式===================================================================================================
public class GM : MonoBehaviour
{
	//Round是回合，表示現在是哪一個玩家的回合===================================
	public enum Round
	{
		non,
		player1,
		player2
	}

	//遊戲流程=================================================================
	public enum Process
	{
		start,        //遊戲初始化
		waitLogin,    //等待玩家登入
		decidePlayer, //決定現在是哪個玩家進行動作
		p1Action,     //玩家1的回合
		p2Action,     //玩家2的回合
		checkWin,     //檢查數字是否達到勝利條件20
		end,          //遊戲結束
	}

	//宣告變數===================================================================================
	public List<Player> allPlayer = new List<Player>();
	public Round round = Round.non;
	public Process process = Process.start;
	int roundCount = -1;
	public int Mumber = 0;             //目前的數字,剛開始數字=0

	//登入====================================================================================
	public void Login(Player player)
	{
		allPlayer.Add(player);
		player.RpcSetPlayer(allPlayer.Count);

		if (allPlayer.Count == 2)    //玩家人數=2,遊戲流程變為開始遊戲
			process = Process.decidePlayer;
	}

	//接收一個參數，然後會把數字與參數相加====================================================================================
	public void AddMunber(int addMun)
	{
		Mumber += addMun;  //現在數字 = 現在數字 + 玩家選擇數字 

		if (Mumber >= 20)  //如果現在數字>=20,流程變為檢查贏家
			process = Process.checkWin;
		else               //如果現在數字<20,流程變為持續進行
			process = Process.decidePlayer;
	}

	//Start====================================================================================
	void Start()
	{
		process = Process.waitLogin;  //剛開始流程變為等待玩家
	}

	//Update====================================================================================
	void Update()
	{
		switch (process)
		{
		//遊戲等待玩家***************************************************************************
		case Process.waitLogin:
			foreach (Player pl in allPlayer)
				pl.SysMsg = "等待玩家連線...";
			break;
        
		//登入玩家有兩個的時候****************************************************************
		case Process.decidePlayer:
			roundCount++;  //回合數加1

			//%2來取除以2的餘數,餘數是1就是玩家1的回合，餘數是0就是玩家2的回合
			if (roundCount % 2 == 0)//p1回合
			{
				round = Round.player1;      //現在為玩家1回合
				process = Process.p1Action; //玩家的流程狀態要在action時按下按鈕才能喊數字

			}
			else//p2回合
			{
				round = Round.player2;      //現在為玩家2回合
				process = Process.p2Action; //玩家的流程狀態要在action時按下按鈕才能喊數字
			}
			break;

		//現在為玩家1回合更新畫面*****************************************************
		case Process.p1Action:
			allPlayer[0].SysMsg = "輪到你了!";
			allPlayer[0].SetProcess(Player.Process.action); //玩家1的流程變為活動
			allPlayer[1].SysMsg = "等待對方..."; 
			allPlayer[1].SetProcess(Player.Process.wait);   //玩家2的流程變為等待
			break;

		//現在為玩家1回合更新畫面**********************************************************
		case Process.p2Action:
			allPlayer[1].SysMsg = "輪到你了!";
			allPlayer[1].SetProcess(Player.Process.action); //玩家2的流程變為活動
			allPlayer[0].SysMsg = "等待對方...";
			allPlayer[0].SetProcess(Player.Process.wait);   //玩家1的流程變為等待
			break;
        
		//檢查贏家**************************************************************************
		case Process.checkWin:
			switch (round)
			{
			//玩家1回合
			case Round.player1:
				allPlayer[0].SysMsg = "Winner";
				allPlayer[1].SysMsg = "Loser";
				break;

			//玩家2回合
			case Round.player2:
				allPlayer[1].SysMsg = "Winner";
				allPlayer[0].SysMsg = "Loser";
				break;
			}

			allPlayer[0].SetProcess(Player.Process.end);  //玩家1的流程變為結束
			allPlayer[1].SetProcess(Player.Process.end);  //玩家2的流程變為結束
			process = Process.end;                        //遊戲流程變為結束 
			break;
		}//Update.Switch結束===================================================================================================
	}//Update結束==============================================================================================================

}//主程式結束