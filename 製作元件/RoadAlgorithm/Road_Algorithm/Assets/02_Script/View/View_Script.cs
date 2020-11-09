//View腳本
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View_Script : MonoBehaviour
{
    //=============================================
    //宣告UI
    //=============================================
    
    //點
    //public Image[] Point;

    //路徑
    public Class_Road_Script[] Road;

    //=============================================
    //宣告變數
    //=============================================

    //=============================================
    //副程式:結果顯示(非完善)(全部路徑數量 , 全部最短路徑起點 , 全部最短路徑終點)
    //=============================================
    public void View_Show(int Road_Nubmer , int[] Road_X , int[] Road_Y)
    {
        //全部路徑
        for(int i=0; i< BaseVarible_SCript.ALL_Road_Number;  i++) {
            //確認的路徑
            for(int j=0; j< Road_Nubmer; j++)
            {
                //如果路徑的起點、終點符合確認的路徑起點終點，則設定路徑顏色
                if(Road[i].Read_Begin() == Road_X[j] && Road[i].Read_End() == Road_Y[j])
                {
                    Road[i].Set_OnRoad();
                }
            }//for j
        }// for i
    }

}
