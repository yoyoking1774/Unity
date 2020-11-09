using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class BasicARText_Script : MonoBehaviour , IVirtualButtonEventHandler{

    //=========================================================
    //宣告變數
    //=========================================================
    //隨機數
    private int Number;

    //=========================================================
    //宣告UI
    //=========================================================
    //Text
    public TextMesh ARtext;

    //Animator
    public Animator ARanimator;




    // Start is called before the first frame update
    void Start()
    {
        //抓取VirtualButtonBehaviour
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();

        //取得所有VirtualButton
        for (int i = 0; i < vbs.Length; i++) {
            vbs[i].RegisterEventHandler(this);
        }
        
    }


    /*
    *當使用者靠近VirtualButton，則會自動執行OnButtonPressed
    *當使用者離開VirtualButton，則會自動執行OnButtonReleased 
    */

    //=========================================================
    //按下VirtualButton
    //=========================================================
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        ARtext.text = "" + vb.name + " 按鈕被按下";
        //開始旋轉
        ARanimator.Play("AR_rotation_animation");
    }

    //=========================================================
    //放開VirtualButton
    //=========================================================
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        ARtext.text = "" + vb.name + " 按鈕被放開";
        //停止旋轉
        ARanimator.Play("AR_rotationstop_Animation"); 
    }


}
