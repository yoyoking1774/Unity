//Dijkstra Algorithm
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra_ModelScript : Class_RoadAlgorithm_Script
{
    //==============================================
    //宣告變數
    //==============================================
    //全部點的數量 
    /* private static int Point_nubmer = BaseVarible_SCript.Point_nubmer;
     //未知距離
     private static int ifs = BaseVarible_SCript.ifs;
     //全部點的距離表 
     int[,] dis = BaseVarible_SCript.dis;*/
    /* new int[,]
    {
      { 0  ,32 ,ifs,ifs,ifs,3  ,ifs },
      {32 ,0  ,21 ,ifs,12 ,7  ,ifs},
      {ifs,21 ,0  ,ifs,6  ,2  ,11 },
      {ifs,ifs,ifs,0  ,13 ,ifs,9  },
      {ifs,12 ,6  ,13 ,0  ,ifs,ifs},
      {3  ,7  ,2  ,ifs,ifs,0  ,ifs},
      {ifs,ifs,11 ,9  ,ifs,ifs,0}
   };*/


    //起點距離每個點最短距離(以a為起點) 
    /*int[] Mindis = new int[] { 0, 32, ifs, ifs, ifs, 3, ifs };
    
    //起點到各點所選的路徑( 依照Point_nubmerifs，因為最多只有點的數量-1的路徑 ) 
    int[] OnRoad_X = new int[Point_nubmer - 1];
    int[] OnRoad_Y = new int[Point_nubmer - 1];
    //紀錄已經包含路徑數量 
    int OnRoad_Number = 0;

    //點是否已包含在路徑中，true:已包含 false:未包含 
    bool[] OnRoad = new bool[Point_nubmer];*/



    // Start is called before the first frame update
    void Start()
    {
        //初始化
        //OnRoad_Initial(0);
        //執行
        //Dijkstra();
        //輸出距離結果 
        //Print_Mindis_Result();
        //輸出路徑結果
        //Print_Road_Result();
    }

    //===========================================
    //建構子(無參數)
    //===========================================
    public Dijkstra_ModelScript()
    {
        //預設從第一個點開始
        OnRoad_Initial(0);
    }

    //===========================================
    //建構子(有參數)
    //===========================================
    public Dijkstra_ModelScript(int Start)
    {
        //依照使用者決定從哪個點開始
        OnRoad_Initial(Start); 
    }

    
    //========================================================
    //外部使用Function
    //========================================================

    //==============================================
    //副程式:輸出最短距離結果
    //==============================================
    void Print_Mindis_Result()
    {
        for (int i = 0; i < Point_nubmer; i++) print(Mindis[i] + " ");
    }



    //==============================================
    //副程式(overload):紀錄最短路徑結果
    //==============================================
    void Road_Result(int x, int y)
    {
        //檢查新的點已經有舊的路徑存在 
        for (int i = 0; i < OnRoad_Number; i++)
        {
            //如果有，則新的路徑覆蓋舊的路徑	
            if (OnRoad_Y[i] == y)
            {
                OnRoad_X[i] = x;
                OnRoad_Y[i] = y;
                //沒有新的路徑加入，因為OnRoad_Number每次都會+1所以要-1 
                OnRoad_Number = OnRoad_Number - 1;
                break;
            }
            //如果沒有，則加入新的路徑 
            else
            {
                OnRoad_X[OnRoad_Number] = x;
                OnRoad_Y[OnRoad_Number] = y;
            }

        }//for i

        //如果是第一條路徑，也就是起點 
        if (OnRoad_Number == 0)
        {

            OnRoad_X[OnRoad_Number] = x;
            OnRoad_Y[OnRoad_Number] = y;
        }

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
    //副程式:輸出最短路徑結果
    //==============================================
    void Print_Road_Result()
    {
        for (int i = 0; i < Point_nubmer - 1; i++) print(i + ":" + " ( " + OnRoad_X[i] + " , " + OnRoad_Y[i] + " )");
    }


    //==============================================
    //副程式:Dijkstra's algorithm
    //==============================================
    public void Dijkstra()
    {
        //找出距離起點最近的距離
        int min = ifs;
        //最近的點
        int Point = 0;
        //迴圈用 
        int i, j, k;

        //要尋過所有的點，但起點不算，所以要少一次 
        for (i = 1; i < Point_nubmer; i++)
        {
            //因為要重新尋點，所以要恢復預設值 
            min = ifs;

            //===========================
            //尋找現在離起點最近的點 
            //===========================
            //尋過所有的點，但起點不算，所以要少一次 
            for (j = 0; j < Point_nubmer; j++)
            {
                //如果此點不在路徑 且 此點的距離 < min，表示可能可以放進路徑 
                if (OnRoad[j] == false && Mindis[j] < min)
                {
                    //將min設為現在找到離起點最近的點的距離，也可能找出更短的路徑 
                    min = Mindis[j];
                    //設定最近的點 
                    Point = j;
                }
            }//for j

            //===========================
            //決定最近的點放入路徑
            //===========================
            OnRoad[Point] = true;

            //================================= 
            //第一次要放入起點到第一個點的路徑 
            //================================= 
            if (i == 1)
            {
                //放入路徑
                Road_Result(0, Point);
                //可以尋找下一條路徑 
                Road_Result();
            }


            //============================================= 
            //因為加入新的點，所以新增下次可以走的路徑 
            //============================================= 
            for (k = 0; k < Point_nubmer; k++)
            {

                //如果路徑是可以走的，因為不能走的距離為無限，且不能跟自己比，因為一定最近 
                if ((Point != k) && dis[Point, k] < ifs)
                {

                    //如果起點到另一點的距離(例:a->c)，可以由另一更短路徑(a->b->c)，則將路徑設為更短路徑 
                    if (Mindis[k] > Mindis[Point] + dis[Point, k])
                    {
                        Mindis[k] = Mindis[Point] + dis[Point, k];
                        //放入路徑 
                        Road_Result(Point, k);
                        //可以尋找下一條路徑 
                        Road_Result();
                    }

                }

            }//for k

        }//for i

        //已經算出全部路徑，將OnRoad_Number歸0，防止再次搜尋時超出範圍
        OnRoad_Number = 0;
        
    }
}
