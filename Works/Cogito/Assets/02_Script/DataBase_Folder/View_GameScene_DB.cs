/*
 * GameScene，UI資料庫
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View_GameScene_DB : MonoBehaviour
{
    //===========================================================================================
    //MVC
    //===========================================================================================
    //View_Game_Script:VGS
    public View_Game_Script VGS;

    //View_PlayerBoard_Script:VPS
    public View_PlayerBoard_Script VPS;

    //View_GameMain_Script:VGMS
    public View_GameMain_Script VGMS;

    //View_CardBoard_Script:VCS
    public View_CardBoard_Script VCS;

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

    //原始卡牌大頭照
    public Sprite original_headshot;

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

    //生命鑽石，0:填滿，1:中空
    public Sprite[] life_image = new Sprite[2];

    //score outside image
    public Sprite score_outside_image;

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

    //原始卡牌大頭照
    public Sprite get_original_headshot()
    {
        return original_headshot;
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

    //生命鑽石image，true:填滿，false:中空
    public Sprite get_life_image(bool state)
    {
        if (state == true)
            return life_image[0];
        else 
            return life_image[1];
    }

    //score outside image
    public Sprite get_score_outside_image()
    {
        return score_outside_image;
    }

}
