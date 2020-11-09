/*
 * (View)MVC: MangeScene -> EditCard -> EditCard_LeaderCard
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class View_EditCard_LeaderCard_Script : MonoBehaviour
{
    //===========================================================================================
    //MVC
    //===========================================================================================
    //View_EditCard_Script:VES
    public View_EditCard_Script VES;


    //===========================================================================================
    //DataBase
    //===========================================================================================

    //View_ManageScene_DB
    public View_ManageScene_DB VMDB;

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


    //======================================
    //Text
    //======================================

    //領導卡牌名稱
    public Text editcardleader_name_text;
    //領導卡牌描述
    public Text editcardleader_detail_text;
    //領導卡牌學派
    public Text editcardleader_soc_name_text;
    //領導卡牌能力
    public Text editcardleader_soc_ability_text;

    //======================================
    //Image
    //======================================

    //領導卡牌大頭照
    public Image editcardleader_headshot_image;

    //領導卡牌Button大頭照
    public Image[] editcardleader_headshot_button_image = new Image[6];


    //======================================
    //Button
    //======================================

    //選擇領導卡牌
    public Button[] editcardleader_button = new Button[6];



    //===========================================================================================
    //Function(外部)
    //===========================================================================================

    


    //======================================
    //Text
    //======================================
    //editcardleader_name_text
    public void set_editcardleader_name_text(string name)
    {
        editcardleader_name_text.text = "" + name;
    }

    //editcardleader_detail_text
    public void set_editcardleader_detail_text(string detail)
    {
        editcardleader_detail_text.text = "" + detail;
    }

    //editcardleader_soc_name_text
    public void set_editcardleader_soc_name_text(string soc_name)
    {
        editcardleader_soc_name_text.text = "" + soc_name;
    }

    //editcardleader_soc_ability_text
    public void set_editcardleader_soc_ability_text(string soc_ability)
    {
        editcardleader_soc_ability_text.text = "" + soc_ability;
    }

    //全部editcardleader_text
    public void set_editcardleader_text(Leader_Card leader)
    {
        set_editcardleader_name_text(leader.get_name());
        set_editcardleader_detail_text(leader.get_description());
        set_editcardleader_soc_name_text(leader.get_soc());
        set_editcardleader_soc_ability_text(CADB.get_leader_ablity(leader.get_ability()) + "(" + leader.get_ability_number() + ")");
    }


    //======================================
    //Image
    //======================================
    //editcardleader_headshot_image
    public void set_editcardleader_headshot_image(Sprite headshot)
    {
        editcardleader_headshot_image.sprite = headshot;
    }

    //editcardleader_headshot_button_image
    public void set_editcardleader_headshot_button_image(int id , Sprite headshot)
    {
        editcardleader_headshot_button_image[id].sprite = headshot;
    }

    //全部editcardleader_headshot_button_image
    public void set_all_editcardleader_headshot_button_image(Leader_Card[] leader)
    {
        for (i = 0; i < leader.Length; i++)
        {
            editcardleader_headshot_button_image[i].sprite = leader[i].get_headshot();
        }
    }


    //======================================
    //Button
    //======================================


    //===========================================================================================
    //Function(統合)
    //===========================================================================================

    //一次修改領導卡牌選擇資訊
    public void set_editcardleader_information(Leader_Card leader)
    {
        //全部editcardleader_text
        set_editcardleader_text(leader);
        //editcardleader_headshot_image
        set_editcardleader_headshot_image(leader.get_headshot());
    }

}
