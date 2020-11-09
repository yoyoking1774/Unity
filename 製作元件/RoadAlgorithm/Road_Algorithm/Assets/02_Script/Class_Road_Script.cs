//類別:路徑
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Class_Road_Script : MonoBehaviour
{
    //=============================================
    //宣告屬性
    //=============================================
    //路徑起點
    public int Begin =0;
    //路徑終點
    public int End=0;
    //路徑長度
    public int Length = 0;
    //路徑編號
    public int Point = 0;
    //路徑是否包含在最短路徑中
    public bool OnRoad = false;
    //路徑是否可走
    public bool OnGo = false;

    //路徑Image
    private Image Im;




    void Start()
    {
        //綁定Image
        Im = GetComponent<Image>();
    }

    //=============================================
    //方法
    //=============================================

    //=============================================
    //Set
    //=============================================

    //=============================================
    //設定路徑顏色，表示在最短路徑內
    //=============================================
    public void Set_OnRoad()
    {
        Im.color = new Color(0, 1, 0);
    }

    public void Set_Begin(int Number)
    {
        Begin = Number;
    }

    public void Set_End(int Number)
    {
        End = Number;
    }

    public void Set_Length(int Number)
    {
        Length = Number;
    }

    public void Set_Point(int Number)
    {
        Point = Number;
    }

    public void Set_OnRoad(bool Number)
    {
        OnRoad = Number;
    }

    public void Set_OnGo(bool Number)
    {
        OnGo = Number;
    }

    //=============================================
    //回傳起點
    //=============================================
    public int Read_Begin()
    {
        return Begin;
    }

    //=============================================
    //回傳終點
    //=============================================
    public int Read_End()
    {
        return End;
    }

    public int Read_Length()
    {
        return Length;
    }

    public int Read_Point()
    {
        return Point;
    }

    public bool Read_OnRoad()
    {
        return OnRoad;
    }

    public bool Read_OnGo()
    {
        return OnGo;
    }
}
