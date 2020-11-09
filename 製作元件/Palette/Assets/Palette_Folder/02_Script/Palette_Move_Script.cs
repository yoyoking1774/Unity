//可以使用滑鼠拖拉圓點，改變顏色
/*
 調色盤大小 256 X 256

 左上座標
 (調色盤中心位置-128 , 調色盤中心位置+128)

 左下座標
 (調色盤中心位置-128 , 調色盤中心位置-128)

 右上座標
 (調色盤中心位置+128 , 調色盤中心位置+128)

 右下座標
 (調色盤中心位置+128 , 調色盤中心位置-128)
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Palette_Move_Script : MonoBehaviour
{
    //====================================================
    //宣告變數
    //====================================================
    //圓點
    public RectTransform Color_Point;
    //圓點位置
    public Vector2 Point_prePos;

    //Canvas
    public RectTransform Canvas_Rect;
    //Canvas寬
    private float Canvas_Width;
    //Canvas高
    private float Canvas_Height;

    //調色盤
    public RectTransform Palette;
   

    //離中心的最大距離
    private float Max_Distance ;

    //====================================================
    // Start is called before the first frame update
    //====================================================
    void Start()
    {
       
        //由於UI上的是相對位置，需依照Canvas的長寬來計算UI實際的位置
        Canvas_Width = Canvas_Rect.rect.width;
        Canvas_Height = Canvas_Rect.rect.height;

        //圓點初始值，由於是以世界位置來計算，所以UI(0,0)的位置為Canvas得寬和高的一半
        Point_prePos = new Vector2(Canvas_Width / 2, Canvas_Height / 2);

        //依照調色盤的大小，計算離中心的最大距離
        Max_Distance = Palette.rect.width / 2;

    }

    
    //====================================================
    //副程式:抓取滑鼠按下時的座標
    //====================================================
    void OnMouseDown()
    {
        Point_prePos = Input.mousePosition;
        
    }//OnMouseDown

    //====================================================
    //副程式:計算拖曳位置，並改變視窗位置
    //====================================================
    void OnMouseDrag()
    {
        //抓取panel上的RectTransform
        RectTransform rect = GetComponent<RectTransform>();

        //如果沒有超出範圍，則設定新的圓點位置
        if (Check_Position())
        {
            //計算移動後的位置，新的位置 - 上面滑鼠按下時的位置
            rect.anchoredPosition = rect.anchoredPosition + ((Vector2)Input.mousePosition - (Vector2)Point_prePos);
            //將舊座標設為移動後的座標
            Point_prePos = Input.mousePosition;
        }
       
    }//OnMouseDrag

    //====================================================
    //副程式:判斷圓點是否超過範圍
    //====================================================
    private bool Check_Position() {
        //依照Canvas的大小來設定在UI上實際的位置(除以2是因為UI的中心點在Canvas的寬和高的一半)
        float Distance_x = Input.mousePosition.x - (Canvas_Width / 2);
        //依照Canvas的大小來設定在UI上實際的位置(除以2是因為UI的中心點在Canvas的寬和高的一半)
        float Distance_y = Input.mousePosition.y - (Canvas_Height / 2);

        //左上
        if (Distance_x < -Max_Distance || Distance_y > Max_Distance) return false;
        //左下
        else if (Distance_x < -Max_Distance || Distance_y < -Max_Distance) return false;
        //右上
        else if (Distance_x > Max_Distance || Distance_y > Max_Distance) return false;
        //右下
        else if (Distance_x > Max_Distance || Distance_y < -Max_Distance) return false;

        return true;
    }

    //====================================================
    //副程式:回傳圓點位置
    //====================================================
    public Vector2 Read_Point_Vector() {
        //調色盤的座標，會加上Max_Distance是因為調色盤左下為啟始點(0,0)，而非中間所以要加回去
        float Distance_x = Point_prePos.x - (Canvas_Width / 2) + Max_Distance;
        //調色盤的座標，會加上Max_Distance是因為調色盤左下為啟始點(0,0)，而非中間所以要加回去
        float Distance_y = Point_prePos.y - (Canvas_Height / 2) + Max_Distance;

        return new Vector2(Distance_x , Distance_y);
    }

    
}//Palette_Move_Script
