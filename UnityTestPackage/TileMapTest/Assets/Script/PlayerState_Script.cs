using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Script : MonoBehaviour
{
    //===========================
    //宣告屬性*****************************************
    //===========================
    //已獲得的金幣數量
    private int Coins_Number = 0;
    //已獲得的分數
    private int Score_Number = 0;
    //Player生命值
    private float Hp = 3.0f;


    void Start()
    {
        //讀檔
        LoadGame();
    }

    //===========================
    //宣告副程式*****************************************
    //===========================

    //===========================
    //金幣增加
    //===========================
    public void Coin_Add(int Amount)
    {
        Coins_Number = Coins_Number + Amount;
        print("金幣數量: " + Coins_Number);
    }

    //===========================
    //分數增加
    //===========================
    public void Score_Add(int Amount)
    {
        Score_Number = Score_Number + Amount;
        print("分數: " + Score_Number);
    }

    //===========================
    //HP減少
    //===========================
    public void Hp_Decrease(float Amount)
    {
        Hp = Hp - Amount;
        print("Hp: " + Hp);
        //如果生命值歸0，則執行副程式Move_Script的GameOver
        if (Hp <= 0)
        {
            SendMessage("GameOver");
        }

    }//Hp_Decrease

    //===========================
    //存檔
    //===========================
    void SaveGame() {
        GameState.Coins_Number = Coins_Number;
        GameState.Score_Number = Score_Number;
    }//SaveGame

    //===========================
    //讀檔
    //===========================
    void LoadGame() {
        Coins_Number = GameState.Coins_Number;
        Score_Number = GameState.Score_Number;
    }//LoadGame

}//PlayerState_Script
