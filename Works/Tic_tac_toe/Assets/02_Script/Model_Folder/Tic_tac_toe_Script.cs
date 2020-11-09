/*
 * Tic_tac_toe整體相關變數
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tic_tac_toe_Script : MonoBehaviour
{

    //======================================
    //宣告變數
    //======================================

    //決定是要放哪一個Sprite 圈或叉，true:圈 false:叉，初始為圈
    private bool Tic_Sprite = true;

    //達成連線的數量
    private  int Line_Number = 3;

    //Round_Script
    //public Round_Script round_Script;


    //======================================
    //建構子(無參數)
    //======================================
    public Tic_tac_toe_Script() {
        Tic_Sprite = true;

        Line_Number = 3;
    }

    //======================================
    //初始化
    //======================================
    private void Awake()
    {
        Tic_Sprite = true;

        Line_Number = 3;
    }


    //================================================================================================
    //Setter
    //================================================================================================

    //Tic_Sprite
    public void Set_Tic_Sprite(bool Tic_bool) {
        Tic_Sprite = Tic_bool;
    }

    //Line_Number
    public void Set_Line_Number(int Line_Number)
    {
        this.Line_Number = Line_Number;
    }

    //================================================================================================
    //Getter
    //================================================================================================

    //Tic_Sprite
    public bool Get_Tic_Sprite()
    {
       return Tic_Sprite;
    }

    //Line_Number
    public int Get_Line_Number()
    {
        return Line_Number;
    }


    //================================================================================================
    //外部使用
    //================================================================================================
/*
    //======================================
    //副程式:變更圈或叉
    //======================================
    public void Tic_Change() {
        //如果是true就變false，如果是false就變true。
        Tic_Sprite = !Tic_Sprite;

        //改變現在回合UI
        round_Script.Round_Change_Sprite(Tic_Sprite);
    }
    */


}//Tic_tac_toe_Script
