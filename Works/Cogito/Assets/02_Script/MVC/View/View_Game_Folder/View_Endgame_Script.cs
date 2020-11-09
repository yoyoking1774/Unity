/*
 * (View)MVC : GameScene -> Endgame
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View_Endgame_Script : MonoBehaviour
{

    //===========================================================================================
    //MVC
    //===========================================================================================

    //View_Game_Script VGS
    public View_Game_Script VGS;


    //===========================================================================================
    //UI(Sprite、Text、Image、Button、GameObject)
    //===========================================================================================

    //======================================
    //Tetxt
    //======================================

    //endscore_score_player_text_01
    public Text endscore_score_player_text_01;

    //endscore_score_opponent_text_01
    public Text endscore_score_opponent_text_01;

    //endscore_score_player_text_02
    public Text endscore_score_player_text_02;

    //endscore_score_opponent_text_02
    public Text endscore_score_opponent_text_02;

    //endscore_score_player_text_03
    public Text endscore_score_player_text_03;

    //endscore_score_opponent_text_03
    public Text endscore_score_opponent_text_03;

    //endgame_title_text
    public Text endgame_title_text;



    //======================================
    //Image
    //======================================

    //endgame_title_image
    public Image endgame_title_image;

    //======================================
    //Button
    //======================================

    //endgame_button
    public Button endgame_button;

    //===========================================================================================
    //Function(外部)
    //===========================================================================================

    //endscore_score_player_text_01
    public void set_endscore_score_player_text_01(int score)
    {
        endscore_score_player_text_01.text = "" + score;
    }

    //endscore_score_player_text_01 color
    public void set_endscore_score_player_text_01_color(Color32 color)
    {
        endscore_score_player_text_01.color = color;
    }

    //endscore_score_opponent_text_01
    public void set_endscore_score_opponent_text_01(int score)
    {
        endscore_score_opponent_text_01.text = "" + score;
    }

    //endscore_score_opponent_text_01 color
    public void set_endscore_score_opponent_text_01_color(Color32 color)
    {
        endscore_score_opponent_text_01.color = color;
    }

    //endscore_score_player_text_02
    public void set_endscore_score_player_text_02(int score)
    {
        endscore_score_player_text_02.text = "" + score;
    }

    //endscore_score_player_text_02 color
    public void set_endscore_score_player_text_02_color(Color32 color)
    {
        endscore_score_player_text_02.color = color;
    }

    //endscore_score_opponent_text_02
    public void set_endscore_score_opponent_text_02(int score)
    {
        endscore_score_opponent_text_02.text = "" + score;
    }

    //endscore_score_opponent_text_02 color
    public void set_endscore_score_opponent_text_02_color(Color32 color)
    {
        endscore_score_opponent_text_02.color = color;
    }

    //endscore_score_player_text_03
    public void set_endscore_score_player_text_03(int score)
    {
        endscore_score_player_text_03.text = "" + score;
    }

    //endscore_score_player_text_03 color
    public void set_endscore_score_player_text_03_color(Color32 color)
    {
        endscore_score_player_text_03.color = color;
    }

    //endscore_score_opponent_text_03
    public void set_endscore_score_opponent_text_03(int score)
    {
        endscore_score_opponent_text_03.text = "" + score;
    }

    //endscore_score_opponent_text_03 color
    public void set_endscore_score_opponent_text_03_color(Color32 color)
    {
        endscore_score_opponent_text_03.color = color;
    }

    //endgame_title_text
    public void set_endgame_title_text(string title)
    {
        endgame_title_text.text = title;
    }

    //endgame_title_text color
    public void set_endgame_title_text_color(Color32 color)
    {
        endgame_title_text.color = color;
    }


    //endgame_title_image color
    public void set_endgame_title_image_color(Color32 color)
    {
        endgame_title_image.color = color;
    }

    //endgame_button interable
    public void set_endgame_button_interable(bool state)
    {
        endgame_button.interactable = state;
    }


    //===========================================================================================
    //Function(內部)
    //===========================================================================================

    //endscore_score_player_text
    private void set_endscore_score_player_text(int[,] scoreboard, string[] winnerboard)
    {
        set_endscore_score_player_text_01(scoreboard[0,0]);
        set_endscore_score_player_text_02(scoreboard[0,1]);
        if (winnerboard[2] != null)
            set_endscore_score_player_text_03(scoreboard[0,2]);
         
    }

    //endscore_score_opponent_text
    private void set_endscore_score_opponent_text(int[,] scoreboard, string[] winnerboard)
    {
        set_endscore_score_opponent_text_01(scoreboard[1, 0]);
        set_endscore_score_opponent_text_02(scoreboard[1, 1]);
        if (winnerboard[2] != null)
            set_endscore_score_opponent_text_03(scoreboard[1, 2]);
    }

    //endscore_score_text_color
    private void set_endscore_score_text_color(string[] winnerboard)
    {
        //第1回合
        if (winnerboard[0] == "player")
            set_endscore_score_player_text_01_color(new Color32(246,210,154,255));
        else if(winnerboard[0] == "opponent")
            set_endscore_score_opponent_text_01_color(new Color32(246, 210, 154, 255));

        //第2回合
        if (winnerboard[1] == "player")
            set_endscore_score_player_text_02_color(new Color32(246, 210, 154, 255));
        else if (winnerboard[1] == "opponent")
            set_endscore_score_opponent_text_02_color(new Color32(246, 210, 154, 255));

        //第3回合
        if (winnerboard[2] != null)
        {
            if (winnerboard[2] == "player")
                set_endscore_score_player_text_03_color(new Color32(246, 210, 154, 255));
            else if (winnerboard[2] == "opponent")
                set_endscore_score_opponent_text_03_color(new Color32(246, 210, 154, 255));
        }


    }

    //set_endgame_title
    private void set_set_endgame_title(string winner)
    {
        if (winner == "player")
        {
            set_endgame_title_text("勝");
            set_endgame_title_text_color(new Color32(246, 210, 154, 255));
            set_endgame_title_image_color(new Color32(246, 210, 154, 255));
        }
        else if (winner == "opponent")
        {
            set_endgame_title_text("敗");
            set_endgame_title_text_color(new Color32(229, 85, 99, 255));
            set_endgame_title_image_color(new Color32(229, 85, 99, 255));
        }
        else
        {
            set_endgame_title_text("平手");
            set_endgame_title_text_color(new Color32(255, 255, 255, 255));
            set_endgame_title_image_color(new Color32(255, 255, 255, 255));
        }

    }

    //===========================================================================================
    //Function(統合)
    //===========================================================================================


    //設定Endgame，(scoreboard:結算表，winnerboard:勝利表)
    public void set_endgame(int[,] scoreboard,string[] winnerboard,string winner)
    {
        set_endscore_score_player_text(scoreboard, winnerboard);
        set_endscore_score_opponent_text(scoreboard, winnerboard);
        set_endscore_score_text_color(winnerboard);

        set_set_endgame_title(winner);

    }










}
