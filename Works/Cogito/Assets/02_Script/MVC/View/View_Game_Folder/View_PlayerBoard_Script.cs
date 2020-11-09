/*
 * (View)MVC : GameScene -> PlayerBoard
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View_PlayerBoard_Script : MonoBehaviour
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

    //playerboard_player_name_text
    public Text playerboard_player_name_text;

    //playerboard_player_socname_text
    public Text playerboard_player_socname_text;

    //playerboard_player_handnumber_text
    public Text playerboard_player_handnumber_text;

    //playerboard_player_score_text
    public Text playerboard_player_score_text;

    //playerboard_opponent_name_text
    public Text playerboard_opponent_name_text;

    //playerboard_opponent_socname_text
    public Text playerboard_opponent_socname_text;

    //playerboard_opponent_handnumber_text
    public Text playerboard_opponent_handnumber_text;

    //playerboard_opponent_score_text
    public Text playerboard_opponent_score_text;

    //======================================
    //Image
    //======================================

    //playerboard_player_headshot_image
    public Image playerboard_player_headshot_image;

    //playerboard_player_socheadshot_image
    public Image playerboard_player_socheadshot_image;

    //playerboard_player_life_image_one
    public Image playerboard_player_life_image_one;

    //playerboard_player_life_image_two
    public Image playerboard_player_life_image_two;

    //playerboard_player_score_outside_image
    public Image playerboard_player_score_outside_image;

    //playerboard_player_score_inside_image
    public Image playerboard_player_score_inside_image;

    //playerboard_player_leadercard_button_image
    public Image playerboard_player_leadercard_button_image;

    //playerboard_opponent_headshot_image
    public Image playerboard_opponent_headshot_image;

    //playerboard_opponent_socheadshot_image
    public Image playerboard_opponent_socheadshot_image;

    //playerboard_opponent_life_image_01
    public Image playerboard_opponent_life_image_one;

    //playerboard_opponent_life_image_two
    public Image playerboard_opponent_life_image_two;

    //playerboard_opponent_score_outside_image
    public Image playerboard_opponent_score_outside_image;

    //playerboard_opponent_score_inside_image
    public Image playerboard_opponent_score_inside_image;

    //playerboard_opponent_leadercard_button_image
    public Image playerboard_opponent_leadercard_button_image;

    //======================================
    //Button
    //======================================

    //playerboard_player_leadercard_button
    public Button playerboard_player_leadercard_button;

    //playerBoard_player_check_button
    public Button playerBoard_player_check_button;

    //playerBoard_opponent_check_button
    public Button playerBoard_opponent_check_button;

    //======================================
    //GameObject
    //======================================



    //===========================================================================================
    //Function(外部)
    //===========================================================================================

    //playerboard_player_name_text
    public void set_playerboard_player_name_text(string name)
    {
        playerboard_player_name_text.text = "" + name;
    }

    //playerboard_player_socname_text
    public void set_playerboard_player_socname_text(string socname)
    {
        playerboard_player_socname_text.text = "" + socname;
    }

    //playerboard_player_handnumber_text
    public void set_playerboard_player_handnumber_text(int number)
    {
        playerboard_player_handnumber_text.text = "" + number;
    }

    //playerboard_player_score_text
    public void set_playerboard_player_score_text(int score)
    {
        playerboard_player_score_text.text = "" + score;
    }

    //playerboard_opponent_name_text
    public void set_playerboard_opponent_name_text(string name)
    {
        playerboard_opponent_name_text.text = "" + name;
    }

    //playerboard_opponent_socname_text
    public void set_playerboard_opponent_socname_text(string socname)
    {
        playerboard_opponent_socname_text.text = "" + socname;
    }

    //playerboard_opponent_handnumber_text
    public void set_playerboard_opponent_handnumber_text(int number)
    {
        playerboard_opponent_handnumber_text.text = "" + number;
    }

    //playerboard_opponent_score_text
    public void set_playerboard_opponent_score_text(int score)
    {
        playerboard_opponent_score_text.text = "" + score;
    }

    //playerboard_player_headshot_image
    public void set_playerboard_player_headshot_image(Sprite sprite)
    {
        playerboard_player_headshot_image.sprite = sprite;
    }

    //playerboard_player_socheadshot_image
    public void set_playerboard_player_socheadshot_image(Sprite sprite)
    {
        playerboard_player_socheadshot_image.sprite = sprite;
    }

    //playerboard_player_life_image_one
    public void set_playerboard_player_life_image_one(bool state)
    {
        playerboard_player_life_image_one.sprite = VGDB.get_life_image(state);
    }

    //playerboard_player_life_image_two
    public void set_playerboard_player_life_image_two(bool state)
    {
        playerboard_player_life_image_two.sprite = VGDB.get_life_image(state);
    }

    //playerboard_player_score_outside_image
    public void set_playerboard_player_score_outside_image(Sprite sprite)
    {
        playerboard_player_score_outside_image.sprite = sprite;
    }

    //playerboard_player_score_inside_image
    public void set_playerboard_player_score_inside_image(Sprite sprite)
    {
        playerboard_player_score_inside_image.sprite = sprite;
    }

    //playerboard_player_leadercard_button_image
    public void set_playerboard_player_leadercard_button_image(Sprite sprite)
    {
        playerboard_player_leadercard_button_image.sprite = sprite;
    }

    //playerboard_opponent_headshot_image
    public void set_playerboard_opponent_headshot_image(Sprite sprite)
    {
        playerboard_opponent_headshot_image.sprite = sprite;
    }

    //playerboard_opponent_socheadshot_image
    public void set_playerboard_opponent_socheadshot_image(Sprite sprite)
    {
        playerboard_opponent_socheadshot_image.sprite = sprite;
    }

    //playerboard_opponent_life_image_one
    public void set_playerboard_opponent_life_image_one(bool state)
    {
        playerboard_opponent_life_image_one.sprite = VGDB.get_life_image(state);
    }

    //playerboard_opponent_life_image_two
    public void set_playerboard_opponent_life_image_two(bool state)
    {
        playerboard_opponent_life_image_two.sprite = VGDB.get_life_image(state);
    }

    //playerboard_opponent_score_outside_image
    public void set_playerboard_opponent_score_outside_image(Sprite sprite)
    {
        playerboard_opponent_score_outside_image.sprite = sprite;
    }

    //playerboard_opponent_score_inside_image
    public void set_playerboard_opponent_score_inside_image(Sprite sprite)
    {
        playerboard_opponent_score_inside_image.sprite = sprite;
    }

    //playerboard_opponent_leadercard_button_image
    public void set_playerboard_opponent_leadercard_button_image(Sprite sprite)
    {
        playerboard_opponent_leadercard_button_image.sprite = sprite;
    }

    //playerboard_opponent_leadercard_button_image color
    public void set_playerboard_opponent_leadercard_button_image(Color32 color)
    {
        playerboard_opponent_leadercard_button_image.color = color;
    }

    //playerboard_player_leadercard_button
    public void set_playerboard_player_leadercard_button_interactable(bool state)
    {
        playerboard_player_leadercard_button.interactable = state;
    }

    //playerBoard_player_check_button
    public void set_playerBoard_player_check_button_interactable(bool state)
    {
        playerBoard_player_check_button.interactable = state;
    }

    //playerBoard_opponent_check_button
    public void set_playerBoard_opponent_check_button_interactable(bool state)
    {
        playerBoard_opponent_check_button.interactable = state;
    }

    //===========================================================================================
    //Function(內部)
    //===========================================================================================


    //===========================================================================================
    //Function(統合)
    //===========================================================================================

    //初始化player的playboard(player:玩家、handcards:手牌數量)
    public void ini_player_playboard(Player player , int handcards)
    {
        //text
        set_playerboard_player_name_text(player.get_name());
        set_playerboard_player_socname_text(player.get_play_card().get_leader_card().get_soc());
        set_playerboard_player_handnumber_text(handcards);
        //set_playerboard_player_score_text(0);

        //image
        set_playerboard_player_headshot_image(player.get_headshot());
        set_playerboard_player_socheadshot_image(VGDB.get_soc_sprite(player.get_play_card().get_leader_card().get_soc()));
        set_playerboard_player_life_image_one(true);
        set_playerboard_player_life_image_two(true);
        set_playerboard_player_leadercard_button_image(player.get_play_card().get_leader_card().get_headshot());
    }

    //初始化opponent的playboard(opponent:對手、handcards:手牌數量)
    public void ini_opponent_playboard(Player opponent, int handcards)
    {
        //text
        set_playerboard_opponent_name_text(opponent.get_name());
        set_playerboard_opponent_socname_text(opponent.get_play_card().get_leader_card().get_soc());
        set_playerboard_opponent_handnumber_text(handcards);
        //set_playerboard_opponent_score_text(0);

        //image
        set_playerboard_opponent_headshot_image(opponent.get_headshot());
        set_playerboard_opponent_socheadshot_image(VGDB.get_soc_sprite(opponent.get_play_card().get_leader_card().get_soc()));
        set_playerboard_opponent_life_image_one(true);
        set_playerboard_opponent_life_image_two(true);
        set_playerboard_opponent_leadercard_button_image(opponent.get_play_card().get_leader_card().get_headshot());
    }

    //playerboard_life_image(winner:此回合勝利者，winnerboard:勝利表，round:第幾回合)
    public void set_playerboard_life_image(string winner,string[] winnerboard,int round)
    {
        //第一回合
        if (round == 1)
        {
            if (winner == "player")
                // opponent 的生命寶石變中空
                set_playerboard_opponent_life_image_one(false);
            else if (winner == "opponent")
                // player 的生命寶石變中空
                set_playerboard_player_life_image_one(false);
            else
            {
                // player 的生命寶石變中空
                set_playerboard_player_life_image_one(false);
                // opponent 的生命寶石變中空
                set_playerboard_opponent_life_image_one(false);
            }
        }
        //第二回合
        else if (round == 2)
        {
            if (winner == "player")
            {
                if (winnerboard[0] == "player")
                    // opponent 的生命寶石變中空
                    set_playerboard_opponent_life_image_two(false);
                else if (winnerboard[0] == "opponent")
                    // opponent 的生命寶石變中空
                    set_playerboard_opponent_life_image_one(false);
                else
                {
                    // opponent 的生命寶石變中空
                    set_playerboard_opponent_life_image_two(false);
                }
            }
            else if (winner == "opponent")
            {
                if (winnerboard[0] == "player")
                    // player 的生命寶石變中空
                    set_playerboard_player_life_image_one(false);
                else if (winnerboard[0] == "opponent")
                    // player 的生命寶石變中空
                    set_playerboard_player_life_image_two(false);
                else
                {
                    // player 的生命寶石變中空
                    set_playerboard_player_life_image_two(false);
                }
            }
            else
            {
                if (winnerboard[0] == "player")
                {
                    // player 的生命寶石變中空
                    set_playerboard_player_life_image_one(false);
                    // opponent 的生命寶石變中空
                    set_playerboard_opponent_life_image_two(false);
                }

                else if (winnerboard[0] == "opponent")
                {
                    // player 的生命寶石變中空
                    set_playerboard_player_life_image_two(false);
                    // opponent 的生命寶石變中空
                    set_playerboard_opponent_life_image_one(false);
                }
                else
                {
                    // player 的生命寶石變中空
                    set_playerboard_player_life_image_two(false);
                    // opponent 的生命寶石變中空
                    set_playerboard_opponent_life_image_two(false);
                }
            }
        }
        //第三回合
        else
        {
            if (winner == "player")
                // opponent 的生命寶石變中空
                set_playerboard_opponent_life_image_two(false);
            else if (winner == "opponent")
                // player 的生命寶石變中空
                set_playerboard_player_life_image_two(false);
            else
            {
                // player 的生命寶石變中空
                set_playerboard_player_life_image_two(false);
                // opponent 的生命寶石變中空
                set_playerboard_opponent_life_image_two(false);
            }
        }
    }

    //set_playerboard_player_score_text
    public void set_score(int player_score, int opponent_score)
    {
        
        set_playerboard_player_score_text(player_score);
        set_playerboard_opponent_score_text(opponent_score);
        set_score_outside_image(player_score, opponent_score);
    }

    //score_outside_image(player_score:player分數、opponent_score:opponent分數)
    private void set_score_outside_image(int player_score, int opponent_score)
    {
        //player分數 > opponent分數
        if (player_score > opponent_score)
        {
            playerboard_player_score_outside_image.sprite = VGDB.get_score_outside_image();
            playerboard_opponent_score_outside_image.sprite = null;
            playerboard_player_score_outside_image.color = new Color32(106, 142, 36, 255);
            playerboard_opponent_score_outside_image.color = new Color32(106, 142, 36, 0);
        }
        //player分數 < opponent分數
        else if (player_score < opponent_score)
        {
            playerboard_player_score_outside_image.sprite = null;
            playerboard_opponent_score_outside_image.sprite = VGDB.get_score_outside_image();
            playerboard_player_score_outside_image.color = new Color32(106, 142, 36, 0);
            playerboard_opponent_score_outside_image.color = new Color32(106, 142, 36, 255);
        }
        //雙方分數一樣
        else
        {
            playerboard_player_score_outside_image.sprite = null;
            playerboard_opponent_score_outside_image.sprite = null;
            playerboard_player_score_outside_image.color = new Color32(106, 142, 36, 0);
            playerboard_opponent_score_outside_image.color = new Color32(106, 142, 36, 0);
        }
    }

    //check_button
    public void set_check_button(bool player_state,bool opponent_state)
    {
        set_playerBoard_player_check_button_interactable(player_state);
        set_playerBoard_opponent_check_button_interactable(opponent_state);
    }

}
