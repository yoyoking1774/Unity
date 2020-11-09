//類別:角色
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    //===========================
    //宣告屬性***********************************************
    //===========================
    private float RunSpeed;
    private float JumpHeight;
    private float Hp;

    //===========================
    //建構子*************************************************
    //===========================
    public Player_Script()
    {
        RunSpeed = 5.0f;
        JumpHeight = 250.0f;
        Hp = 3.0f;
    }

    //===========================
    //宣告方法**************************************************
    //===========================

    //===========================
    //設定、獲得RunSpeed
    //===========================
    public float SetGet_RunSpeed
    {
        get
        {
            return RunSpeed;
        }

        set
        {
            RunSpeed = value;
        }
    }

    //===========================
    //設定、獲得JumpHeught
    //===========================
    public float SetGet_JumpHeight
    {
        get
        {
            return JumpHeight;
        }

        set
        {
            JumpHeight = value;
        }
    }

    //===========================
    //設定、獲得Hp
    //===========================
    public float SetGet_Hp
    {
        get
        {
            return Hp;
        }

        set
        {
            Hp = value;
        }
    }


}//Player_Script
