//外部使用調色盤控制腳本
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Palette_Control_Script : MonoBehaviour
{
    //============================
    //變數
    //============================

    //顏色控制條
    public Palette_RGB_Script Prgb;

    //主要調色盤
    public Palette_Script Palette;

    //小型調色盤
    public Palette_Small_Script Palette_Small;

    //調色盤圓點
    public Palette_Move_Script Palette_Point;

    //調色盤圓點位置
    private Vector2 Palette_Point_Vector;

    //使用者調色盤選擇的顏色
    private Color NowColor = new Color(1, 1, 1);

    //使用者控制條選擇的顏色
    private Color RGB_NowColor = new Color(1, 1, 1);

   

    //======================================
    //控制條:給予使用者選擇顏色
    //======================================
    public void OnSliderValueChanged(float ColorNumber)
    {
        //依照ColorNumber來設定顏色
        RGB_NowColor = Prgb.Read_arrayColor(ColorNumber);

        //主要調色盤改變顏色
        Palette.SetColorPanel(RGB_NowColor);

        //改變現在選擇的顏色
        User_Color_Set();
    }

    //======================================
    //調色盤:給予使用者選擇顏色，放在Color_Point的EventTrigger下
    //======================================
    public void User_Color_Set()
    {
        //回傳現在圓點的座標
        Palette_Point_Vector = Palette_Point.Read_Point_Vector();

        //依照座標回傳調色盤上該座標的顏色
        NowColor = Palette.Read_Palette_arrayColor((int)Palette_Point_Vector.x, (int)Palette_Point_Vector.y);

        //給予Palette_Small調色盤現在的顏色
        Palette_Small.Set_Small_ColorPanel(NowColor);
    }

    


}//Palette_Control_Script
