//控制改變調色盤顏色的顏色條
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 (0,0) (0,16) 
     
 (255,0) (255,16)    
*/
public class Palette_RGB_Script : MonoBehaviour
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
    //色彩深度，共2^16 = 65536種顏色
    int TexPixelWdith = 16;
    //儲存色彩陣列
    Color[,] arrayColor;

   

    //====================================================
    // Start is called before the first frame update
    //====================================================
    void Start()
    {
        //設定色彩陣列為16 X 256 大小
        arrayColor = new Color[TexPixelWdith, TexPixelLength];
        //設定像素長寬 16 X 256
        tex2d = new Texture2D(TexPixelWdith, TexPixelLength, TextureFormat.RGB24, true);
        //調色盤的長度跟tex2d一樣，並綁定ri會依照tex2d而改變
        ri.texture = tex2d;

        //初始化顏色
        SetColorPanel();
    }


    //==========================================
    //計算完到顏色數組後，就可以將他繪製tex2d上，然後顯示在RawImage上(Color 最右上角的顏色)，給外部使用
    //==========================================
    public void SetColorPanel()
    {
        //使用CalcArrayColor()計算顏色
        Color[] CalcArray = Change_CalcArrayColor();
        //設定tex2d每一點像素的顏色
        tex2d.SetPixels(CalcArray);
        //顯示到RawImage
        tex2d.Apply();
    }

    //====================================================
    //改變顏色的變色條，右邊較細的一條顏色條
    //====================================================
    Color[] Change_CalcArrayColor()
    {
        //=============================================
        //第一步
        //=============================================

        //先計算RGB，三原色的啟始位置之間的差值
        int addValue = (TexPixelLength - 1) / 3;
        //依照上述差值，設定三原色位置
        for (int i = 0; i < TexPixelWdith; i++)
        {
            //Red(頂端)
            arrayColor[i, 0] = Color.red;
            //Green(中間)
            arrayColor[i, addValue] = Color.green;
            //Blue(中間)
            arrayColor[i, addValue + addValue] = Color.blue;
            //Red(底部)
            arrayColor[i, TexPixelLength - 1] = Color.red;
        }

        //=============================================
        //第二步，開始依照上述RGB的啟始位置，計算其它顏色
        //=============================================

        //計算 綠色~紅色 之間的顏色差值，(除上addValue是因為這一段差值最多只有這些顏色)
        Color value = (Color.green - Color.red) / addValue;

        //依照上述差值，設定顏色(0 ~ addValue)
        for (int i = 0; i < TexPixelWdith; i++)
        {
            for (int j = 0; j < addValue; j++)
            {
                arrayColor[i, j] = Color.red + value * j;
            }
        }

        //=============================================
        //第三步
        //=============================================

        //計算 藍色~綠色 之間的顏色差值，(除上addValue是因為這一段差值最多只有這些顏色)
        value = (Color.blue - Color.green) / addValue;

        //依照上述差值，設定顏色(addValue ~ addValue * 2)，(j-addValue是因為要從0開始加，但j是從addValue開始)
        for (int i = 0; i < TexPixelWdith; i++)
        {
            for (int j = addValue; j < addValue * 2; j++)
            {
                arrayColor[i, j] = Color.green + value * (j - addValue);
            }
        }

        //=============================================
        //第四步
        //=============================================

        //計算 紅色(底部)~藍色 之間的顏色差值，(除上addValue是因為這一段差值最多只有這些顏色)
        value = (Color.red - Color.blue) / ((TexPixelLength - 1) - addValue - addValue);

        //依照上述差值，設定顏色(addValue * 2 ~ 最後的顏色)，(j-addValue*2 是因為要從0開始加，但j是從addValue*2開始)
        for (int i = 0; i < TexPixelWdith; i++)
        {
            for (int j = addValue * 2; j < TexPixelLength - 1; j++)
            {
                arrayColor[i, j] = Color.blue + value * (j - addValue * 2);
            }
        }

        //=============================================
        //第五步
        //=============================================
        //用於儲存上面計算最後的調色結果
        List<Color> listColor = new List<Color>();
        //放入List，(由上至下，由左至右，RGBR)
        for (int i = TexPixelLength-1; i >=0 ; i--)
        {
            for (int j = 0; j < TexPixelWdith; j++)
            {
                listColor.Add(arrayColor[j, i]);
            }
        }

        //回傳計算結果
        return listColor.ToArray();
    }//Change_CalcArrayColor

    //======================================
    //副程式:讀取arrayColor[,]的顏色代碼
    //======================================
    public Color Read_arrayColor(float ColorNumber)
    {
        return arrayColor[0, (int)ColorNumber];
    }


}//Palette_RGB_Script
