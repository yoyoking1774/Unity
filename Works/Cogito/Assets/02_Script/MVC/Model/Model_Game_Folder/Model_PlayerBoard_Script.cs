/*
 * (Model)MVC : GameScene -> PlayerBoard
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_PlayerBoard_Script : MonoBehaviour
{
    //===========================================================================================
    //MVC
    //===========================================================================================

    //Model_Game_Script:MGS
    public Model_Game_Script MGS;

   

    //===========================================================================================
    //Variable
    //===========================================================================================

    //carddetailcanvas
    public GameObject carddetailcanvas;

    //playerboard_player_leadercard_button
    public GameObject playerboard_player_leadercard_button;

    //opponentboard_opponent_leadercard_image
    public GameObject opponentboard_opponent_leadercard_image;

    private void Start()
    {
        //初始化player的playboard
        MGS.CGS.VGS.VPS.ini_player_playboard(MGS.get_player(), MGS.MGMS.get_all_player_handcard().Count);

        //初始化(Player)
        ini_PlayerBoard_LeaderCard();

        //初始化opponent的opponentboard
        MGS.CGS.VGS.VPS.ini_opponent_playboard(MGS.get_opponent(),MGS.MGMS.get_all_opponent_handcard().Count);

        //初始化(Opponent)
        ini_OpponentBoard_LeaderCard();

    }


    //===========================================================================================
    //Function(Event Trigger)
    //===========================================================================================

    //================
    //(Event Trigger)開啟 CardDetailCanvas (gameObject:卡牌自身)
    //================
    public void Do_Enter_CardDetailCanvas(GameObject gameObject)
    {
        carddetailcanvas.SetActive(true);

        //更新View，一次修改現在editcarddetail資訊
        MGS.CGS.VGS.VCS.set_carddetailcanvas_information(gameObject.GetComponent<Leader_Card>());
    }

    //================
    //(Event Trigger)關閉 CardDetailCanvas
    //================
    public void Do_Exit_CardDetailCanvas()
    {
        carddetailcanvas.SetActive(false);
    }


    //===========================================================================================
    //Function(外部)
    //===========================================================================================

    //出牌(領導卡牌，player)
    public void play_leader_card(Leader_Card leader_card)
    {
        //使用領導卡牌能力
        MGS.get_leader_ability(MGS.MGMIS.get_now_round(), leader_card);
        //更新View，設定領導卡牌為不可用
        MGS.CGS.VGS.VPS.set_playerboard_player_leadercard_button_interactable(false);
        //已使用領導卡牌
        MGS.set_used_leader("player", true);

        //呼叫GameMonitor
        MGS.MGMIS.call_GameMonitor("player", MGS.CADB.get_leader_ablity(MGS.get_player().get_play_card().get_leader_card().get_ability()));

    }

    //出牌(領導卡牌，opponent)
    public void play_leader_card_opponent(Leader_Card leader_card)
    {
        //使用領導卡牌能力
        MGS.get_leader_ability(MGS.MGMIS.get_now_round(), leader_card);
        //更新View，設定領導卡牌為透明，表示已使用
        MGS.CGS.VGS.VPS.set_playerboard_opponent_leadercard_button_image(new Color32(255,255,255,125));
        //已使用領導卡牌
        MGS.set_used_leader("opponent", true);

        //呼叫GameMonitor
        MGS.MGMIS.call_GameMonitor("opponent", MGS.CADB.get_leader_ablity(MGS.get_opponent().get_play_card().get_leader_card().get_ability()));

    }

    //check 
    public void check(string caller)
    {
        switch (caller)
        {
            case "player":
                {
                    MGS.MGMIS.call_GameMonitor("player", "check");
                    break;
                }

            case "opponent":
                {
                    MGS.MGMIS.call_GameMonitor("opponent", "check");
                    break;
                }
        }
    }

    //===========================================================================================
    //Function(內部)
    //===========================================================================================

    //初始化(Player)
    private void ini_PlayerBoard_LeaderCard()
    {
        playerboard_player_leadercard_button.GetComponent<Leader_Card>().set_leader_card(MGS.get_player().get_play_card().get_leader_card());
    }

    //初始化(Opponent)
    private void ini_OpponentBoard_LeaderCard()
    {
        opponentboard_opponent_leadercard_image.GetComponent<Leader_Card>().set_leader_card(MGS.get_opponent().get_play_card().get_leader_card());
    }
}
