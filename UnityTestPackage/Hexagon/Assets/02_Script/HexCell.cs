/*
 * GameObject: HexCell ，每一個網格裡的六邊形。
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//============================================
//每個HexCell都有六個鄰居，我們可以使用6個方向表示它們。
//這些方向為東北，東邊，東南，西南，西邊，西北。
//============================================
/*
 * 列舉 (enum)：也有人稱作為 "狀態機"，因為列舉常常被人拿來當作狀態判斷的使用。enum 所佔的記憶體為 32 位元 (bit)，這是在預設的情況底下，系統預設為 int。
 */
public enum HexDirection
{
    NE, E, SE, SW, W, NW
}

/*
 * Extension Methods: 當我們開發了一些通用的函式特別指那些 public static 的函式在任何地方都有可能被呼叫來使用
 */
public static class HexDirectionExtensions
{
    //獲得反方向的HexCell
    //我們通過為HexDirection創建一個Extension Methods來支持此功能。為了得到相反方向，在原始方向上加3。不過這只對前三個方向(NE, E, SE)起作用，對於其它三個(SW, W, NW)我們需要減3.
    public static HexDirection Opposite(this HexDirection direction)
    {
        return (int)direction < 3 ? (direction + 3) : (direction - 3);
    }

    //由於一個六邊形的每個頂點都由總共三個六邊形共享，所以加入前一個和後一個鄰居的Function。
    //前一個方向
    public static HexDirection Previous(this HexDirection direction)
    {
        return direction == HexDirection.NE ? HexDirection.NW : (direction - 1);
    }

    //後一個方向
    public static HexDirection Next(this HexDirection direction)
    {
        return direction == HexDirection.NW ? HexDirection.NE : (direction + 1);
    }

}

public class HexCell : MonoBehaviour
{
    //============================================
    //宣告變數
    //============================================
    //為了保存這些鄰居，向HexCell中加入一個HexCell[]。
    [SerializeField]
    HexCell[] neighbors;

    //用於儲存HexCell自身座標
    public HexCoordinates coordinates;
 
    //自身顏色
    public Color color;

    
    //============================================
    //Getter
    //============================================
    public HexCell GetNeighbor(HexDirection direction)
    {
        return neighbors[(int)direction];
    }

    //============================================
    //Setter
    //============================================
    public void SetNeighbor(HexDirection direction, HexCell cell)
    {
        //鄰居關係是雙向的。所以在一個方向建立起鄰居時，我們可以立刻將鄰居設為相對方向。
        neighbors[(int)direction] = cell;
        cell.neighbors[(int)direction.Opposite()] = this;
    }


}//HexCell
