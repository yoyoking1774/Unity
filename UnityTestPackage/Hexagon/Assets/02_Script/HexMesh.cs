/*
 * HexMesh管理網格底下的HexCell。
 * 它需要一個網格物體過濾器(MeshFilter)和一個渲染器(MeshRenderer)，需要有一個網格物體，以及需要有網格物體頂點和三角的List。
 * 由於不知道原本需要的網格大小，所以使用List來動態增減。
 * 並將HexCell從正方形改變為三角形。
 * 
 * 一個3D物件的呈現，主要由 Mesh 與 Material 兩個部分。
 * Mesh 是作為Hexcell(Object)”外型”的基本框架。
 * MeshFilter 用來儲存Mesh的相關資料。
 * Renderer   用來設定一個或數個的 Material，讓實際繪製物件時，可以呈現不同的樣貌或效果。
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexMesh : MonoBehaviour
{
    //用於設定，從HexFrid傳進來的Hexcell。
    Mesh hexMesh;

    //儲存每個Hexcell的座標。
    List<Vector3> vertices;

    //儲存每個Hexcell的編號。
    List<int> triangles;

    //用於接收HexGrid的射線。
    MeshCollider meshCollider;

    //儲存HexCell設定的顏色。
    List<Color> colors;

    void Awake()
    {
        //綁定HexMesh底下的MeshFilter
        GetComponent<MeshFilter>().mesh = hexMesh = new Mesh();
        hexMesh.name = "Hex Mesh";

        //向HexMesh加入一個MeshCollider。
        meshCollider = gameObject.AddComponent<MeshCollider>();

        //生成一個List，儲存每個Hexcell的座標。
        vertices = new List<Vector3>();

        //生成一個List，儲存每個Hexcell的顏色。
        colors = new List<Color>();

        //生成一個List，儲存每個Hexcell的編號。
        triangles = new List<int>();
    }


    //==========================================================
    //副程式(多個HexCell):將全部的HexCell從正方形改為三角形。
    //==========================================================
    public void Triangulate(HexCell[] cells)
    {
        //進行清空，防止舊資料遺留。
        hexMesh.Clear();
        //進行清空，防止舊資料遺留。
        vertices.Clear();
        //進行清空，防止舊資料遺留。
        triangles.Clear();
        //進行清空，防止舊資料遺留。
        colors.Clear();

        //將HexCell一個個轉變為三角形。
        for (int i = 0; i < cells.Length; i++)
        {
            Triangulate(cells[i]);
        }

        //=========================
        //全部的HexCell轉換完畢。
        //=========================
        //將List儲存的座標轉為陣列，儲存到hexMesh。
        hexMesh.vertices = vertices.ToArray();
        //將List儲存的編號轉為陣列，儲存到hexMesh。
        hexMesh.triangles = triangles.ToArray();
        ////將List儲存的編號轉為陣列，儲存到hexMesh。
        hexMesh.colors = colors.ToArray();
        //重新計算從三角形和頂點重新計算網格的法線。
        hexMesh.RecalculateNormals();

        //完成三角化之後將我們的HexCell設置碰撞器。
        meshCollider.sharedMesh = hexMesh;
    }

    //==========================================================
    //副程式(單一HexCell):將單一HexCell從正方形改為三角形。
    //==========================================================
    /*void Triangulate(HexCell cell)
    {
        //儲存原本的座標。
        Vector3 center = cell.transform.localPosition;

        //依照HexMetrics設定的座標，將正方形的HexCell的座標，改為三角形的頂點座標，從第一個三角開始。它的第一個頂點是六邊形的中心。另外兩個頂點是相對於中心的兩個頂點。
        //循環6個三角形成一個六角形
        for (int i = 0; i < 6; i++)
        {
            AddTriangle(
                center,
                center + HexMetrics.corners[i],
                center + HexMetrics.corners[i + 1]
            );
            AddTriangleColor(cell.color);
        }
    }
    */

    //==========================================================
    //副程式(單一HexCell):將單一HexCell從正方形改為三角形，由於我們現在有方向了，讓我們使用它代替數字索引來區分不同的部分。。
    //==========================================================
    void Triangulate(HexCell cell)
    {
        for (HexDirection d = HexDirection.NE; d <= HexDirection.NW; d++)
        {
            Triangulate(d, cell);
        }
    }

    //==========================================================
    //副程式(單一HexCell):將單一HexCell從正方形改為三角形，由於我們使用方向，如果我們可以通過方向來得到角就好了，省得再轉換為索引。
    //==========================================================
    void Triangulate(HexDirection direction, HexCell cell)
    {
        Vector3 center = cell.transform.localPosition;
        Vector3 v1 = center + HexMetrics.GetFirstSolidCorner(direction);
        Vector3 v2 = center + HexMetrics.GetSecondSolidCorner(direction);

        AddTriangle(center, v1, v2);
        AddTriangleColor(cell.color , cell.color , cell.color);

        //處理東北連接時添加一個橋。
        if (direction == HexDirection.NE)
        {
            TriangulateConnection(direction, cell, v1, v2);
        }

        //只需在前三個方向（東北，東邊，東南）三角化它們。
        if (direction <= HexDirection.SE)
        {
            TriangulateConnection(direction, cell, v1, v2);
        }

        //首先對HexCell自身另外兩個頂點使用鄰居的顏色。
        //?? cell是用於因為我們的邊界單元沒有六個鄰居，使用單元自身作為替代物。
        //a??b是a!= null ? a：b的簡寫。
        /*HexCell prevNeighbor = cell.GetNeighbor(direction.Previous()) ?? cell;
        HexCell neighbor = cell.GetNeighbor(direction) ?? cell;
        HexCell nextNeighbor = cell.GetNeighbor(direction.Next()) ?? cell;
        //六邊形邊上的顏色應該是相鄰單元的平均值。
        Color edgeColor = (cell.color + neighbor.color) * 0.5f;
        //三個鄰居，進行兩種三色混合。
        AddTriangleColor(
            cell.color,
            (cell.color + prevNeighbor.color + neighbor.color) / 3f,
            (cell.color + neighbor.color + nextNeighbor.color) / 3f
        );
        */
        /* Color bridgeColor = (cell.color + neighbor.color) * 0.5f;
        AddQuadColor(cell.color, bridgeColor);

        AddTriangle(v1, center + HexMetrics.GetFirstCorner(direction), v3);
        AddTriangleColor(
            cell.color,
            (cell.color + prevNeighbor.color + neighbor.color) / 3f,
            bridgeColor
        );

        AddTriangle(v2, v4, center + HexMetrics.GetSecondCorner(direction));
        AddTriangleColor(
            cell.color,
            bridgeColor,
            (cell.color + neighbor.color + nextNeighbor.color) / 3f
        );*/

    }

    //==========================================================
    //副程式:處理邊緣三角和顏色混合的代碼。
    //==========================================================
    void TriangulateConnection(HexDirection direction, HexCell cell, Vector3 v1, Vector3 v2)
    {
        HexCell neighbor = cell.GetNeighbor(direction);
        //不再使用單元本身代替不存在的鄰居。
        if (neighbor == null)
        {
            return;
        }

        //處理邊緣三角和顏色混合的代碼。
        Vector3 bridge = HexMetrics.GetBridge(direction);
        Vector3 v3 = v1 + bridge;
        Vector3 v4 = v2 + bridge;

        AddQuad(v1, v2, v3, v4);
        AddQuadColor(cell.color, neighbor.color);

        //填充那些連接下一個鄰居的三角形。
        //由於三個單元共享同一個三角形連接，我們只需要添加兩個連接。所以只需東北和東邊就可以了。
        HexCell nextNeighbor = cell.GetNeighbor(direction.Next());
        if (direction <= HexDirection.E && nextNeighbor != null)
        {
            AddTriangle(v2, v4, v2 + HexMetrics.GetBridge(direction.Next()));
            AddTriangleColor(cell.color, neighbor.color, nextNeighbor.color);
        }

    }

    //==========================================================
    //副程式:將轉換完成的HexCell的3個頂點座標儲存。
    //==========================================================
    void AddTriangle(Vector3 v1, Vector3 v2, Vector3 v3)
    {
        //取得有多少現在有多少三角形頂點。
        int vertexIndex = vertices.Count;

        //儲存三角形3個頂點座標。
        vertices.Add(v1);
        vertices.Add(v2);
        vertices.Add(v3);

        //儲存三角形3個頂點編號。
        triangles.Add(vertexIndex);
        triangles.Add(vertexIndex + 1);
        triangles.Add(vertexIndex + 2);
    }

    //==========================================================
    //副程式:將轉換完成的HexCell的3個頂點的顏色儲存，每個頂點一種顏色。
    //==========================================================
    void AddTriangleColor(Color c1, Color c2, Color c3)
    {
        colors.Add(c1);
        colors.Add(c2);
        colors.Add(c3);
    }

    //==========================================================
    //副程式:縮小三角形來填充空白區域。
    /*
     *     V3-------V4
     *      V1-----V2
     *         ---
     *          -
     *        center
     */
    //==========================================================
    void AddQuad(Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4)
    {
        int vertexIndex = vertices.Count;

        //四個頂點
        vertices.Add(v1);
        vertices.Add(v2);
        vertices.Add(v3);
        vertices.Add(v4);

        //加入List
        triangles.Add(vertexIndex);
        triangles.Add(vertexIndex + 2);
        triangles.Add(vertexIndex + 1);
        triangles.Add(vertexIndex + 1);
        triangles.Add(vertexIndex + 2);
        triangles.Add(vertexIndex + 3);
    }

    //==========================================================
    //副程式:填充空白區域的顏色。
    //==========================================================
    void AddQuadColor(Color c1, Color c2)
    {
        colors.Add(c1);
        colors.Add(c1);
        colors.Add(c2);
        colors.Add(c2);
    }

}//HexMesh
