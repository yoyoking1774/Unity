//執行腳本
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Execute_ControlScript : MonoBehaviour
{
    //=============================================
    //宣告腳本
    //=============================================

    //Dijkstra腳本
    public Dijkstra_ModelScript Dij;
    //Kruskal腳本
    public Kruskal_ModelScript Kru;
    //Prim腳本
    public Prim_ModelScript Pri;


    //View 腳本
    public View_Script View;


    //=============================================
    //宣告變數
    //=============================================

    //全部點的數量
    int Point_nubmer;

    //起點距離每個點最短距離
    int[] Mindis;

    //路徑
    int[] Road_X;
    int[] Road_Y;


    void Awake()
    {

        Dij = new Dijkstra_ModelScript(0);
        
        Exe_Initialize();

    }

    //=============================================
    //副程式:初始化
    //=============================================
    void Exe_Initialize()
    {
        Point_nubmer = BaseVarible_SCript.Point_nubmer;
        Mindis = new int[Point_nubmer];
        Road_X = new int[Point_nubmer-1];
        Road_Y = new int[Point_nubmer-1];
    }

    //=============================================
    //副程式:獲取路徑計算結果
    //=============================================
    void Get_Result()
    {
        Mindis = Dij.Read_Mindis();
        Road_X = Dij.Read_OnRoad_X();
        Road_Y = Dij.Read_OnRoad_Y();
    }

    //=============================================
    //副程式:執行
    //=============================================
    public void ExeFunction()
    {
        //計算路徑
        Dij.Dijkstra();
        //Kru.kruskal();
        //Pri.Prim();
        //獲取路徑計算結果
        Get_Result();
        //顯示結果
        View.View_Show(Point_nubmer - 1, Road_X, Road_Y);
    }
}
