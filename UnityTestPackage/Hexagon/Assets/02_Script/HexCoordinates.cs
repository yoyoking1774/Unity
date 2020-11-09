/*
 * 讓我們在六邊形網格存在的情況下再看看我們的單元坐標。 Z坐標還好，但是X坐標呈鋸齒狀分佈。HexCoordinates用於覆蓋一個方形區域從而對行進行偏移帶來的副作用。
 * 
 * HexCoordinates使用它來轉換成不同的坐標系統。將它設置為可序列化這樣Unity可以儲存它。另外，通過使用唯讀屬性使這些坐標不能被改變。
 * 
 * 將三個坐標X、Y、Z加總會得到0。
 * 如果一個坐標增加了，必須要減少一個坐標。
 * 這會產生六個可能的運動方向。這些坐標被稱為立方體坐標，因為它們是三維的且形成的拓撲類似一個立方體。
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct HexCoordinates
{
    //======================================================
    //宣告屬性
    //======================================================
    //SerializeField為了能讓X、Y、Z座標三者能顯示在Inspector上。
    [SerializeField]
    //X座標、Z座標
    private int x, z;

    //Y座標
    //由於X和Y維度彼此對稱，如果保持Z不變，將它們坐標相加總會產生相同的結果。
    //因為我們已經存儲了X和Z坐標，所以不需要存儲Y坐標了。我們可以包含一個變數用來在需要的時候計算它，然後在副程式中使用它。
    public int Y{
        get{return -X - Z;}
    }

    //X座標
    public int X{
        get{ return x;}
    }

    //Z座標
    public int Z{
        get{return z;}
    }


    //======================================================
    //建構子(有參數)
    //======================================================
    public HexCoordinates(int x, int z){
        this.x = x;
        this.z = z;
    }

    //======================================================
    //靜態副程式: 用於儲存偏移坐標的坐標集。現在只需一個個複製這些坐標。
    //修正那些X坐標讓它們沿直線排開。這樣可以取消水平調整。結果得到了軸坐標。
    //======================================================
    public static HexCoordinates FromOffsetCoordinates(int x, int z){
        return new HexCoordinates(x - (z / 2) , z);
        //這是原本尚未修正偏移的座標。
        //return new HexCoordinates(x, z);
    }

    //======================================================
    //靜態副程式: 用於HexFrid的副程式TouchCell，計算觸碰位置轉換為六角形坐標。
    //======================================================
    public static HexCoordinates FromPosition(Vector3 position){

        //首先將x除以六邊形的水平寬。因為Y坐標與X坐標相對，x的負數就是y。
        float x = position.x / (HexMetrics.innerRadius * 2f);
        float y = -x;

        //但是只有Z為0的時候我們會得到正確的坐標。
        //沿著Z運動我們需要再一次偏移。每隔兩行需要向左偏移一整個單位。
        float offset = position.z / (HexMetrics.outerRadius * 3f);
        x -= offset;
        y -= offset;

        //Mathf.RoundToInt 四捨五入到整數
        //iX和iY為整數，代表每個HexCell的中央座標。
        int iX = Mathf.RoundToInt(x);
        int iY = Mathf.RoundToInt(y);
        //由於iX + iY + iZ == 0，所以推導出IZ。
        int iZ = Mathf.RoundToInt(-x - y);

        //但上面計算的iX + iY + iZ 並不一定為0，問題出現在靠近六邊形相鄰邊的位置。所以是對坐標的取整數導致了問題。
        if (iX + iY + iZ != 0){
            //一個HexCell的中心距離越遠，取整數的幅度越大。所以應該假設取整幅度最大的坐標是錯誤的。
            float dX = Mathf.Abs(x - iX);
            float dY = Mathf.Abs(y - iY);
            float dZ = Mathf.Abs(-x - y - iZ);

            //解法就變成了要摒棄取整幅度最大的坐標，然後從另外兩個重新計算它。但是由於我們只需要X和Z，我們不需要重建Y。
            if (dX > dY && dX > dZ) {
                iX = -iY - iZ;
            }
            else if (dZ > dY) {
                iZ = -iX - iY;
            }
        }// if (iX + iY + iZ != 0)

        return new HexCoordinates(iX, iZ);
    }

    //======================================================
    //副程式: 回傳六角形坐標到畫面上。
    //======================================================
    public override string ToString(){
        return "(" +X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + ")";
    }

    //======================================================
    //副程式(有換行): 回傳六角形坐標到畫面上。
    //======================================================
    public string ToStringOnSeparateLines(){
        return X.ToString() + "\n" + Y.ToString() + "\n" + Z.ToString();
    }



}//HexCoordinates
