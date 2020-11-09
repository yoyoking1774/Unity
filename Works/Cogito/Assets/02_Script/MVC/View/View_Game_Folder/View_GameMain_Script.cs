/*
 * (View)MVC : GameScene -> GameMain
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View_GameMain_Script : MonoBehaviour
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
    //Function(內部)
    //===========================================================================================

    //===========================================================================================
    //Function(外部)
    //===========================================================================================

    //設定player card的大頭照
    public void set_play_card_headshot(GameObject temp_play)
    {
        temp_play.GetComponent<Image>().sprite = temp_play.GetComponent<Normal_Card>().get_headshot();
    }

    //設定player card的Button
    public void set_play_card_button_interable(GameObject temp_play , bool state)
    {
        temp_play.GetComponent<Button>().interactable = state;
    }

    //設定opponent card的大頭照(handcard)
    public void set_opponent_card_headshot(GameObject temp_play)
    {
        temp_play.GetComponent<Image>().sprite = VGDB.get_original_headshot();
    }

    //設定opponent card的大頭照(onplaycard)
    public void set_opponent_card_headshot_onplay(GameObject temp_play)
    {
        temp_play.GetComponent<Image>().sprite = temp_play.GetComponent<Normal_Card>().get_headshot();
    }


}
