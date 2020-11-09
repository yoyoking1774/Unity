/*
 * 網格，網格都會包含多個HexCell，HexCell合起來就是完整的六邊形。
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour
{
    //==============================================
    //宣告變數
    //==============================================
    //網格的寬，也就是HexCell橫排數量
    public int width = 6;

    //網格的高，也就是HexCell直排數量
    public int height = 6;

    //HexCell，用於告知網格每一格要生成HexCell。
    public HexCell cellPrefab;

    //將建立的網格儲存起來
    HexCell[] cells;

    //用於將網格進行動態增減HexCell
    HexMesh hexMesh;

    //HexCell預設顏色
    public Color DefaultColor = Color.white;

    //HexCell碰觸顏色
    public Color TouchedColor = Color.magenta;

    //==============================================
    //宣告UI
    //==============================================
    //Canvas
    Canvas gridCanvas;

    //HexCell的座標文字
    public Text cellLabelPrefab;



    //===================================================
    //初始化
    //===================================================
    void Awake()
    {
        //綁定HexGrid底下的Canvas
        gridCanvas = GetComponentInChildren<Canvas>();

        //綁定HexGrid底下的HexMesh
        hexMesh = GetComponentInChildren<HexMesh>();

        //設定整體HexCell數量
        cells = new HexCell[height * width];

        //給予座標開始建立，由於在3D下X座標、Z座標是平面的，而Y是上下，為了畫面平整只使用X座標、Z座標。
        for (int z = 0, i = 0; z < height; z++){
            for (int x = 0; x < width; x++){
                CreateCell(x, z, i++);
            }
        }
    }

    //===================================================
    //網格初始化後，生成HexCell
    //===================================================
    private void Start()
    {
        //透過hexMesh將全部的HexCell從正方形改為三角形。
        hexMesh.Triangulate(cells);
    }

    /*void Update()
    {
        if (Input.GetMouseButton(0))
        {
            HandleInput();
        }
    }

    //===================================================
    //滑鼠位置向場景發射射線來觸碰一個單元。
    //===================================================
    void HandleInput(){

        //射線
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //儲存射線後產生的碰撞資料。
        RaycastHit hit;

        //射線由inputRay射出，碰到的物件為HIT
        //Raycast(myRay,儲存所碰到物件,射線長度(沒設置無線長),設定忽略物件)
        if (Physics.Raycast(inputRay, out hit)){
            //將射線觸碰位置轉換為六角形坐標
            //distance 從射線起點到射線與碰撞器的交點的距離
            //normal 射線射入平面的法向量
            //point 射線與碰撞器交點的坐標
            TouchCell(hit.point);
        }
    }*/

    //===================================================
    //副程式:使用者碰觸HexCell，將射線觸碰位置轉換為六角形坐標，並改變顏色。
    //===================================================
    public void ColorCell(Vector3 position , Color color)
    {
        //將position從世界坐標到局部坐標。和Transform.TransformPoint相反。
        position = transform.InverseTransformPoint(position);
        //轉換為六角形坐標。
        HexCoordinates coordinates = HexCoordinates.FromPosition(position);
        //訊息顯示，碰觸HexCell的座標。
        Debug.Log("touched at " + coordinates.ToString());
        //首先將HexCell坐標轉換為符合的索引。對於一個正方形網格就是X加Z乘以寬度，但是在我們的情況中我們還需要加入半-Z偏移量。
        int index = coordinates.X + (coordinates.Z * width) + (coordinates.Z / 2);
        //得到HexCell。
        HexCell cell = cells[index];
        //改變HexCell的顏色。
        cell.color = color;
        //然後再一次三角化網格物體。
        hexMesh.Triangulate(cells);
    }

    //===================================================
    //副程式:建立網格
    //===================================================
    void CreateCell(int x, int z, int i){
        //依照傳進來的座標，設定HexCell座標
        Vector3 position;
        //每一橫排的六邊形不是在下一橫排的正上方。每一行沿著X方向都有一個內徑大小的偏移。我們可以在乘以兩倍內徑之前加上Z到X距離的一半，但為了保持方形操作，在做乘法之前先減去Z除以2的商。
        position.x = (x + (z * 0.5f) - (z / 2) ) * (HexMetrics.innerRadius * 2f);
        //未使用Y座標，設為0(單位)
        position.y = 0f;
        //每個HexCell距離下一橫排的距離為外徑的1.5倍
        position.z = z * (HexMetrics.outerRadius * 1.5f);

        //設定每一個HexCell初始化
        HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
        //新生成的HexCell放在HexGrid底下，為子物件
        cell.transform.SetParent(transform, false);
        //設定HexCell座標
        cell.transform.localPosition = position;
        //儲存轉換後的六角形座標
        cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);
        //設定成預設顏色
        cell.color = DefaultColor;


        //因為每個HexCell都會在設定西邊、西南、東南邊的HexCell後，同時變成對方東邊、東北、西北邊的HexCell，所以不需要在設定自身東邊、東北、西北邊的HexCell。
        //每一橫排的第一個單元沒有東邊的鄰居。但是橫排的其他單元都有。
        if (x > 0){
            cell.SetNeighbor(HexDirection.W, cells[i - 1]);
        }

        //我們有另外兩個雙向的連接可以完成。由於它們在不同行之間，我們只能連接之前的行。這意味著我們需要跳過整個第一行。
        //換行處應該被區別對待。我們首先處理。由於這些行中所有的單元都有東南方向的鄰居，我們可以將它們連到那裡。
        if (z > 0){
            //偶數橫排
            if ((z & 1) == 0)
            {
                //設定東南邊的HexCell
                cell.SetNeighbor(HexDirection.SE, cells[i - width]);

                //除每橫排中的第一個單元之外都有西南HexCell。
                if (x > 0)
                {
                    cell.SetNeighbor(HexDirection.SW, cells[i - width - 1]);
                }
            }
            //奇數橫排
            else
            {
                //設定西南邊的HexCell
                cell.SetNeighbor(HexDirection.SW, cells[i - width]);

                //除每橫排中的最後一個個單元之外都有東南HexCell。
                if (x < width - 1)
                {
                    cell.SetNeighbor(HexDirection.SE, cells[i - width + 1]);
                }
            }
        }

        //設定HexCell座標Text
        Text label = Instantiate<Text>(cellLabelPrefab);
        //新生成的label放在gridCanvas底下，為子物件
        label.rectTransform.SetParent(gridCanvas.transform, false);
        //設定label座標
        label.rectTransform.anchoredPosition = new Vector2(position.x, position.z);
        //將label的Text設定為HexCell座標
        label.text = cell.coordinates.ToStringOnSeparateLines();
    }




}//HexGrid
