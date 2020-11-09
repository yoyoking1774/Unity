/*
 * (Model)MVC : GameScene - -> GameMonitor
 * 
 * 監看整個GameScene的變化情況，並將監看結果傳回Model_Game_Script。
 * Model_Game_Script依照Model_GameMonitor_Script傳回的情況，來對整個GameScene做出反應。
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_GameMonitor_Script : MonoBehaviour
{
    //===========================================================================================
    //MVC
    //===========================================================================================

    //Model_Game_Script:MGS
    public Model_Game_Script MGS;

    //===========================================================================================
    //Variable
    //===========================================================================================

    //第幾個回合，預設第1回合
    private int round = 1;

    //現在屬於誰的回合，player 或 opponent
    private string now_round = "player";

    //現在狀態
    private string game_state;

    //執行check的人
    private string checker = "empty";

    /*
    //測試用，讓opponent自動出牌
    private void Update()
    {
        if (now_round == "opponent")
        {           
            
            //使用普通卡牌
            //MGS.MGMS.play_card_opponent(MGS.MGMS.get_opponent_handcard(0));
            //使用領導卡牌
            //MGS.MPS.play_leader_card_opponent(MGS.get_opponent().get_play_card().get_leader_card());
            //跳過這一回合
            //MGS.MPS.check("opponent");
            //測試結算
            //MGS.call_showdown();

        }
    }
    */

    //===========================================================================================
    //Function(外部)
    //===========================================================================================

    //外部呼叫，狀態要改變，(caller:呼叫者，state:現在狀態)
    public void call_GameMonitor(string caller, string state)
    {
        game_state = state;

        do_state(caller, state);
    }

    //===========================================================================================
    //Function(內部)
    //===========================================================================================

    //依照game_state判斷現在狀態，(caller:呼叫者，state:現在狀態代號)
    private void do_state(string caller, string state)
    {

        switch (state)
        {
            //出牌(getgraychip)
            case "getgraychip":
            //出牌(getoppositechip)
            case "getoppositechip":
            //出牌(backgraychip)
            case "backgraychip":
                {
                    //更新View，更新 player 手牌數量
                    MGS.CGS.VGS.VPS.set_playerboard_player_handnumber_text(MGS.MGMS.get_all_player_handcard().Count);
                    //更新View，更新 opponent 手牌數量
                    MGS.CGS.VGS.VPS.set_playerboard_opponent_handnumber_text(MGS.MGMS.get_all_opponent_handcard().Count);

                    //更新View，更新雙方分數、outside image
                    MGS.CGS.VGS.VPS.set_score(MGS.get_all_player_chip_list().Count, MGS.get_all_opponent_chip_list().Count);

                    //將回合改變成下一位
                    if(checker == "empty") change_now_round();
                   
                    break;
                }

            //出牌(addcard)
            case "addcard":
            //出牌(lockownchip)
            case "lockownchip":
                {
                    //更新View，更新 player 手牌數量
                    MGS.CGS.VGS.VPS.set_playerboard_player_handnumber_text(MGS.MGMS.get_all_player_handcard().Count);
                    //更新View，更新 opponent 手牌數量
                    MGS.CGS.VGS.VPS.set_playerboard_opponent_handnumber_text(MGS.MGMS.get_all_opponent_handcard().Count);

                    //更新View，更新雙方分數、outside image
                    MGS.CGS.VGS.VPS.set_score(MGS.get_all_player_chip_list().Count, MGS.get_all_opponent_chip_list().Count);

                    //將回合改變成下一位
                    if (checker == "empty") change_now_round();

                    break;
                }
            //check
            case "check":
                {
                    //如果沒有人check
                    if (checker == "empty")
                    {
                        //設定 checker 為 caller
                        checker = caller;
                        //將回合改變成下一位
                        change_now_round();
                    }
                    //如果已經有人check
                    else if (checker != "empty")
                    {
                        //測試結算
                        MGS.call_showdown();
                        //新的回合設定 checker 為 empty
                        checker = "empty";
                    }
                    break;
                }
                
            //結算
            case "showdown":
                {
                    //進入下一回合
                    round = round + 1;
                    //設定回合權
                    now_round = caller;
                    break;
                }
            //結束本次對決
            case "endgame":
                {
                    //print("endgame");
                    MGS.call_endgame();
                    break;
                }
                
        }//switch
    }


    //將回合改變成下一位
    private void change_now_round()
    {
        if (now_round == "player")
            now_round = "opponent";
        else if (now_round == "opponent")
            now_round = "player";
    }

   

    //======================================
    //Getter
    //======================================

    //round
    public int get_round()
    {
        return round;
    }

    //now_round
    public string get_now_round()
    {
        return now_round;
    }

    //game_state
    public string get_game_state()
    {
        return game_state;
    }

    //checker
    public string get_checker()
    {
        return checker;
    }
    //======================================
    //Setter
    //======================================

    //round
    public void set_round(int number)
    {
        round = number;
    }

    //now_round
    public void set_now_round(string round)
    {
        now_round = round;
    }

    //game_state
    public void set_game_state(string state)
    {
        game_state = state;
    }

    //checker
    public void set_checker(string checker)
    {
        this.checker = checker;
    }

}//Model_GameMonitor_Script
