//控制Button的EventTrigger控制腳本
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Event_Trigger_Script : MonoBehaviour
{



    //==========================
    //進入:控制背景透明度
    //==========================
    public void Set_Panel_Alpha_In(Image image)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.5f); 
        //print("In");
    }


    //==========================
    //離開:控制背景透明度
    //==========================
    public void Set_Panel_Alpha_Out(Image image)
    {
         image.color = new Color(image.color.r, image.color.g, image.color.b, 1.0f);
        //print("Out");
    }

    //==========================
    //進入:控制背景透明度(動畫)
    //==========================
    public void Set_Panel_Alpha_In_Animation(Animation Panel_Animation)
    {
        Panel_Animation.Play("Bg_Panel_In_Animation");
    }


    //==========================
    //離開:控制背景透明度(動畫)
    //==========================
    public void Set_Panel_Alpha_Out_Animation(Animation Panel_Animation)
    {

        Panel_Animation.Play("Bg_Panel_Out_Animation");
    }

    //==========================
    //進入:放大按扭
    //==========================
    public void Set_Button_Point_In_Size(GameObject button_gameObject) {
        button_gameObject.transform.localScale = new Vector3(1.2f, 1.2f , button_gameObject.transform.localScale.z);
    }

    //==========================
    //離開:縮小按扭
    //==========================
    public void Set_Button_Point_Out_Size(GameObject button_gameObject)
    {
        button_gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    //==========================
    //進入:放大按扭(動畫)
    //==========================
    public void Set_Button_Point_In_Size_Animation(Animation button_Animation)
    {
        button_Animation.Play("Button_In_Animation");
    }

    //==========================
    //離開:縮小按扭(動畫)
    //==========================
    public void Set_Button_Point_Out_Size_Animation(Animation button_Animation)
    {
        button_Animation.Play("Button_Out_Animation");
    }

}//Button_Event_Trigger_Script
