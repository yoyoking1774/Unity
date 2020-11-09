/*
 * (View)MVC: MangeScene -> EditCard
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class View_EditCard_Script : MonoBehaviour
{

    //===========================================================================================
    //MVC
    //===========================================================================================
    
    //View_Manage_Script:VMS
    public View_Manage_Script VMS;

    //View_EditCard_LeaderCard_Script
    public View_EditCard_LeaderCard_Script VELS;

    //===========================================================================================
    //DataBase
    //===========================================================================================

    //View_ManageScene_DB
    public View_ManageScene_DB VMDB;

    //Normal_Card、Leader_Card 的能力資料庫
    public Card_Ability_DB CADB;

    //===========================================================================================
    //UI(Sprite、Text、Image、Button、GameObject)
    //===========================================================================================

    //======================================
    //Sprite
    //======================================

    //======================================
    //Text
    //======================================

    //箱子的卡牌數量
    public Text EditOwnCard_Number_Text;

    //已上場的卡牌數量
    public Text EditPlayCard_Number_Text;

    //現在選擇的領導卡牌學派名稱
    public Text editcardbase_soc_text;

    //現在選擇的領導卡牌能力說明
    public Text editcardbasetitle_ability_text;

    //現在選擇的領導卡牌名稱
    public Text editcardbaseleadercard_name_text;

    //EditCardDetail_Name_Text
    public Text EditCardDetail_Name_Text;

    //EditCardDetail_Text
    public Text EditCardDetail_Text;

    //EditCardDetail_Ability_Text
    public Text EditCardDetail_Ability_Text;

    //======================================
    //Image
    //======================================

    //現在選擇的領導卡牌學派Image
    public Image editcardbase_soc_image;

    //EditCardBaseLeaderCard_Button的Image
    public Image editcardbaseleadercard_button_image;

    //EditCardDetail_Image
    public Image EditCardDetail_Image;

    //EditCardDetail_In_Panel的Image
    public Image EditCardDetail_In_Panel_Image;

    //EditCardDetail_Soc_Image
    public Image EditCardDetail_Soc_Image;

    //======================================
    //Button
    //======================================

    //EditCardBaseLeaderCard_Button
    public Button editcardbaseleadercard_button;


    //======================================
    //GameObject
    //======================================

    //editowncard_content:卡牌新增到editowncard_content
    public GameObject editowncard_content;

    //editplaycard_content:卡牌新增到editplaycard_content
    public GameObject editplaycard_content;



    //===========================================================================================
    //Function(外部)
    //===========================================================================================


    //======================================
    //Text
    //======================================

    //================
    //交換卡牌的剩餘卡牌數量(normal_card_object:要交換的卡牌  , other_card:交換卡片在另一個頁面的卡牌 , own_card_normal_cards_number:own_card數量 , play_card_normal_cards_number:play_card數量 , state:是在哪個的content)
    //================
    public void View_single_card_number(GameObject normal_card_object , GameObject other_card, Dictionary<string, int> own_card_normal_cards_number, Dictionary<string, int> play_card_normal_cards_number , bool state)
    {
        //editowncard_content -> editplaycard_content
        if (state == true) normal_card_object.transform.GetChild(0).GetComponent<Text>().text = "X" + own_card_normal_cards_number[normal_card_object.GetComponent<Normal_Card>().get_id().ToString()];
        //editplaycard_content -> editowncard_content
        else normal_card_object.transform.GetChild(0).GetComponent<Text>().text = "X" + play_card_normal_cards_number[normal_card_object.GetComponent<Normal_Card>().get_id().ToString()];

        //editowncard_content -> editplaycard_content
        if (state == true) other_card.transform.GetChild(0).GetComponent<Text>().text = "X" + play_card_normal_cards_number[normal_card_object.GetComponent<Normal_Card>().get_id().ToString()];
        //editplaycard_content -> editowncard_content
        else other_card.transform.GetChild(0).GetComponent<Text>().text = "X" + own_card_normal_cards_number[normal_card_object.GetComponent<Normal_Card>().get_id().ToString()];
    }

    //================
    //OwnCard_Number_Text
    //================
    public void set_EditOwnCard_Number_Text(int number)
    {
        EditOwnCard_Number_Text.text = "" + number;
    }

    //================
    //PlayCard_Number_Text
    //================
    public void set_EditPlayCard_Number_Text(int number)
    {
        EditPlayCard_Number_Text.text = "" + number;
    }

    //================
    //editcardbase_soc_text
    //================
    public void set_editcardbase_soc_text(string soc)
    {
        editcardbase_soc_text.text = "" + soc;
    }

    //================
    //editcardbasetitle_detail_text
    //================
    public void set_editcardbasetitle_ability_text(string ability)
    {
        editcardbasetitle_ability_text.text = "" + ability;
    }

    //================
    //editcardbaseleadercard_name_text
    //================
    public void set_editcardbaseleadercard_name_text(string name)
    {
        editcardbaseleadercard_name_text.text = "" + name;
    }


    //================
    //EditCardDetail_Name_Text
    //================
    public void set_EditCardDetail_Name_Text(string name)
    {
        EditCardDetail_Name_Text.text = "" + name;
    }

    //================
    //EditCardDetail_Text
    //================
    public void set_EditCardDetail_Text(string detail)
    {
        EditCardDetail_Text.text = "" + detail;
    }

    //================
    //EditCardDetail_Ability_Text
    //================
    public void set_EditCardDetail_Ability_Text(int ability_number)
    {
        EditCardDetail_Ability_Text.text = "" + ability_number;
    }
  


    //======================================
    //Image
    //======================================

    //editcardbase_soc_image
    public void set_editcardbase_soc_image(Sprite sprite)
    {
        editcardbase_soc_image.sprite = sprite;
    }

    //editcardbaseleadercard_button_image
    public void set_editcardbaseleadercard_button_image(Sprite sprite)
    {
        editcardbaseleadercard_button_image.sprite = sprite;
    }

    //EditCardDetail_Image
    public void set_EditCardDetail_Image(Sprite sprite)
    {
        EditCardDetail_Image.sprite = sprite;
    }
    

    //EditCardDetail_In_Panel_Image
    public void set_EditCardDetail_In_Panel_Image(bool islegend)
    {
        EditCardDetail_In_Panel_Image.sprite = VMDB.get_in_panel_sprite(islegend);
    }

    //EditCardDetail_Soc_Image
    public void set_EditCardDetail_Soc_Image(string soc)
    {
        EditCardDetail_Soc_Image.sprite = VMDB.get_soc_sprite(soc);
    }


  
    //===========================================================================================
    //Function(內部)
    //===========================================================================================

    //===========================================================================================
    //Function(統合)
    //===========================================================================================

    //一次修改現在選擇的領導卡牌資訊
    public void set_editcardleader_information(Leader_Card leader)
    {
        set_editcardbase_soc_text(leader.get_soc());
        set_editcardbasetitle_ability_text(CADB.get_leader_ablity(leader.get_ability()) + "(" +  leader.get_ability_number() + ")");
        set_editcardbaseleadercard_name_text(leader.get_name());
        set_editcardbaseleadercard_button_image(leader.get_headshot());
        set_editcardbase_soc_image(VMDB.get_soc_sprite(leader.get_soc()));
    }

    //一次修改editcarddetail資訊
    public void set_editcarddetail_information(Normal_Card normal)
    {
        set_EditCardDetail_Name_Text(normal.get_name());
        set_EditCardDetail_Text(CADB.get_normal_ablity(normal.get_islegend() , normal.get_ability()));
        set_EditCardDetail_Ability_Text(normal.get_ability_number());
        set_EditCardDetail_Image(normal.get_headshot());
        set_EditCardDetail_In_Panel_Image(normal.get_islegend());
        set_EditCardDetail_Soc_Image(normal.get_soc());
    }




}
