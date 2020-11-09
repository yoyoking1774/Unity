//控制Triangle_Detail_Circle按扭的腳本
//附著於Detail_Text_Script腳本
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Triangle_Detail_Circle_Button_Script : MonoBehaviour
{
    //================================
    //變數
    //================================
    //用於Detail_Text_Script底下的UI
    public Detail_Text_Script DTS;

    //================================
    //使用:Triangle_Detail_Circle_Button(按扭編號，依照編號執行不同技能細節)
    //================================
    public void Use_Triangle_Detail_Circle_Button(int Number) {

        //如果是返回健，則不播放Text刷新動畫
        if(Number != 0) DTS.Play_Detail_Text_Refresh_Animation();

        switch (Number)
        {
            //恢復成一開始沒有點選技能的樣子
            case 0:
                {
                    Triangle_Detail_Back_Button();
                    break;
                }
            //======================
            //以下為各種技能的點選
            //======================
            case 1:
                {
                    Triangle_Detail_Circle_Button_One();
                    break;
                }

            case 4:
                {
                    Triangle_Detail_Circle_Button_Four();
                    break;
                }
            //預設功能
            default:
                {
                    Triangle_Detail_Back_Button();
                    break;
                }
        }//switch

    }//Use_Triangle_Detail_Circle_Button

    //=====================================================================================================================
    //以下由開發者自行新增，也可將字串放在資料庫，再將以下執行的DTS修改為讀取資料庫
    //=====================================================================================================================

    //================================
    //Triangle_Detail_Back_Button 功能，恢復成一開始沒有點選技能的樣子
    //================================
    void Triangle_Detail_Back_Button() {
        DTS.Set_Detail_Name_Text("(點選任一技能)技能名稱");
        DTS.Set_Detail_Describe_Text("(點選任一技能)描述");
        DTS.Set_Detail_Ability_Text("(點選任一技能)能力");
        DTS.Set_Detail_Request_Text("(點選任一技能)要求");
    }

    //================================
    //Triangle_Detail_Circle_Button_1_1編號 1 功能
    //================================
    void Triangle_Detail_Circle_Button_One() {
        DTS.Set_Detail_Name_Text("狂襲浪潮");
        DTS.Set_Detail_Describe_Text("破壞性傷害");
        DTS.Set_Detail_Ability_Text("增加200%狂襲傷害");
        DTS.Set_Detail_Request_Text("經驗值100");
    }

    //================================
    //Triangle_Detail_Circle_Button_2_1編號 4 功能
    //================================
    void Triangle_Detail_Circle_Button_Four()
    {
        DTS.Set_Detail_Name_Text("平凡威古");
        DTS.Set_Detail_Describe_Text("恢復性治療");
        DTS.Set_Detail_Ability_Text("增加50%生命");
        DTS.Set_Detail_Request_Text("經驗值500");
    }

}//Triangle_Detail_Circle_Button_Script
