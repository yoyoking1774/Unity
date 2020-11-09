/*
 * (View)MVC : GameScene -> CardBoard
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View_CardBoard_Script : MonoBehaviour
{
    //===========================================================================================
    //MVC
    //===========================================================================================

    //View_Game_Script VGS
    public View_Game_Script VGS;

    //===========================================================================================
    //DataBase
    //===========================================================================================

    //View_GameScene_DB
    public View_GameScene_DB VGDB;

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

    //player_cardsboard_numbers_text
    public Text player_cardsboard_numbers_text;

    //player_graveyard_numbers_text
    public Text player_graveyard_numbers_text;

    //opponent_cardsboard_numbers_text
    public Text opponent_cardsboard_numbers_text;

    //opponent_graveyard_numbers_text
    public Text opponent_graveyard_numbers_text;

    //CardDetailCanvas_name_text
    public Text carddetailcanvas_name_text;

    //CardDetailCanvas_ability_number_text
    public Text carddetailcanvas_ability_number_text;

    //CardDetailCanvas_ability_text
    public Text carddetailcanvas_ability_text;


    //======================================
    //Image
    //======================================

    //CardDetailCanvas_in_image
    public Image carddetailcanvas_in_image;

    //CardDetailCanvas_headshot_image
    public Image carddetailcanvas_headshot_image;

    //======================================
    //GameObject
    //======================================

    


    //===========================================================================================
    //Function(外部)
    //===========================================================================================

    //player_cardsboard_numbers_text
    public void set_player_cardsboard_numbers_text(int number)
    {
        player_cardsboard_numbers_text.text = "" + number;
    }

    //player_graveyard_numbers_text
    public void set_player_graveyard_numbers_text(int number)
    {
        player_graveyard_numbers_text.text = "" + number;
    }

    //opponent_cardsboard_numbers_text
    public void set_opponent_cardsboard_numbers_text(int number)
    {
        opponent_cardsboard_numbers_text.text = "" + number;
    }

    //opponent_graveyard_numbers_text
    public void set_opponent_graveyard_numbers_text(int number)
    {
        opponent_graveyard_numbers_text.text = "" + number;
    }

    //CardDetailCanvas_name_text
    public void set_carddetailcanvas_name_text(string name)
    {
        carddetailcanvas_name_text.text = "" + name;
    }

    //CardDetailCanvas_ability_number_text
    public void set_carddetailcanvas_ability_number_text(int number)
    {
        carddetailcanvas_ability_number_text.text = "" + number;
    }

    //CardDetailCanvas_ability_text
    public void set_carddetailcanvas_ability_text(string ability)
    {
        carddetailcanvas_ability_text.text = "" + ability;
    }


    //CardDetailCanvas_in_image
    public void set_carddetailcanvas_in_image(bool islegend)
    {
        carddetailcanvas_in_image.sprite = VGDB.get_in_panel_sprite(islegend);
    }

    //CardDetailCanvas_headshot_image
    public void set_carddetailcanvas_headshot_image(Sprite sprite)
    {
        carddetailcanvas_headshot_image.sprite = sprite;
    }



    //===========================================================================================
    //Function(內部)
    //===========================================================================================

    //===========================================================================================
    //Function(統合)
    //===========================================================================================

    //player_cardboard_numbers_text
    public void set_player_all_cardboard_numbers_text(int number , int graveyard_numer)
    {
        set_player_cardsboard_numbers_text(number);
        set_player_graveyard_numbers_text(graveyard_numer);
    }

    //opponent_cardboard_numbers_text
    public void set_opponent_all_cardboard_numbers_text(int number, int graveyard_numer)
    {
        set_opponent_cardsboard_numbers_text(number);
        set_opponent_graveyard_numbers_text(graveyard_numer);
    }


    //一次修改 CardDetailCanvas 資訊(普通、傳說卡牌)
    public void set_carddetailcanvas_information(Normal_Card normal)
    {
        set_carddetailcanvas_name_text(normal.get_name());
        set_carddetailcanvas_ability_text(CADB.get_normal_ablity(normal.get_islegend(), normal.get_ability()));
        set_carddetailcanvas_ability_number_text(normal.get_ability_number());
        set_carddetailcanvas_headshot_image(normal.get_headshot());
        set_carddetailcanvas_in_image(normal.get_islegend());
        
    }

    //一次修改 CardDetailCanvas 資訊(領導卡牌)
    public void set_carddetailcanvas_information(Leader_Card leader)
    {
        set_carddetailcanvas_name_text(leader.get_name());
        set_carddetailcanvas_ability_text(CADB.get_normal_ablity(true, leader.get_ability()));
        set_carddetailcanvas_ability_number_text(leader.get_ability_number());
        set_carddetailcanvas_headshot_image(leader.get_headshot());
        set_carddetailcanvas_in_image(true);
    }

}
