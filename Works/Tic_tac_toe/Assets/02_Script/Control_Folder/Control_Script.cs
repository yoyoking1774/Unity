/*
 * MVC: Control腳本
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Script : MonoBehaviour
{
    //==========================================
    //宣告變數
    //==========================================

    //用於通知View
    public View_Script view;



    //================================================================================================
    //外部使用
    //================================================================================================

    //=====================================
    //Control通知View修改Tic
    //=====================================
    public void Control_To_View_Tic_Change(bool Tic_Sprite)
    {
        view.Tic_Change(Tic_Sprite);
    }


}//Control_Script
