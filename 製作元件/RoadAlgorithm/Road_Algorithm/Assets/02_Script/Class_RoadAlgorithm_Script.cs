//所有路徑演算法的父類別(抽象)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Class_RoadAlgorithm_Script : MonoBehaviour
{
    //全部點的數量 
    public  int Point_nubmer;
    //未知距離
    public int ifs ;
    //全部點的距離表 
    public int[,] dis ;

    //起點距離每個點最短距離
    public int[] Mindis;

    //起點到各點所選的路徑( 依照Point_nubmerifs，因為最多只有點的數量-1的路徑 ) 
    public int[] OnRoad_X ;
    public int[] OnRoad_Y ;
    //紀錄已經包含路徑數量 
    public int OnRoad_Number = 0 ;

    //點是否已包含在路徑中，true:已包含 false:未包含 
    public bool[] OnRoad ;

    //===========================================
    //建構子(無參數)，依照BaseVarible_SCript.Point_nubmer配置陣列大小
    //===========================================
    public Class_RoadAlgorithm_Script()
    {
        //全部點的數量
        Point_nubmer = BaseVarible_SCript.Point_nubmer;
        //未知距離
        ifs = BaseVarible_SCript.ifs;
        //全部點的距離表 
        dis = BaseVarible_SCript.dis;
        //起點距離每個點最短距離
        Mindis = new int[BaseVarible_SCript.Point_nubmer];
        Mindis = BaseVarible_SCript.Mindis;
        //起點到各點所選的路徑
        OnRoad_X = new int[BaseVarible_SCript.Point_nubmer-1];
        OnRoad_Y = new int[BaseVarible_SCript.Point_nubmer-1];
        //點是否已包含在路徑中
        OnRoad = new bool[BaseVarible_SCript.Point_nubmer];
        
    }

    //========================================================
    //副程式(外):回傳起點距離每個點最短距離
    //========================================================
    public int[] Read_Mindis()
    {
        return Mindis;
    }

    //========================================================
    //副程式(外):回傳路徑
    //========================================================
    public int[] Read_OnRoad_X()
    {
        return OnRoad_X;
    }

    //========================================================
    //副程式(外):回傳路徑
    //========================================================
    public int[] Read_OnRoad_Y()
    {
        return OnRoad_Y;
    }



    //==============================================
    //副程式:是否已包含在路徑中初始化(使用者決定起點)
    //==============================================
    public void OnRoad_Initial(int Start)
    {
        //因為是起點，所以一開始就包含在路徑中 
        OnRoad[Start] = true;

        //將其它的點設為未包含在路徑中 
        for (int i = 0; i < BaseVarible_SCript.Point_nubmer; i++)
        {
            if (i != Start) OnRoad[i] = false;
        }
    }

}
