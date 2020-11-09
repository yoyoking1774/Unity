using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat_Coin : MonoBehaviour
{
    //===========================
    //宣告變數****************************************************************
    //===========================

    //===========================
    //金幣是否被吃掉 true:被吃掉 false:未被吃掉
    //===========================
    private bool EatenCoin_Bool = false;

    //===========================
    //副程式:金幣被Player吃掉
    //===========================
    void EatenCoin()
    {
        //銷毀金幣自身
        Destroy(this.gameObject);
    }

    //===========================
    //觸發****************************************************************
    //===========================

    //===========================
    //觸發:進入
    //===========================
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        //如果碰到Player
        if (collision.tag == "Player") {
            //播放吃到金幣動畫
            GetComponent<Animator>().Play("Coin_Damp");
            //呼叫player身上的腳本PlayerState，執行方法Coin_Add
            collision.gameObject.SendMessage("Coin_Add", 1);
            print("吃到金幣");
            EatenCoin_Bool = true;
        }
        else{
            return;
        }

    }//OnTriggerEnter2D

    

}
