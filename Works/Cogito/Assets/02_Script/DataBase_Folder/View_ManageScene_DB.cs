/*
 * ManageScene，UI資料庫
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class View_ManageScene_DB : MonoBehaviour
{

    //===========================================================================================
    //MVC
    //===========================================================================================
    //View_Manage_Script:VMS
    public View_Manage_Script VMS;

    //View_EditCard_Script:VES
    public View_EditCard_Script VES;

    //View_EditCard_LeaderCard_Script
    public View_EditCard_LeaderCard_Script VELS;

    //===========================================================================================
    //DataBase
    //===========================================================================================

    //Normal_Card、Leader_Card 的能力資料庫
    public Card_Ability_DB CADB;

    //===========================================================================================
    //Variable
    //===========================================================================================

    //迴圈用
    private int i, j;

    //===========================================================================================
    //UI(Sprite、Text、Image、Button、GameObject)
    //===========================================================================================


    //======================================
    //Sprite
    //======================================

    //領導卡牌大頭照
    public Sprite[] leadercard_headshot = new Sprite[6];

    //普通卡牌大頭照
    public Sprite[] normalcard_headshot = new Sprite[8];

    //學派:分裂者
    public Sprite soc_fist_sprite;

    //學派:哲學家
    public Sprite soc_philosophy_sprite;

    //學派:學宮
    public Sprite soc_education_sprite;

    //普通卡牌背景
    public Sprite normal_in_panel_sprite;

    //傳說卡牌背景
    public Sprite legend_in_panel_sprite;



    //======================================
    //Text
    //======================================


    //======================================
    //Image
    //======================================





    //===========================================================================================
    //Function(外部)
    //===========================================================================================

    //領導卡牌大頭照(id:領導卡牌編號)
    public Sprite get_leadercard_headshot(int id)
    {
        return leadercard_headshot[id];
    }

    //普通卡牌大頭照(id:普通卡牌編號)
    public Sprite get_normalcard_headshot(int id)
    {
        return normalcard_headshot[id];
    }

    //學派(soc:領導卡牌學派名稱)
    public Sprite get_soc_sprite(string soc)
    {
        switch (soc)
        {
            case ("分裂者"):
                {
                    return soc_fist_sprite;
                    break;
                }

            case ("哲學家"):
                {
                    return soc_philosophy_sprite;
                    break;
                }
            case ("學宮"):
                {
                    return soc_education_sprite;
                    break;
                }
            default:
                return soc_education_sprite;
        }
    }


    //普通、傳說卡牌背景
    public Sprite get_in_panel_sprite(bool islegend)
    {
        if (islegend == true) return legend_in_panel_sprite;

        return normal_in_panel_sprite;
    }


}
