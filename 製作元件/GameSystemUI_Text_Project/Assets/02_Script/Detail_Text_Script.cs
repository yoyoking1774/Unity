//Detail_Tex腳本
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Detail_Text_Script : MonoBehaviour
{
    //=====================
    //變數
    //=====================
    //用於設定Detail_Text_Animator的動畫，true:進入 false:離開
    private bool Animation_In_Out_Bool = false;
    //用於設定Detail_Text的Text刷新動畫， true:刷新 false:不刷新
    //Detail_Text_Script的Animator
    private Animator Detail_Text_Animator;

    //Detail_Text_Script的UI元件
    //技能名稱
    public Text Detail_Name_Text;
    //技能描述
    public Text Detail_Describe_Text;
    //技能能力
    public Text Detail_Ability_Text;
    //技能要求
    public Text Detail_Request_Text;


    //=====================
    //Awake
    //=====================
    private void Awake()
    {
        //綁定Detail_Text_Script上的Animator
        Detail_Text_Animator = GetComponent<Animator>();
    }

    //=====================
    //進入:Detail_Text的畫面
    //=====================
    public void Button_Entry_Detail_Text()
    {
        //設定為true，表示進入Detail_Text
        Animation_In_Out_Bool = true;
        //將Animator上的Animation_In_Out_Bool狀態改為true，並播放Detail_Text_In_Animation
        Detail_Text_Animator.SetBool("Animation_In_Out_Bool" , Animation_In_Out_Bool);
    }

    //=====================
    //離開:Detail_Text的畫面
    //=====================
    public void Button_Exit_Detail_Text()
    {
        //false，表示離開Detail_Text
        Animation_In_Out_Bool = false;
        //將Animator上的Animation_In_Out_Bool狀態改為false，並播放Detail_Text_Out_Animation
        Detail_Text_Animator.SetBool("Animation_In_Out_Bool", Animation_In_Out_Bool);
    }

    //=====================
    //動畫:刷新Detail_Text
    //=====================
    public void Play_Detail_Text_Refresh_Animation()
    {
        //將Animator上的Detail_Text_Refresh_Trigger開啟，並播放Detail_Text_Refresh_Animation
        Detail_Text_Animator.SetTrigger("Detail_Text_Refresh_Trigger");
    }

    //=====================
    //設定Text:技能名稱
    //=====================
    public void Set_Detail_Name_Text(string Input_Text)
    {
        Detail_Name_Text.text = "" + Input_Text;
    }

    //=====================
    //設定Text:技能描述 
    //=====================
    public void Set_Detail_Describe_Text(string Input_Text)
    {
        Detail_Describe_Text.text = "" + Input_Text;
    }

    //=====================
    //設定Text:技能能力
    //=====================
    public void Set_Detail_Ability_Text(string Input_Text)
    {
        Detail_Ability_Text.text = "" + Input_Text;
    }

    //=====================
    //設定Text:技能要求
    //=====================
    public void Set_Detail_Request_Text(string Input_Text)
    {
        Detail_Request_Text.text = "" + Input_Text;
    }
}//Detail_Text_Script
