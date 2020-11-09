/*
 * 遊戲回合相關UI 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Round_Script : MonoBehaviour
{

    //======================================
    //宣告變數
    //======================================

    //======================================
    //宣告UI
    //======================================
    //sprite:圈
    public Sprite Circle_Sprite;

    //sprite:叉
    public Sprite Cancel_Sprite;

    //抓取Round底下的Sprite
    private SpriteRenderer Round_render;


    //======================================
    //宣告動畫
    //======================================
    public Animation round_sprite_Animation;

    private void Awake()
    {
        //綁定Round下一層子物件的sprite。
        Round_render = transform.GetChild(0).GetComponent<SpriteRenderer>();
 
    }


    //===========================================
    //副程式:改變sprite成 圈或叉
    //===========================================
    public void Round_Change_Sprite(bool sprite_bool) {
        //依照現在回合，將Round_render.sprite改變成圈或叉。
        if (sprite_bool == true) Round_render.sprite = Circle_Sprite;
        else Round_render.sprite = Cancel_Sprite;

        //播放round_sprite_Animation
        round_sprite_Animation.Play();
    }



}//Round_Script
