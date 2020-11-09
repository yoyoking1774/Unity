/*
 * HexCell顏色編輯器，附著於HexMapEditor
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HexMapEditor : MonoBehaviour
{

    //============================================
    //宣告變數
    //============================================
    
    //自訂顏色
    public Color[] colors;

    //要著色的網格
    public HexGrid hexGrid;

    //現在選擇的顏色
    private Color ActiveColor;


    //============================================
    //初始化
    //============================================
    private void Awake()
    {
        //滑鼠預設顏色
        SelectColor(0);
    }

    //============================================
    // Update is called once per frame
    //============================================
    void Update()
    {
        //如果按下左鍵
        //HexMapEditor覆蓋HexGrid。當選擇一個新顏色時，在UI下面的單元也會被著色。所以我們和兩個UI、兩個六邊形都在互動，這不是需要的。
        //EventSystem檢測到滑鼠在某對像上來修正這個問題。由於它只知道UI對象，這意味著我們正和UI互動。所以只有當此情況沒發生的時候我們才需手動處理輸入。
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject()) {
            //滑鼠位置向場景發射射線來觸碰一個單元。
            HandleInput();
        }
    }

    //===================================================
    //滑鼠位置向場景發射射線來觸碰一個單元。
    //===================================================
    void HandleInput() {
        //射線，從畫面上的滑鼠世界座標發射
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //儲存射線後產生的碰撞資料。
        RaycastHit hit;

        //射線由inputRay射出，碰到的物件為hit
        //Raycast(myRay,儲存所碰到物件,射線長度(沒設置無線長),設定忽略物件)
        if (Physics.Raycast(inputRay, out hit)) {
            //將射線觸碰位置轉換為六角形坐標
            //hit.distance 從射線起點到射線與碰撞器的交點的距離
            //hit.normal 射線射入平面的法向量
            //hit.point 射線與碰撞器交點的坐標
            hexGrid.ColorCell(hit.point, ActiveColor);
        }
    }

    //===================================================
    //副程式:設定滑鼠按下時的顏色，附著於CplorPanel底下的Toggle
    //===================================================
    public void SelectColor(int index) {
        ActiveColor = colors[index];
    }  

}
