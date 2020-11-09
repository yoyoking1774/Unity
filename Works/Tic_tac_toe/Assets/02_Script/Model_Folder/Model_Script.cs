/*
 * MVC: Model腳本
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_Script : MonoBehaviour
{
    //==========================================
    //宣告變數
    //==========================================

    //Tic_tac_toe整體相關變數，九個slot統一使用，外部的Script下的Tic_tac_toe_Script上的Tic_tac_toe_Script
    public Tic_tac_toe_Script Tic;

    //用於通知control
    public Control_Script control;


    //================================================================================================
    //外部使用
    //================================================================================================

    //=====================================
    //通知Control修改View
    //=====================================
    public void Model_To_Control_Tic_Change(bool Tic_Sprite) {

        //因為已經決定位置，進行下一回合，Sprite改變為另一邊的Spirte，圈變叉，叉變圈。
        Tic.Set_Tic_Sprite(!Tic_Sprite);

        //通知Control修改View
        control.Control_To_View_Tic_Change(!Tic_Sprite);
    }


}//Model_Script
