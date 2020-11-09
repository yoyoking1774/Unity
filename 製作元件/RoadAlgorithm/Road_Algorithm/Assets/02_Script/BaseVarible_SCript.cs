//儲存基本全域變數腳本
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseVarible_SCript : MonoBehaviour
{
    //==============================================
    //宣告變數
    //==============================================
    //全部點的數量 
    public static int Point_nubmer = 7;
    //未知距離
    public static int ifs = 9999;
    //全部點的距離表 
    public static int[,] dis = new int[,]
    {
      { 0  ,32 ,ifs,ifs,ifs,3  ,ifs },
      {32 ,0  ,21 ,ifs,12 ,7  ,ifs},
      {ifs,21 ,0  ,ifs,6  ,2  ,11 },
      {ifs,ifs,ifs,0  ,13 ,ifs,9  },
      {ifs,12 ,6  ,13 ,0  ,ifs,ifs},
      {3  ,7  ,2  ,ifs,ifs,0  ,ifs},
      {ifs,ifs,11 ,9  ,ifs,ifs,0}
   };

    //起點距離每個點最短距離
    public static int[] Mindis = new int[] { 0, 32, ifs, ifs, ifs, 3, ifs };
    
    //畫面上共有多少路徑
    public static int ALL_Road_Number = 10;

    

}
