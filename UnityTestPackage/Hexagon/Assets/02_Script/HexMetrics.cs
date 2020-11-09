/*
 * class: HexMetrics
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMetrics : MonoBehaviour
{
    //==============================================
    //宣告屬性
    //==============================================
    //外部半徑，預設為10(單位)。
    public const float outerRadius = 10f;

    //內部半徑，預設為 外部半徑 * (√3 / 2)，√3 = 1.73205080757。
    public const float innerRadius = outerRadius * 0.866025404f;

    //純色區域比例
    public const float solidFactor = 0.75f;

    //邊界混色區域比例
    public const float blendFactor = 1f - solidFactor;

    static Vector3[] corners = {
        //以下6個角為六角形，相對於中心的距離。
        new Vector3(0f, 0f, outerRadius),
        new Vector3(innerRadius, 0f, 0.5f * outerRadius),
        new Vector3(innerRadius, 0f, -0.5f * outerRadius),
        new Vector3(0f, 0f, -outerRadius),
        new Vector3(-innerRadius, 0f, -0.5f * outerRadius),
        new Vector3(-innerRadius, 0f, 0.5f * outerRadius),
        //下面這第7個角，是HexMesh在轉換HexCell時，最後一個三角形試圖找到不存在的第七個角。當然它應該返回來使用第一個角作為它最後的頂點，用於解決HexMesh的AddTriangle的問題。
        new Vector3(0f, 0f, outerRadius)
    };


    //==============================================
    //Getter
    //==============================================
    //取得某一個方向的第一個頂點
    public static Vector3 GetFirstCorner(HexDirection direction)
    {
        return corners[(int)direction];
    }

    //取得某一個方向的第二個頂點
    public static Vector3 GetSecondCorner(HexDirection direction)
    {
        return corners[(int)direction + 1];
    }

    //取得某一個方向的第一個頂點的顏色
    public static Vector3 GetFirstSolidCorner(HexDirection direction)
    {
        return corners[(int)direction] * solidFactor;
    }

    //取得某一個方向的第二個頂點的顏色
    public static Vector3 GetSecondSolidCorner(HexDirection direction)
    {
        return corners[(int)direction + 1] * solidFactor;
    }

    //
    //我們可以通過從v1和v2開始找到v3和v4的新位置，然後沿著橋移動，一直到單元的邊。那麼這個橋的偏移量為多少？你可以取兩個相關角的中點，然後對它使用混合因子來得到偏移量。
    /*
    *     V3-------V4
    *      V1-----V2
    *         ---
    *          -
    *        center
    */
    //
    public static Vector3 GetBridge(HexDirection direction)
    {
        return (corners[(int)direction] + corners[(int)direction + 1]) *
            blendFactor;
    }

}
