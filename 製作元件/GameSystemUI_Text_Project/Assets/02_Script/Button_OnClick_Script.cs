//Button的按下功能
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_OnClick_Script : MonoBehaviour
{


    //=============================
    //按下button後，將畫面移動，顯示下一層畫面
    //=============================
    public void Push_Button_Move_Out_Animation(Animation Bg_Image) {
        //播放在Bg_Image上的動畫Button_Push_Move_Out_Animation
        Bg_Image.Play("Button_Push_Move_Out_Animation");
    }

    //=============================
    //返回後後，將畫面復原
    //=============================
    public void Push_Button_Move_In_Animation(Animation Bg_Image)
    {
        //播放在Bg_Image上的動畫Button_Push_Move_In_Animation
        Bg_Image.Play("Button_Push_Move_In_Animation");
    }

}//Button_OnClick_Script
