/*
 * (View)MVC : GameScene
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View_Game_Script : MonoBehaviour
{

    //===========================================================================================
    //MVC
    //===========================================================================================

    //Control_Game_Script:CGS
    public Control_Game_Script CGS;

    //View_PlayerBoard_Script:VPS
    public View_PlayerBoard_Script VPS;

    //View_GameMain_Script:VGMS
    public View_GameMain_Script VGMS;

    //View_CardBoard_Script:VCS
    public View_CardBoard_Script VCS;

    //View_Endgame_Script
    public View_Endgame_Script VES;

    //===========================================================================================
    //Variable
    //===========================================================================================

    //color:4種chip的color
    public Color[] chipcolor = new Color[5];

    //===========================================================================================
    //DataBase
    //===========================================================================================

    //View_GameScene_DB
    public View_GameScene_DB VGDB;

    //Normal_Card、Leader_Card 的能力資料庫
    public Card_Ability_DB CADB;



    //===========================================================================================
    //Function(外部)
    //===========================================================================================

    //chipcolor
    public Color get_chipcolor(int idx)
    {
        return chipcolor[idx];
    }

    //===========================================================================================
    //Function(內部)
    //===========================================================================================





}
