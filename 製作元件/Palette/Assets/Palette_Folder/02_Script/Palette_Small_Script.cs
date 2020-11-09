//小畫面顯示現在顏色
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

public class Palette_Small_Script : MonoBehaviour
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
        Set_Small_ColorPanel(Color.red);
    }


    //==========================================
    //計算完到顏色數組後，就可以將他繪製tex2d上，然後顯示在RawImage上
    //==========================================
    public void Set_Small_ColorPanel(Color endColor)
    {
        //使用CalcArrayColor()計算顏色
        Color[] CalcArray = CalcArrayColor(endColor);
        //設定tex2d每一點像素的顏色
        tex2d.SetPixels(CalcArray);
        //顯示到RawImage
        tex2d.Apply();
    }

    //=========================================
    //計算像素顏色，全部的像素顏色都相同
    //=========================================
    Color[] CalcArrayColor(Color endColor)
    {
        //=======================
        //第一步
        //=======================
        
        //先算最上面一排的顏色(像素位置)(0,255) ~ (255,255)
        for (int i = 0; i < TexPixelLength; i++)
        {
            //由於全部的像素顏色都一樣，所以每的像素都設定為endColor
            arrayColor[i, TexPixelLength - 1] = endColor;
        }

        //=======================
        //第二步
        //=======================
        //使用最上面一排的顏色，開始填滿以下的顏色(由下至上，由左至右)
        for (int i = 0; i < TexPixelLength; i++)
        {
            //由於全部的像素顏色都一樣，所以每的像素都設定為endColor
            for (int j = 0; j < TexPixelLength; j++)
            {
                arrayColor[i, j] = endColor;
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

}
