//不規則圖型按扭，限定只能在圖案內才能觸發按扭
/*
 在平時的遊戲和平面程序開發中，難免會遇到需要使用不規則按鈕的需求，而Unity3d中使用UGUI的按鈕控件只能實現規則的長方形按鈕。
 *注: 使用alphaHitTestMinimumThreshold屬性需要開啟sprite 的Read/Write Enbale屬性(button的Image)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageButton : MonoBehaviour
{
    //public Text text;
    //private int count;

    void Awake()
    {
        // 設定透明度，當滑鼠在透明度 < 0.1的圖案時，則按扭不能按下。
        Image image = GetComponent<Image>();
        image.alphaHitTestMinimumThreshold = 0.1f;

        
    }

   /* public void OnButtonClicked()
    {
        //count++;
        //text.text = "第" + count + "次按下按钮";
        //print("a");
    }
    */

}
