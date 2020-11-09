//調色盤
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
=========================================
(像素的陣列分配)
(0,255)                        (255,255)

(0,0)                          (255,0)
=========================================
*/
public class Palette_Script : MonoBehaviour
{
    //================================
    //變數
    //================================

    //用於內部計算像素
    Texture2D tex2d;
    //外部使用者觀看的調色盤
    public RawImage ri;

    //像素長度(0~255)
    int TexPixelLength = 256;
    //儲存色彩陣列
    Color[,] arrayColor;

    //=========================================
    // Use this for initialization
    //=========================================
    void Start()
    {
        //設定色彩陣列為256 X 256 大小
        arrayColor = new Color[TexPixelLength, TexPixelLength];
        //設定像素長寬 256 X 256
        tex2d = new Texture2D(TexPixelLength, TexPixelLength, TextureFormat.RGB24, true);
        //調色盤的長度跟tex2d一樣，並綁定ri會依照tex2d而改變
        ri.texture = tex2d;

        //初始化顏色
        SetColorPanel(Color.red);
    }

    //==========================================
    //計算完到顏色數組後，就可以將他繪製tex2d上，然後顯示在RawImage上(Color 最右上角的顏色)，給外部使用
    //==========================================
    public void SetColorPanel(Color endColor)
    {
        //使用CalcArrayColor()計算顏色
        Color[] CalcArray = CalcArrayColor(endColor);
        //設定tex2d每一點像素的顏色
        tex2d.SetPixels(CalcArray);
        //顯示到RawImage
        tex2d.Apply();
    }


    //=========================================
    //計算像素顏色，左下為黑色(0,0)，左上為白色，右上為自定義顏色(Endcolor 255,255)，右下為黑色，知道四個角落的顏色後就開始計算中間像素的顏色
    //=========================================
    Color[] CalcArrayColor(Color endColor)
    {
        //=======================
        //第一步
        //=======================
        //顏色代碼(0~255)，計算出每個像素之間的RGBA的差值
        Color value = (endColor - Color.white) / (TexPixelLength - 1);

        //先算最上面一排的顏色(像素位置)(0,255) ~ (255,255)
        for (int i = 0; i < TexPixelLength; i++)
        {
            //依照上面計算出的差值，將每個像素的顏色依照差值一一放入arrayColor (左右相反value * (255-i))
            arrayColor[i, TexPixelLength - 1] = Color.white + value * i;
        }

        //=======================
        //第二步
        //=======================
        //使用上面計算出的最上面一排的顏色，開始填滿以下的顏色(由下至上，由左至右)
        for (int i = 0; i < TexPixelLength; i++)
        {
            //計算同一直行間，每個像素的差值
            value = (arrayColor[i, TexPixelLength - 1] - Color.black) / (TexPixelLength - 1);

            //依照上面計算出的差值，將每個像素的顏色依照差值一一放入arrayColor
            for (int j = 0; j < TexPixelLength; j++)
            {
                arrayColor[i, j] = Color.black + value * j;
            }
        }

        //=======================
        //第三步
        //=======================
        //用於儲存上面計算最後的調色結果
        List<Color> listColor = new List<Color>();

        //放入List，(由下至上，由右至左)
        for (int i = 0; i < TexPixelLength; i++)
        {
            for (int j = 0; j < TexPixelLength; j++)
            {
                listColor.Add(arrayColor[j, i]);
            }
        }

        //回傳計算結果
        return listColor.ToArray();
    }//CalcArrayColor


    //======================================
    //副程式:讀取arrayColor[,]的顏色代碼
    //======================================
    public Color Read_Palette_arrayColor(int x , int y)
    {
        return arrayColor[x, y];
    }

}//Palette_Script
