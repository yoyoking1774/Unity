/*
 * MVC: View腳本
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View_Script : MonoBehaviour
{
    //==========================================
    //宣告變數
    //==========================================

    //音效腳本:Sounds_Script
    public Sounds_Script sounds;

    //現在回合:Round_Script
    public Round_Script round_Script;


    //======================================
    //副程式:變更圈或叉
    //======================================
    public void Tic_Change(bool Tic_Sprite)
    {
        //改變現在回合UI，如果是true就變圈，如果是false就變叉。 
        round_Script.Round_Change_Sprite(Tic_Sprite);

        //播放Slot按下音效
        sounds.Play_Slot_Push();
    }

}//View_Script
