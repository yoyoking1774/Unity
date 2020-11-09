//Prim Algorithm
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prim_ModelScript : Class_RoadAlgorithm_Script
{
    //存在的路徑
    public Class_Road_Script[] Edge_Road;

    //用於記錄點現在所在集合 
    int[] PrimRoad = new int[BaseVarible_SCript.Point_nubmer];
    //集合編號 
    int PrimNumber = 1;

    //===========================================
    //建構子(無參數)
    //===========================================
    public Prim_ModelScript()
    {

    }

    //===========================================
    //建構子(有參數)
    //===========================================
    public Prim_ModelScript(int Start, int End, int Length, int Point, bool OnRoad ,bool OnGo)
    {

    }

    //==============================================
    //副程式(overload):紀錄最短路徑結果
    //==============================================
    void Road_Result(int Begin, int End)
    {
        OnRoad_X[OnRoad_Number] = Begin;
        OnRoad_Y[OnRoad_Number] = End;
        OnRoad[Begin] = true;
        OnRoad[End] = true;
        Road_Result();
    }


    //==============================================
    //副程式(overload):可以尋找下一個路徑 
    //==============================================
    void Road_Result()
    {
        //表示已找到最短路徑，可以記錄下一條路徑 
        OnRoad_Number = OnRoad_Number + 1;
    }


    //==============================================
    //副程式:判斷是否產生迴圈路徑 
    //==============================================
    bool Check_is_Loop(int Edge)
    {

        //如果是第一次放入路徑，則代表不會產生迴圈，放入集合內 
        if (PrimNumber == 1)
        {
            PrimRoad[Edge_Road[Edge].Read_Begin()] = PrimNumber;
            PrimRoad[Edge_Road[Edge].Read_End()] = PrimNumber;
            PrimNumber = PrimNumber + 1;
        }
        //如果邊的起點終點已存在於集合中 且 起點終點在同一集合內，表示產生迴圈 
        else if ((PrimRoad[Edge_Road[Edge].Read_Begin()] != 0 && PrimRoad[Edge_Road[Edge].Read_End()] != 0) && (PrimRoad[Edge_Road[Edge].Read_Begin()] == PrimRoad[Edge_Road[Edge].Read_End()]))
        {
            //將產生迴圈的邊設為無限大，防止再次搜尋 
            Edge_Road[Edge].Set_Length(ifs);
            return true;
        }
        //如果不是第一次放入路徑，而起點終點並不在集合內，也不跟集合內的點連接，則不會產生迴圈，放入新的集合內 
        else if ((PrimRoad[Edge_Road[Edge].Read_Begin()] == 0 && PrimRoad[Edge_Road[Edge].Read_End()] == 0))
        {
            PrimRoad[Edge_Road[Edge].Read_Begin()] = PrimNumber;
            PrimRoad[Edge_Road[Edge].Read_End()] = PrimNumber;
            PrimNumber = PrimNumber + 1;
        }
        //如果起點終點已存在於集合，但兩者在不同集合內，則不會產生迴圈 
        else if ((PrimRoad[Edge_Road[Edge].Read_Begin()] != 0 && PrimRoad[Edge_Road[Edge].Read_End()] != 0) && (PrimRoad[Edge_Road[Edge].Read_Begin()] != PrimRoad[Edge_Road[Edge].Read_End()]))
        {
            //由於不同集合相連接，則合併成同一個集合，已小編號的集合為主 
            if (PrimRoad[Edge_Road[Edge].Read_Begin()] > PrimRoad[Edge_Road[Edge].Read_End()])
            {
                for (int i = 0; i < BaseVarible_SCript.Point_nubmer; i++) if (PrimRoad[i] == PrimRoad[Edge_Road[Edge].Read_Begin()]) PrimRoad[i] = PrimRoad[Edge_Road[Edge].Read_End()];
            }
            else
            {
                for (int i = 0; i < BaseVarible_SCript.Point_nubmer; i++) if (PrimRoad[i] == PrimRoad[Edge_Road[Edge].Read_End()]) PrimRoad[i] = PrimRoad[Edge_Road[Edge].Read_Begin()];
            }
        }
        //如果起點終點，有一點不在集合內，而另一點在集合內，則不會產生迴圈，將不在集合內的那一點，放入進集合內 
        else
        {
            if (PrimRoad[Edge_Road[Edge].Read_Begin()] > PrimRoad[Edge_Road[Edge].Read_End()]) PrimRoad[Edge_Road[Edge].Read_End()] = PrimRoad[Edge_Road[Edge].Read_Begin()];
            else PrimRoad[Edge_Road[Edge].Read_Begin()] = PrimRoad[Edge_Road[Edge].Read_End()];
        }

        //沒有則回傳false，表示沒有產生迴圈 
        return false;

    }

    //==============================================
    //副程式:設定新的可以走的路徑 
    //==============================================
    void Set_New_Road_OnGO(int Edge)
    {
        
        //將選上的邊的起點終點可走的邊設為可走 
        for (int j = 0; j < BaseVarible_SCript.ALL_Road_Number; j++)
        {
            if (Edge_Road[j].Read_Begin() == Edge_Road[Edge].Read_Begin() || Edge_Road[j].Read_Begin() == Edge_Road[Edge].Read_End()) Edge_Road[j].Set_OnGo(true);
            if (Edge_Road[j].Read_End() == Edge_Road[Edge].Read_Begin() || Edge_Road[j].Read_End() == Edge_Road[Edge].Read_End()) Edge_Road[j].Set_OnGo(true);
            
        }
        
        //將選上的邊的起點終點設為包含在最短路徑 
        OnRoad[Edge_Road[Edge].Read_Begin()] = true;
        //將選上的邊的起點終點設為包含在最短路徑 
        OnRoad[Edge_Road[Edge].Read_End()] = true;
    }

    //==============================================
    //副程式:Prim algorithm
    //==============================================
    public void Prim()
    {
        //找出最短的邊 
        int min = ifs;
        //最短的邊，一開始還沒搜尋設為-1
        int Edge = -1;
        //迴圈用 
        int i, j, k;

        //將每個邊都尋訪一遍 

        //while (OnRoad_Number != (BaseVarible_SCript.Point_nubmer - 1))
        while (OnRoad_Number != (Point_nubmer - 1))
        {
            //已經算出全部路徑，則不再計算路徑
            if (OnRoad_Number >= BaseVarible_SCript.Point_nubmer - 1) break;

            //因為要重新尋找邊，所以將min初始化 
            min = ifs;

            //找出現在最短的邊 
            for (j = 0; j < BaseVarible_SCript.ALL_Road_Number; j++)
            {
                //如果邊還沒被選上 且 邊是可以走的 且 邊的長度<min 
                if (Edge_Road[j].Read_OnRoad() == false && Edge_Road[j].Read_OnGo() == true && Edge_Road[j].Read_Length() < min)
                {
                    //min = 邊的長度
                    min = Edge_Road[j].Read_Length();
                    //設定最短的邊
                    Edge = j;
                }

            }// for j
            
            //檢查會不會產生迴圈路徑 
            if (Check_is_Loop(Edge) == true) Edge_Road[Edge].Set_OnRoad(false);
            else Edge_Road[Edge].Set_OnRoad(true);
            
            //表示有新路徑加入 
            if (Edge_Road[Edge].Read_OnRoad() == true)
            {
                //設定新的可以走的路徑 
                Set_New_Road_OnGO(Edge);
                //可以尋找下一條路徑 
                Road_Result(Edge_Road[Edge].Read_Begin(), Edge_Road[Edge].Read_End());
            }

        }//while
        
        
    }

}
