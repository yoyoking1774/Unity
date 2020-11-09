//計算時間腳本
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTime_Script : MonoBehaviour
{
    //===========================
    //宣告屬性**********************************
    //===========================
    //最大時間
    private int MaxTime = 120;
    //現在時間
    private int CurrentTime = 0;

    //Start
    void Start()
    {
        CurrentTime = MaxTime;
        //執行副程式:CountDown ，從0秒開始，每1秒執行1次
        InvokeRepeating("CountDown" , 0 , 1);
    }

    //===========================
    //副程式:計算時間
    //===========================
    void CountDown() {
        //減少時間
        CurrentTime = CurrentTime - 1;
        //將UI的Text，進行修改
        GetComponent<UnityEngine.UI.Text>().text = "Time\n" + CurrentTime;
    }//CountDown

}//CountTime_Script
