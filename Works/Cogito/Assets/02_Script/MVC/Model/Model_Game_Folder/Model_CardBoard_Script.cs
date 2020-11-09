/*
 * (Model)MVC : GameScene -> CardBoard
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_CardBoard_Script : MonoBehaviour
{
    //===========================================================================================
    //MVC
    //===========================================================================================

    //Model_Game_Script:MGS
    public Model_Game_Script MGS;

    //===========================================================================================
    //Variable
    //===========================================================================================

    // List<Normal_Card> : 玩家牌組卡牌
    private List<Normal_Card> player_card;

    // List<Normal_Card> : 對手牌組卡牌
    private List<Normal_Card> opponent_card;

    // List<Normal_Card> : 玩家墓地卡牌
    private List<Normal_Card> player_graveyard_card;

    // List<Normal_Card> : 對手墓地卡牌
    private List<Normal_Card> opponent_graveyard_card;

    // Start
    private void Start()
    {
        //初始化(player)
        ini_card();

        //初始化(opponent)
        ini_card_opponent();

        //開局抽牌(player)
        MGS.MGMS.ini_draw_card(5);

        //開局抽牌(opponent)
        MGS.MGMS.ini_draw_card_opponent(7);

        //更新View，Player CardBoard的卡牌數量
        MGS.CGS.VGS.VCS.set_player_all_cardboard_numbers_text(player_card.Count, player_graveyard_card.Count);

        //更新View，opponent CardBoard的卡牌數量
        MGS.CGS.VGS.VCS.set_opponent_all_cardboard_numbers_text(opponent_card.Count, opponent_graveyard_card.Count);

        /*
        MGS.MGMS.play_card(MGS.MGMS.get_player_handcard(0));
        //MGS.set_now_round("opponent");
        MGS.MGMIS.call_GameMonitor("player",1);
        MGS.MGMS.play_card_opponent(MGS.MGMS.get_opponent_handcard(0));
        //MGS.set_now_round("player");
        MGS.MGMIS.call_GameMonitor("opponent", 1);
        MGS.MGMS.play_card(MGS.MGMS.get_player_handcard(0));
        //MGS.set_now_round("opponent");
        MGS.MGMIS.call_GameMonitor("player", 1);
        MGS.MGMS.play_card_opponent(MGS.MGMS.get_opponent_handcard(0));
        */
        //MGS.CGS.VGS.VPS.set_score(MGS.get_all_player_chip_list().Count, MGS.get_all_opponent_chip_list().Count);
        
        //MGS.MGMS.play_card_opponent(MGS.MGMS.get_opponent_handcard(0));
        //MGS.MGMS.play_card_opponent(MGS.MGMS.get_opponent_handcard(0));
        //MGS.MGMS.play_card_opponent(MGS.MGMS.get_opponent_handcard(0));

        //MGS.MGMS.displaycard_opponent(MGS.MGMS.get_opponent_onplaycard(1));
        //MGS.CGS.VGS.VCS.set_opponent_all_cardboard_numbers_text(opponent_card.Count, opponent_graveyard_card.Count);

        //棄手牌
        //MGS.MGMS.dishandcard(MGS.MGMS.get_player_handcard(1));
        //MGS.CGS.VGS.VCS.set_player_all_cardboard_numbers_text(player_card.Count, player_graveyard_card.Count);

        /*
        //出牌
        MGS.MGMS.play_card(MGS.MGMS.get_player_handcard(0));
        MGS.CGS.VGS.VCS.set_player_all_cardboard_numbers_text(player_card.Count, player_graveyard_card.Count);

        MGS.MGMS.play_card(MGS.MGMS.get_player_handcard(1));
        MGS.CGS.VGS.VCS.set_player_all_cardboard_numbers_text(player_card.Count, player_graveyard_card.Count);

        //移除已上場卡牌
        MGS.MGMS.displaycard(MGS.MGMS.get_player_onplaycard(1));
        MGS.CGS.VGS.VCS.set_player_all_cardboard_numbers_text(player_card.Count, player_graveyard_card.Count);
        */
    }


    //===========================================================================================
    //Function(內部)
    //===========================================================================================

    // 初始化player_card
    private void ini_card()
    {
        player_card = new List<Normal_Card>();

        player_graveyard_card = new List<Normal_Card>();

        // 取得player的上場卡牌
        player_card = MGS.get_player().get_play_card().get_all_normal_card();

        //更新View，Player CardBoard的卡牌數量
        MGS.CGS.VGS.VCS.set_player_all_cardboard_numbers_text(player_card.Count , player_graveyard_card.Count);
    }

    // 初始化opponent_card
    private void ini_card_opponent()
    {
        opponent_card = new List<Normal_Card>();

        opponent_graveyard_card = new List<Normal_Card>();

        // 取得opponent的上場卡牌
        opponent_card = MGS.get_opponent().get_play_card().get_all_normal_card();

        //更新View，opponent CardBoard的卡牌數量
        MGS.CGS.VGS.VCS.set_opponent_all_cardboard_numbers_text(opponent_card.Count, opponent_graveyard_card.Count);
    }


    //增加 player_card
    private void player_card_add(Normal_Card normal_card)
    {
        player_card.Add(normal_card);
    }

    //增加 opponent_card
    private void opponent_card_add(Normal_Card normal_card)
    {
        opponent_card.Add(normal_card);
    }

    //移除 player_card
    private void player_card_remove(Normal_Card normal_card)
    {
        //如果沒有手牌
        if (player_card.Count == 0)
            print("No player card");
        //如果有手牌
        else
        {
            player_card.RemoveAt(player_card.IndexOf(normal_card));
        }
    }

    //移除  opponent_card
    private void opponent_card_remove(Normal_Card normal_card)
    {
        //如果沒有手牌
        if (opponent_card.Count == 0)
            print("No  opponent card");
        //如果有手牌
        else
        {
            opponent_card.RemoveAt(opponent_card.IndexOf(normal_card));
        }
    }

    //增加player_graveyard_card
    private void player_graveyard_card_add(Normal_Card normal_card)
    {
        player_graveyard_card.Add(normal_card);
    }

    //增加opponent_graveyard_card
    private void opponent_graveyard_card_add(Normal_Card normal_card)
    {
        opponent_graveyard_card.Add(normal_card);
    }

    //移除player_graveyard_card
    private void player_graveyard_card_remove(Normal_Card normal_card)
    {
        //如果沒有手牌
        if (player_graveyard_card.Count == 0)
            print("No player_graveyard_card");
        //如果有手牌
        else
        {
            player_graveyard_card.RemoveAt(player_graveyard_card.IndexOf(normal_card));
        }
    }

    //移除opponent_graveyard_card
    private void opponent_graveyard_card_remove(Normal_Card normal_card)
    {
        //如果沒有手牌
        if (opponent_graveyard_card.Count == 0)
            print("No opponent_graveyard_card");
        //如果有手牌
        else
        {
            opponent_graveyard_card.RemoveAt(opponent_graveyard_card.IndexOf(normal_card));
        }
    }

    //===========================================================================================
    //Function(外部)
    //===========================================================================================


    //======================================
    //Getter
    //======================================

    //player_card
    public Normal_Card get_player_card(int idx)
    {
        return player_card[idx];
    }

    //opponent_card
    public Normal_Card get_opponent_card(int idx)
    {
        return opponent_card[idx];
    }

    //player_graveyard_card
    public Normal_Card get_player_graveyard_card(int idx)
    {
        return player_graveyard_card[idx];
    }

    //opponent_graveyard_card
    public Normal_Card get_opponent_graveyard_card(int idx)
    {
        return opponent_graveyard_card[idx];
    }

    //player_card
    public List<Normal_Card> get_all_player_card()
    {
        return player_card;
    }

    //player_card
    public List<Normal_Card> get_all_opponent_card()
    {
        return opponent_card;
    }

    //player_graveyard_card
    public List<Normal_Card> get_all_player_graveyard_card()
    {
        return player_graveyard_card;
    }

    //opponent_graveyard_card
    public List<Normal_Card> get_all_opponent_graveyard_card()
    {
        return opponent_graveyard_card;
    }

    //======================================
    //Setter
    //======================================

    //player_card
    public void set_player_card(string mod, Normal_Card normal_card)
    {
        switch (mod)
        {
            case "Add":
                {
                    player_card_add(normal_card);
                    break;
                }

            case "Remove":
                {
                    player_card_remove(normal_card);
                    break;
                }
        }
    }

    //opponent_card
    public void set_opponent_card(string mod, Normal_Card normal_card)
    {
        switch (mod)
        {
            case "Add":
                {
                    opponent_card_add(normal_card);
                    break;
                }

            case "Remove":
                {
                    opponent_card_remove(normal_card);
                    break;
                }
        }
    }

    //player_graveyard_card
    public void set_player_graveyard_card(string mod, Normal_Card normal_card)
    {
        switch (mod)
        {
            case "Add":
                {
                    player_graveyard_card_add(normal_card);
                    break;
                }

            case "Remove":
                {
                    player_graveyard_card_remove(normal_card);
                    break;
                }
        }
    }

    //opponent_graveyard_card
    public void set_opponent_graveyard_card(string mod, Normal_Card normal_card)
    {
        switch (mod)
        {
            case "Add":
                {
                    opponent_graveyard_card_add(normal_card);
                    break;
                }

            case "Remove":
                {
                    opponent_graveyard_card_remove(normal_card);
                    break;
                }
        }
    }

}
