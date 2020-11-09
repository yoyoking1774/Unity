//調色盤腳本，UI元件可依照使用者自訂顏色
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Color_Set_Script : MonoBehaviour
{
    //調色盤
    public Color color;
    //================================
    //以下為要被調色盤控制的UI元件
    //================================

    //Develop_Text
    public Text Develop_Text;


    //================================
    //按扭:UI設定顏色
    //================================
    public void Set_Color()
    {
        Develop_Text.color = color;
    }

}//Color_Set_Script
