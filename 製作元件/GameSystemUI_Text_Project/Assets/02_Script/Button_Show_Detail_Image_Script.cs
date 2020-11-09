//用於控制Triangle_Detail的真假畫面
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Button_Show_Detail_Image_Script : MonoBehaviour
{
    //Triangle_Detail的畫面
    public GameObject[] Triangle_Detail_Image;
    //Triangle_Detail的畫面數量
    private int Triangle_Detail_Image_Length = 6;
    //Triangle_button的Event Trigger的功能
    public EventTrigger[] trigger ;
    //Triangle_Detail的返回按扭
    public Button Triangle_Detail_Back_Button;
    
    //=============================
    //按下按扭進入Triangle_Detail
    //=============================
    public void Set_Triangle_Detail_Image_Open_GameObject(GameObject Detail_gameObject)
    {
        
        //顯示Triangle_Detail的畫面
        Detail_gameObject.SetActive(true);

        //開啟Triangle_Detail_Back_Button
        Triangle_Detail_Back_Button.interactable = true;

        //將Triangle_button的Event Trigger功能停用
        for (int i = 0; i < Triangle_Detail_Image_Length; i++)
        {
            trigger[i].enabled = false;
        }

    }//Set_Triangle_Detail_Image_Open_GameObject

    //=============================
    //給予按扭使用Set_Triangle_Detail_Image_Close_GameObject
    //=============================
    public void Use_Set_Triangle_Detail_Image_Close_GameObject()
    {
        //1秒後再執行Set_Triangle_Detail_Image_Close_GameObject這個副程式，防止動畫未跑完，新的動畫插入
        Invoke("Set_Triangle_Detail_Image_Close_GameObject", 1);
    }
    //=============================
    //離開按扭離開Triangle_Detail
    //=============================
    void Set_Triangle_Detail_Image_Close_GameObject()
    {

        //停用Triangle_Detail_Back_Button
        Triangle_Detail_Back_Button.interactable = false;

        //隱藏全部Triangle_Detail的畫面
        for (int i=0; i< Triangle_Detail_Image_Length; i++)
        {
            //隱藏全部Triangle_Detail的畫面
            Triangle_Detail_Image[i].SetActive(false);
            //將Triangle_button的Event Trigger功能開啟
            trigger[i].enabled = true;
        }
        
    }//Set_Triangle_Detail_Image_Close_GameObject

}//Button_Show_Detail_Image_Script
