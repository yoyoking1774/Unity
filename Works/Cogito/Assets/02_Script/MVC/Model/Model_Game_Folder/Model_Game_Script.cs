/*
 * (Model)MVC : GameScene
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Model_Game_Script : MonoBehaviour
{
    //===========================================================================================
    //MVC
    //===========================================================================================

    //Control_Game_Script:CGS
    public Control_Game_Script CGS;

    //Model_PlayerBoard_Script:MPS
    public Model_PlayerBoard_Script MPS;

    //Model_GameMain_Script:MGMS
    public Model_GameMain_Script MGMS;

    //Model_CardBoard_Script:MCS
    public Model_CardBoard_Script MCS;

    //Model_GameMonitor_Script:MGMIS
    public Model_GameMonitor_Script MGMIS;

    //Model_Endgame_Script
    public Model_Endgame_Script MES;

    //Model_AI_Script
    public Model_AI_Script MAS;

    //===========================================================================================
    //DataBase
    //===========================================================================================

    //Normal_Card、Leader_Card 的能力資料庫
    public Card_Ability_DB CADB;

    //===========================================================================================
    //Variable
    //===========================================================================================

    //結算表[兩位玩家,三次結果]
    private int[,] scoreboard = new int[2,3];
    //勝利表
    private string[] winnerboard = new string[3];
    //本次對決勝利者
    private string winner;
    //是否使用過領導卡牌，共兩位，player、opponent，true:使用過、false:未使用過
    private bool[] used_leader = new bool[2];

    //SaveGame_Class : 存檔
    private GameSave gamesave = new GameSave();

    //Player:player
    private Player player;
    //List<Normal_Card>:玩家擁有普通卡牌
    private List<Normal_Card> pl_nc;
    //Leader_Card:玩家領導卡牌
    private Leader_Card lc;
    //Play_cards:玩家擁有卡牌
    private Play_cards pl;

    //Player:opponent
    private Player opponent;
    //List<Normal_Card>:opponent擁有普通卡牌
    private List<Normal_Card> op_nc;
    //Leader_Card:opponent領導卡牌
    private Leader_Card o_lc;
    //Play_cards:opponent擁有卡牌
    private Play_cards ol;



    //List<Chip>:棋子
    private List<Chip> chips_list = new List<Chip>();

    //List<int>:player擁有棋子編號
    private List<int> player_chip_list = new List<int>();

    //List<int>:opponent擁有棋子編號
    private List<int> opponent_chip_list = new List<int>();

    //int:現在第1顆未變色棋子
    private int last_chip = 0;

    //外部新建chip，chip的Prefab
    public GameObject instantiate_chip;

    //chip的Main_Chips_Neutral_Panel
    public GameObject Main_Chips_Neutral_Panel;

    //EndgameCanvas
    public GameObject EndgameCanvas;

    //==================
    //迴圈用
    //==================
    int i, j;

    //==================
    //載入場景
    //==================
    

    private void Awake()
    {
        //測試區
        //player
        /*pl_nc = new List<Normal_Card>();
        pl_nc.Add(new Normal_Card(0, "一", "哲學家", CGS.VGS.VGDB.get_normalcard_headshot(0), "getgraychip", 5, false));
        pl_nc.Add(new Normal_Card(1, "二", "哲學家", CGS.VGS.VGDB.get_normalcard_headshot(1), "getgraychip", 4, false));
        pl_nc.Add(new Normal_Card(1, "三", "哲學家", CGS.VGS.VGDB.get_normalcard_headshot(1), "getgraychip", 3, false));
        pl_nc.Add(new Normal_Card(7, "四", "哲學家", CGS.VGS.VGDB.get_normalcard_headshot(7), "getoppositechip", 2, false));
        pl_nc.Add(new Normal_Card(1, "三", "哲學家", CGS.VGS.VGDB.get_normalcard_headshot(1), "getgraychip", 2, true));

        pl_nc.Add(new Normal_Card(2, "四", "分裂者", CGS.VGS.VGDB.get_normalcard_headshot(2), "getgraychip", 2, true));
        pl_nc.Add(new Normal_Card(5, "五", "學宮", CGS.VGS.VGDB.get_normalcard_headshot(5), "getgraychip", 3, false));
        pl_nc.Add(new Normal_Card(4, "六", "哲學家", CGS.VGS.VGDB.get_normalcard_headshot(4), "getgraychip", 4, false));
        pl_nc.Add(new Normal_Card(2, "七", "分裂者", CGS.VGS.VGDB.get_normalcard_headshot(2), "backgraychip", 2, true));
        pl_nc.Add(new Normal_Card(2, "八", "分裂者", CGS.VGS.VGDB.get_normalcard_headshot(2), "lockownchip", 2, true));

        lc = new Leader_Card(0, "義晴_1", "學宮", CGS.VGS.VGDB.get_leadercard_headshot(0), "addcard", 2);

        pl = new Play_cards(lc, pl_nc);

        player = new Player(null, pl);
        */


        
        //讀檔區
        lc = new Leader_Card();
        pl_nc = new List<Normal_Card>();
        pl = new Play_cards(null, pl_nc);

        //讀檔
        gamesave.DoLoad_GameScene(pl);

        player = new Player(null, pl);
        

        //opponent
        op_nc = new List<Normal_Card>();
        op_nc.Add(new Normal_Card(0, "一", "哲學家", CGS.VGS.VGDB.get_normalcard_headshot(0), "getgraychip", 4, false));
        op_nc.Add(new Normal_Card(2, "二", "哲學家", CGS.VGS.VGDB.get_normalcard_headshot(1), "getgraychip", 3, false));
        op_nc.Add(new Normal_Card(2, "三", "哲學家", CGS.VGS.VGDB.get_normalcard_headshot(2), "getgraychip", 2, false));
        op_nc.Add(new Normal_Card(3, "四", "哲學家", CGS.VGS.VGDB.get_normalcard_headshot(3), "getoppositechip", 2, false));
        op_nc.Add(new Normal_Card(4, "三", "哲學家", CGS.VGS.VGDB.get_normalcard_headshot(4), "lockownchip", 2, true));

        op_nc.Add(new Normal_Card(2, "四", "分裂者", CGS.VGS.VGDB.get_normalcard_headshot(2), "getgraychip", 2, true));
        op_nc.Add(new Normal_Card(5, "五", "學宮", CGS.VGS.VGDB.get_normalcard_headshot(5), "getgraychip", 3, false));
        op_nc.Add(new Normal_Card(4, "六", "哲學家", CGS.VGS.VGDB.get_normalcard_headshot(4), "getgraychip", 4, false));
        op_nc.Add(new Normal_Card(2, "七", "分裂者", CGS.VGS.VGDB.get_normalcard_headshot(2), "backgraychip", 2, true));
        op_nc.Add(new Normal_Card(2, "八", "分裂者", CGS.VGS.VGDB.get_normalcard_headshot(2), "lockownchip", 2, true));

        o_lc = new Leader_Card(0, "義晴_2", "分裂者", CGS.VGS.VGDB.get_leadercard_headshot(1), "addcard", 2);

        ol = new Play_cards(o_lc, op_nc);

        opponent = new Player(null, ol);

        used_leader[0] = false;
        used_leader[1] = false;

        //初始化，生成chip
        ini_chip(50);
       
        print("player:" + player_chip_list.Count);

        print("opponent:" + opponent_chip_list.Count);

        print("last:" + last_chip);

        
    }


    //測試用，讓opponent自動出牌
    private void Update()
    {
        if (MGMIS.get_now_round() == "opponent")
        {
            //使用普通卡牌
            MGMS.play_card_opponent(MGMS.get_opponent_handcard(0));
            //使用領導卡牌
            //MGS.MPS.play_leader_card_opponent(MGS.get_opponent().get_play_card().get_leader_card());
            //跳過這一回合
            //MGS.MPS.check("opponent");
            //測試結算
            call_showdown();

        }
    }
    
    //===========================================================================================
    //Function(外部)
    //===========================================================================================

    //使用卡牌能力(普通、傳說卡牌)
    public void get_normal_ability(string owner, Normal_Card normal_card)
    {
        string ability = CADB.get_normal_ablity(normal_card.get_islegend(), normal_card.get_ability());

        switch (ability)
        {
            case "getgraychip":
                distributechip_gray(owner, normal_card.get_ability_number());
                break;
            case "getoppositechip":
                distributechip_opposite(owner, normal_card.get_ability_number());
                break;
            case "backgraychip":
                distributechip_backgray(owner, normal_card.get_ability_number());
                break;
            case "lockownchip":
                distributechip_lockchip(owner, normal_card.get_ability_number());
                break;
            default:
                print("No ability");
                break;
        }

    }

    //使用卡牌能力(領導卡牌)
    public void get_leader_ability(string owner, Leader_Card leader_card)
    {
        string ability = CADB.get_leader_ablity(leader_card.get_ability());

        switch (ability)
        {
            case "addcard":
                distributecard_addcard(owner, leader_card.get_ability_number());
                break;
            case "lockownchip":
                distributechip_lockchip(owner, leader_card.get_ability_number());
                break;
            case "getgraychip":
                distributechip_gray(owner, leader_card.get_ability_number());
                break;
            case "getoppositechip":
                distributechip_opposite(owner, leader_card.get_ability_number());
                break;
            case "backgraychip":
                distributechip_backgray(owner, leader_card.get_ability_number());
                break;
            default:
                print("No ability");
                break;
        }
    }

    //呼叫結算
    public void call_showdown()
    {
        showdown();
    }

    //呼叫endgame
    public void call_endgame()
    {
        do_endgame();
    }

    //===========================================================================================
    //Function(內部)
    //===========================================================================================

    //初始化，生成chip(number:生成幾個chip)
    private void ini_chip(int number)
    {
        //迴圈用
        int i, j;

        //用於設定新建的chip
        GameObject temp;

        //用於設定List的chip
        //Chip temp_chip = new Chip();

        for (i = 0; i < number; i++)
        {
            //建立chip
            temp = Instantiate(instantiate_chip, Main_Chips_Neutral_Panel.transform);
            //設定新建的chip的內容
            //temp.GetComponent<Chip>().set_chip(temp_chip);
            //設定name
            temp.name = "chip_" + i.ToString();
            //內部的chips_list增加1個chip
            Chip temp_chip = new Chip();
            chips_list.Add(temp_chip);
        }

    }

    //last_chip找出現在場上第一顆灰色棋子
    private void reset_last_chip()
    {
        //這裡用變數k是因為，如果使用變數i會跟下面使用reset_last_chip的i產生衝突
        for (int k = 0; k < chips_list.Count; k++)
        {
            if (chips_list[k].get_owner() == "empty")
            {
                last_chip = k;
                return;
            }
        }
    }

    //分配chip(灰 -> 紅/紫)
    private void distributechip_gray(string owner, int number)
    {
        //如果全部的灰棋都分配完，則不執行分配
        if (last_chip >= chips_list.Count) return;

        for (i = 1; i <= number; i++)
        {
            if (owner == "player")
            {
                //player的chip_list取得現在第1顆未變色棋子
                player_chip_list.Add(last_chip);
                //將chips_list中的現在第1顆未變色棋子的位置，改變成屬於player
                chips_list[last_chip].set_chip(owner, CGS.VGS.get_chipcolor(1), false);
                //更新View，將現在第1顆未變色棋子變色
                Main_Chips_Neutral_Panel.transform.GetChild(last_chip).GetComponent<Image>().color = CGS.VGS.get_chipcolor(1);
                //找出現在場上第一顆灰色棋子
                reset_last_chip();

            }
            else if (owner == "opponent")
            {
                //opponent的chip_list取得現在第1顆未變色棋子
                opponent_chip_list.Add(last_chip);
                //將chips_list中的現在第1顆未變色棋子的位置，改變成屬於opponent
                chips_list[last_chip].set_chip(owner, CGS.VGS.get_chipcolor(3), false);
                //更新View，將現在第1顆未變色棋子變色
                Main_Chips_Neutral_Panel.transform.GetChild(last_chip).GetComponent<Image>().color = CGS.VGS.get_chipcolor(3);
                //找出現在場上第一顆灰色棋子
                reset_last_chip();
                
            }

            //如果全部的灰棋都分配完，則不執行分配
            if (last_chip >= chips_list.Count) break;
        }

       

        //更新View，player分數、opponent分數
        CGS.VGS.VPS.set_score(player_chip_list.Count, opponent_chip_list.Count);

    }

    //分配chip(紅/紫 -> 紫/紅)
    private void distributechip_opposite(string owner, int number)
    {
        //如果沒有灰棋被分配，則不執行分配
        if (last_chip <= 0) return;

        //如果為player 且 opponent 沒有任何1顆棋子，則不執行分配
        if (owner == "player" && opponent_chip_list.Count <= 0) return;

        //如果為opponent 且 player 沒有任何1顆棋子，則不執行分配
        if (owner == "opponent" && player_chip_list.Count <= 0) return;


        //可以改變的chip的index
        int idx = 0;

        //一直搜尋直到number <= 0
        while (number > 0)
        {
            //player
            if (owner == "player")
            {
                //如果棋子不是鎖定的
                if (chips_list[opponent_chip_list[idx]].get_islock() == false)
                {
                    //player的chip_list取得 opponent 位置為idx的棋子
                    player_chip_list.Add(opponent_chip_list[idx]);
                    //opponent的chip_list失去位置為idx的棋子
                    opponent_chip_list.Remove(opponent_chip_list[idx]);
                    //將chips_list中的opponent位置為idx的棋子，改變成屬於player
                    chips_list[player_chip_list[player_chip_list.Count - 1]].set_chip(owner, CGS.VGS.get_chipcolor(1), false);
                    //更新View，將chips_list位置為player_chip_list[player_chip_list.Count - 1]的棋子變色
                    Main_Chips_Neutral_Panel.transform.GetChild(player_chip_list[player_chip_list.Count - 1]).GetComponent<Image>().color = CGS.VGS.get_chipcolor(1);

                    //數量-1
                    number = number - 1;

                    //更新View，player分數、opponent分數
                    CGS.VGS.VPS.set_score(player_chip_list.Count, opponent_chip_list.Count);
                }
                //如果棋子是鎖定的
                else
                {
                    //找尋下1顆棋子
                    idx = idx + 1;
                }

                //opponent 沒有任何1顆棋子 或 沒有棋子可以搜尋，則不執行分配
                if (opponent_chip_list.Count <= 0 || idx >= opponent_chip_list.Count) break;

            }
            //opponent
            else if (owner == "opponent")
            {
                //如果棋子不是鎖定的
                if (chips_list[player_chip_list[idx]].get_islock() == false)
                {
                    //opponent的chip_list取得 player 位置為idx的棋子
                    opponent_chip_list.Add(player_chip_list[idx]);
                    //player的chip_list失去位置為idx的棋子
                    player_chip_list.Remove(player_chip_list[idx]);
                    //將chips_list中的player位置為idx的棋子，改變成屬於opponent
                    chips_list[opponent_chip_list[opponent_chip_list.Count - 1]].set_chip(owner, CGS.VGS.get_chipcolor(3), false);
                    //更新View，將chips_list位置為opponent_chip_list[opponent_chip_list.Count - 1]的棋子變色
                    Main_Chips_Neutral_Panel.transform.GetChild(opponent_chip_list[opponent_chip_list.Count - 1]).GetComponent<Image>().color = CGS.VGS.get_chipcolor(3);

                    //數量-1
                    number = number - 1;

                    //更新View，player分數、opponent分數
                    CGS.VGS.VPS.set_score(player_chip_list.Count, opponent_chip_list.Count);
                }
                //如果棋子是鎖定的
                else
                {
                    //找尋下1顆棋子
                    idx = idx + 1;
                }

                //player 沒有任何1顆棋子 或 沒有棋子可以搜尋，則不執行分配
                if (player_chip_list.Count <= 0 || idx >= player_chip_list.Count) break;
            }
        }

        

        //更新View，player分數、opponent分數
        CGS.VGS.VPS.set_score(player_chip_list.Count, opponent_chip_list.Count);

    }

    //分配chip(紅/紫 -> 灰)
    private void distributechip_backgray(string owner, int number)
    {
        //如果沒有灰棋被分配，則不執行分配
        if (last_chip <= 0) return;

        //如果為player 且 opponent 沒有任何1顆棋子，則不執行分配
        if (owner == "player" && opponent_chip_list.Count <= 0) return;

        //如果為opponent 且 player 沒有任何1顆棋子，則不執行分配
        if (owner == "opponent" && player_chip_list.Count <= 0) return;


        //可以改變的chip的index
        int idx = 0;

        //一直搜尋直到number <= 0
        while (number > 0)
        {
            if (owner == "player")
            {
                //從最後一顆棋子開始改變
                idx = opponent_chip_list.Count - 1;

                //如果棋子不是鎖定的
                if (chips_list[opponent_chip_list[idx]].get_islock() == false)
                {
                    //將chips_list中的opponent 位置為idx的棋子，改變成不屬於任何一方
                    chips_list[opponent_chip_list[idx]].set_chip("empty", CGS.VGS.get_chipcolor(0), false);
                    //更新View，將chips_list位置為opponent_chip_list[idx]的棋子變色
                    Main_Chips_Neutral_Panel.transform.GetChild(opponent_chip_list[idx]).GetComponent<Image>().color = CGS.VGS.get_chipcolor(0);
                    //opponent的chip_list失去位置為idx的棋子
                    opponent_chip_list.Remove(opponent_chip_list[idx]);

                    //數量-1
                    number = number - 1;

                    //更新View，player分數、opponent分數
                    CGS.VGS.VPS.set_score(player_chip_list.Count, opponent_chip_list.Count);
                }
                //如果棋子是鎖定的
                else
                {
                    //找尋下1顆棋子
                    idx = idx - 1;
                }

                //如果沒有灰棋被分配，則不執行分配
                if (last_chip <= 0) break;

                // opponent 沒有任何1顆棋子 或 沒有棋子可以搜尋，則不執行分配
                if (opponent_chip_list.Count <= 0 || idx < opponent_chip_list.Count) break;

            }
            //opponent
            else if (owner == "opponent")
            {
                //從最後一顆棋子開始改變
                idx = player_chip_list.Count - 1;

                //如果棋子不是鎖定的
                if (chips_list[player_chip_list[idx]].get_islock() == false)
                {
                    //將chips_list中的opponent位置為idx的棋子，改變成不屬於任何一方
                    chips_list[player_chip_list[idx]].set_chip("empty", CGS.VGS.get_chipcolor(0), false);
                    //更新View，將chips_list位置為player_chip_list[idx]的棋子變色
                    Main_Chips_Neutral_Panel.transform.GetChild(player_chip_list[idx]).GetComponent<Image>().color = CGS.VGS.get_chipcolor(0);
                    //opponent的chip_list失去位置為idx的棋子
                    player_chip_list.Remove(player_chip_list[idx]);

                    //數量-1
                    number = number - 1;

                    //更新View，player分數、opponent分數
                    CGS.VGS.VPS.set_score(player_chip_list.Count, opponent_chip_list.Count);
                }
                //如果棋子是鎖定的
                else
                {
                    //找尋下1顆棋子
                    idx = idx - 1;
                }

                //如果沒有灰棋被分配，則不執行分配
                if (last_chip <= 0) break;

                // opponent 沒有任何1顆棋子 或 沒有棋子可以搜尋，則不執行分配
                if (player_chip_list.Count <= 0 || idx < player_chip_list.Count) break;

            }


        }

        

        //更新View，player分數、opponent分數
        CGS.VGS.VPS.set_score(player_chip_list.Count, opponent_chip_list.Count);

        //找出現在場上第一顆灰色棋子
        reset_last_chip();

    }

    //分配chip(紅/紫 -> 鎖定)
    private void distributechip_lockchip(string owner, int number)
    {
        //如果沒有灰棋被分配，則不執行分配
        if (last_chip <= 0) return;

        //如果為player 且 player 沒有任何1顆棋子，則不執行分配
        if (owner == "player" && player_chip_list.Count <= 0) return;

        //如果為opponent 且 opponent 沒有任何1顆棋子，則不執行分配
        if (owner == "opponent" && opponent_chip_list.Count <= 0) return;

        
        //依照number次數改變
        for (i = 1; i <= number; i++)
        {
            //player
            if (owner == "player")
            {
                //從頭將 player_chip_list 搜尋一遍
                for (j = 0; j < player_chip_list.Count; j++)
                {
                    //如果棋子不是鎖定的
                    if (chips_list[player_chip_list[j]].get_islock() == false) {
                        //將位置為player_chip_list[j]的棋子變色棋子變成鎖定
                        chips_list[player_chip_list[j]].set_chip("player", CGS.VGS.get_chipcolor(2), true);
                        //更新View，將 chips_list 位置為player_chip_list[j]的棋子變色
                        Main_Chips_Neutral_Panel.transform.GetChild(player_chip_list[j]).GetComponent<Image>().color = CGS.VGS.get_chipcolor(2);
                        //結束搜尋
                        break;
                    }
                }//for (j = 0; j < player_chip_list.Count; j++)
            }//if (owner == "player")
            //opponent
            else if (owner == "opponent")
            {
                //從頭將opponent_chip_list 搜尋一遍
                for (j = 0; j < opponent_chip_list.Count; j++)
                {
                    //如果棋子不是鎖定的
                    if (chips_list[opponent_chip_list[j]].get_islock() == false)
                    {
                        //將位置為opponent_chip_list[j]的棋子變色棋子變成鎖定
                        chips_list[opponent_chip_list[j]].set_chip("opponent", CGS.VGS.get_chipcolor(4), true);
                        //更新View，將 chips_list opponent_chip_list[j]的棋子變色
                        Main_Chips_Neutral_Panel.transform.GetChild(opponent_chip_list[j]).GetComponent<Image>().color = CGS.VGS.get_chipcolor(4);
                        //結束搜尋
                        break;
                    }
                }//for (j = 0; j < opponent_chip_list.Count; j++)
            }//else if (owner == "opponent")
        }//for (i = 1; i <= number; i++)

    }

    //抽牌
    private void distributecard_addcard(string owner, int number)
    {
        if (owner == "player")
            MGMS.draw_card(number);
        else if (owner == "opponent")
            MGMS.draw_card_opponent(number);
        else
            print("No card");
    }

    //結算
    private void showdown()
    {
        //記錄本場 player 的分數
        scoreboard[0,MGMIS.get_round() - 1] = player_chip_list.Count;
        //記錄本場 opponent 的分數
        scoreboard[1,MGMIS.get_round() - 1] = opponent_chip_list.Count;

        //如果 player 分數較多
        if (player_chip_list.Count > opponent_chip_list.Count) { 
            CGS.VGS.VPS.set_playerboard_life_image("player",winnerboard , MGMIS.get_round());
            //將該回合的勝利者設為 player
            winnerboard[MGMIS.get_round() - 1] = "player";
            //將該回合結算，並將回合權保留給 player
            MGMIS.call_GameMonitor("player", "showdown");
        }
        //如果 opponent 分數較多
        else if(player_chip_list.Count < opponent_chip_list.Count) { 
            CGS.VGS.VPS.set_playerboard_life_image("opponent", winnerboard, MGMIS.get_round());
            //將該回合的勝利者設為 opponent
            winnerboard[MGMIS.get_round() - 1] = "opponent";
            //將該回合結算，並將回合權保留給 opponent
            //這裡為了測試所以改成 player，防止回合權給 opponent，造成系統更新太快產生error
            MGMIS.call_GameMonitor("player", "showdown");
        }
        //如果 分數一樣
        else { 
            CGS.VGS.VPS.set_playerboard_life_image("draw", winnerboard, MGMIS.get_round());
            //將該回合設為 draw
            winnerboard[MGMIS.get_round() - 1] = "draw";
            //將該回合結算，並將回合權保留給 最後出牌者
            MGMIS.call_GameMonitor(MGMIS.get_now_round(), "showdown");
        }

        //重整牌面
        organize();

        

        //判斷是否結束本次對決
        if (do_endgame_judge())
            MGMIS.call_GameMonitor(MGMIS.get_now_round(), "endgame");


    }

    //重整牌面
    private void organize()
    {
        //重整牌面:雙方已上場的卡牌，都進入墓地
        organize_to_displaycard();
        //重整牌面:將所有 chip 恢復成灰色
        organize_to_backgray();

        //更新View，雙方分數
        CGS.VGS.VPS.set_score(player_chip_list.Count, opponent_chip_list.Count);
        //更新View，player 手牌數量
        CGS.VGS.VPS.set_playerboard_player_handnumber_text(MGMS.get_all_player_handcard().Count);
        //更新View，opponent 手牌數量
        CGS.VGS.VPS.set_playerboard_opponent_handnumber_text(MGMS.get_all_opponent_handcard().Count);

        //更新View，player 牌組數量、墓地數量
        CGS.VGS.VCS.set_player_all_cardboard_numbers_text(MCS.get_all_player_card().Count,MCS.get_all_player_graveyard_card().Count);
        //更新View，opponent 牌組數量、墓地數量
        CGS.VGS.VCS.set_opponent_all_cardboard_numbers_text(MCS.get_all_opponent_card().Count, MCS.get_all_opponent_graveyard_card().Count);
    }

    //重整牌面:雙方已上場的卡牌，都進入墓地
    private void organize_to_displaycard()
    {
        //移除全部已上場卡牌(player)
        MGMS.disallplaycard();
        //移除全部已上場卡牌(opponent)
        MGMS.disallplaycard_opponent();
    }

    //重整牌面:將所有 chip 恢復成灰色
    private void organize_to_backgray()
    {
        int idx;

        //player
        for (idx = player_chip_list.Count - 1; idx >= 0; idx--)
        {
            //將chips_list中的 player 位置為idx的棋子，改變成不屬於任何一方
            chips_list[player_chip_list[idx]].set_chip("empty", CGS.VGS.get_chipcolor(0), false);
            //更新View，將chips_list位置為player_chip_list[idx]的棋子變色
            Main_Chips_Neutral_Panel.transform.GetChild(player_chip_list[idx]).GetComponent<Image>().color = CGS.VGS.get_chipcolor(0);
            //player 的chip_list失去位置為idx的棋子
            player_chip_list.Remove(player_chip_list[idx]);
        }

        //opponent
        for (idx = opponent_chip_list.Count - 1; idx >= 0; idx--) { 
            //將chips_list中的opponent 位置為idx的棋子，改變成不屬於任何一方
            chips_list[opponent_chip_list[idx]].set_chip("empty", CGS.VGS.get_chipcolor(0), false);
            //更新View，將chips_list位置為opponent_chip_list[idx]的棋子變色
            Main_Chips_Neutral_Panel.transform.GetChild(opponent_chip_list[idx]).GetComponent<Image>().color = CGS.VGS.get_chipcolor(0);
            //opponent的chip_list失去位置為idx的棋子
            opponent_chip_list.Remove(opponent_chip_list[idx]);
        }

        //last_chip找出現在場上第一顆灰色棋子
        reset_last_chip();
    }

    //判斷是否結束本次對決，(true:結束本次對決，false:不結束本次對決)
    private bool do_endgame_judge()
    {
        //第一種情況，連續2回合同一人勝利
        if (winnerboard[0] == winnerboard[1])
            return true;
        //第二種情況，第1回合不是平手但第二回合是平手 或 第1回合是平手但第二回合不是平手
        else if ( (winnerboard[0] !="draw" && winnerboard[1] == "draw") || (winnerboard[0] == "draw" && winnerboard[1] != "draw"))
            return true;
        //第三種情況，第3回合結束
        //由於會先進行結算，再判斷本次對決，所以round會為4，但為防止error所以設round大於3
        else if (MGMIS.get_round() > 3)
            return true;

        return false;
    }

    //結束本次對決
    private void do_endgame()
    {
        EndgameCanvas.SetActive(true);
        set_winner();
        CGS.VGS.VES.set_endgame(scoreboard,winnerboard,winner);
    }

    //決定本次對決勝利者
    private void set_winner()
    {
        int player_count = 0;
        int opponent_count = 0;
        int draw_count = 0;


        if (winnerboard[0] == "player")
            player_count = player_count + 1;
        else if (winnerboard[0] == "opponent")
            opponent_count = opponent_count + 1;
        else
            draw_count = draw_count + 1;

        if (winnerboard[1] == "player")
            player_count = player_count + 1;
        else if (winnerboard[1] == "opponent")
            opponent_count = opponent_count + 1;
        else
            draw_count = draw_count + 1;

        if (winnerboard[2] != null)
        {
            if (winnerboard[2] == "player")
                player_count = player_count + 1;
            else if (winnerboard[2] == "opponent")
                opponent_count = opponent_count + 1;
            else
                draw_count = draw_count + 1;
        }

        if (player_count > opponent_count)
            winner = "player";
        else if (player_count < opponent_count)
            winner = "opponent";
        else
            winner = "draw";

        //存檔
        gamesave.DoSave_GameScene();

    }


    //======================================
    //Getter
    //======================================

    //scoreboard，(side:兩位玩家，round:回合)
    public int get_scoreboard(int side,int round)
    {
        return scoreboard[side,round];
    }

    //winner
    public string get_winnerboard(int round)
    {
        return winnerboard[round];
    }

    //winner
    public string get_winner()
    {
        return winner;
    }

    //used_leader
    public bool get_used_leader(string caller)
    {
        if (caller == "player")
            return used_leader[0];
        else if (caller == "opponent")
            return used_leader[1];

        return false;
    }

    //player
    public Player get_player()
    {
        return player;
    }

    //opponent
    public Player get_opponent()
    {
        return opponent;
    }

    //chips_list
    public Chip get_chips_list(int idx)
    {
        return chips_list[idx];
    }

    //全部chips_list
    public List<Chip> get_all_chips_list()
    {
        return chips_list;
    }

    //player_chip_list
    public int get_player_chip_list(int idx)
    {
        return player_chip_list[idx];
    }

   

    //全部player_chip_list
    public List<int> get_all_player_chip_list()
    {
        return player_chip_list;
    }

    //opponent_chip_list
    public int get_opponent_chip_list(int idx)
    {
        return opponent_chip_list[idx];
    }

    //全部opponent_chip_list
    public List<int> get_all_opponent_chip_list()
    {
        return opponent_chip_list;
    }

    //last_chip
    public int get_last_chip()
    {
        return last_chip;
    }



    //======================================
    //Setter
    //======================================

    //used_leader
    public void set_used_leader(string caller,bool state)
    {
        if (caller == "player")
             used_leader[0] = state;
        else if (caller == "opponent")
            used_leader[1] = state;

    }

}

