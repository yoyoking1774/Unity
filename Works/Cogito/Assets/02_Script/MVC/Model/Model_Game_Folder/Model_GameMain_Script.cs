/*
 * (Model)MVC : GameScene -> GameMain
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_GameMain_Script : MonoBehaviour
{
    //===========================================================================================
    //MVC
    //===========================================================================================

    //Model_Game_Script:MGS
    public Model_Game_Script MGS;

    //===========================================================================================
    //Variable
    //===========================================================================================

    //player，手牌的plane
    public GameObject Main_Player_HandCard_Panel;

    //opponent，手牌的plane
    public GameObject Main_Opponent_HandCard_Panel;

    //player，已上場的牌的plane
    public GameObject Main_Player_OnplayCard_Panel;

    //opponent，已上場的牌的plane
    public GameObject Main_Opponent_OnplayCard_Panel;

    //外部新建player，normal_cards的Prefab
    public GameObject player_instantiate_normal_card;

    //外部新建opponent，normal_cards的Prefab
    public GameObject opponent_instantiate_normal_card;

    //外部新建opponent，上場的normal_cards的Prefab
    public GameObject opponent_instantiate_onplay_normal_card;

    //player手牌
    private List<Normal_Card> player_handcard = new List<Normal_Card>();

    //player手牌
    private List<Normal_Card> opponent_handcard = new List<Normal_Card>();

    //player已上場牌
    private List<Normal_Card> player_onplaycard = new List<Normal_Card>();

    //player已上場牌
    private List<Normal_Card> opponent_onplaycard = new List<Normal_Card>();

    //carddetailcanvas
    public GameObject carddetailcanvas;

   

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
        MGS.CGS.VGS.VCS.set_carddetailcanvas_information(gameObject.GetComponent<Normal_Card>());
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

    //開局抽牌(player)(number : 張數)，(因為需等MCS完成初始化才會有卡牌，為防止搶先，所以在MCS進行初始化)
    public void ini_draw_card(int number)
    {
        //迴圈用
        int i, j;

        //用於設定新建的normal_cards
        GameObject temp_play;

        for (i = 1; i <= number; i++)
        { 
            //建立normal_cards
            temp_play = Instantiate(player_instantiate_normal_card, Main_Player_HandCard_Panel.transform);
            //設定新建的normal_cards的內容
            temp_play.GetComponent<Normal_Card>().set_normal_card(MGS.MCS.get_player_card(0));
            //設定name
            temp_play.name = MGS.MCS.get_player_card(0).get_id().ToString();
            //更新View，設定大頭照
            MGS.CGS.VGS.VGMS.set_play_card_headshot(temp_play);

            //player_handcard加入玩家牌組卡牌第1張，因為一定是牌組最上面的那一張被抽
            player_handcard.Add(MGS.MCS.get_player_card(0));
            //玩家牌組卡牌移除第1張
            MGS.MCS.set_player_card("Remove", MGS.MCS.get_player_card(0));
        }
    
    }

    //開局抽牌(opponent)(number : 張數)，(因為需等MCS完成初始化才會有卡牌，為防止搶先，所以在MCS進行初始化)
    public void ini_draw_card_opponent(int number)
    {
        //迴圈用
        int i, j;

        //用於設定新建的normal_cards
        GameObject temp_play;

        for (i = 1; i <= number; i++)
        {
            //建立normal_cards
            temp_play = Instantiate(opponent_instantiate_normal_card, Main_Opponent_HandCard_Panel.transform);
            //設定新建的normal_cards的內容
            temp_play.GetComponent<Normal_Card>().set_normal_card(MGS.MCS.get_opponent_card(0));
            //設定name
            temp_play.name = MGS.MCS.get_opponent_card(0).get_id().ToString();
            //更新View，設定大頭照
            MGS.CGS.VGS.VGMS.set_opponent_card_headshot(temp_play);

            //player_handcard加入玩家牌組卡牌第1張，因為一定是牌組最上面的那一張被抽
            opponent_handcard.Add(MGS.MCS.get_opponent_card(0));
            //玩家牌組卡牌移除第1張
            MGS.MCS.set_opponent_card("Remove", MGS.MCS.get_opponent_card(0));
        }

    }

    //一般抽牌(number : 張數)
    public void draw_card(int number)
    {
        //迴圈用
        int i, j;

        //用於設定新建的normal_cards
        GameObject temp_play;

        for (i = 1; i <= number; i++)
        {
            //建立normal_cards
            temp_play = Instantiate(player_instantiate_normal_card, Main_Player_HandCard_Panel.transform);
            //設定新建的normal_cards的內容
            temp_play.GetComponent<Normal_Card>().set_normal_card(MGS.MCS.get_player_card(0));
            //設定name
            temp_play.name = MGS.MCS.get_player_card(0).get_id().ToString();
            //更新View，設定大頭照
            MGS.CGS.VGS.VGMS.set_play_card_headshot(temp_play);

            player_handcard.Add(MGS.MCS.get_player_card(0));
            MGS.MCS.set_player_card("Remove", MGS.MCS.get_player_card(0));
        }
    }

    //一般抽牌(number : 張數)
    public void draw_card_opponent(int number)
    {
        //迴圈用
        int i, j;

        //用於設定新建的normal_cards
        GameObject temp_play;

        for (i = 1; i <= number; i++)
        {
            //建立normal_cards
            temp_play = Instantiate(opponent_instantiate_normal_card, Main_Opponent_HandCard_Panel.transform);
            //設定新建的normal_cards的內容
            temp_play.GetComponent<Normal_Card>().set_normal_card(MGS.MCS.get_opponent_card(0));
            //設定name
            temp_play.name = MGS.MCS.get_opponent_card(0).get_id().ToString();
            //更新View，設定大頭照
            MGS.CGS.VGS.VGMS.set_opponent_card_headshot(temp_play);

            opponent_handcard.Add(MGS.MCS.get_opponent_card(0));
            MGS.MCS.set_opponent_card("Remove", MGS.MCS.get_opponent_card(0));
        }
    }

    //移除手牌(Player)
    public void dishandcard(Normal_Card normal_card)
    {
        MGS.MCS.set_player_graveyard_card("Add", normal_card);  

        GameObject temp;
        temp = find_handcard_gameobject(normal_card.get_id());
        set_player_handcard("Remove", normal_card);
        Destroy(temp); 
    }

    //移除手牌(Opponent)
    public void dishandcard_opponent(Normal_Card normal_card)
    {
        MGS.MCS.set_opponent_graveyard_card("Add", normal_card);

        GameObject temp;
        temp = find_handcard_gameobject_opponent(normal_card.get_id());
        set_opponent_handcard("Remove", normal_card);
        Destroy(temp);
    }

    //出牌(Player)
    public void play_card(Normal_Card normal_card)
    {

        //迴圈用
        int i, j;

        //用於設定新建的normal_cards到Main_Player_OnplayCard_Panel
        GameObject temp_play;

        //建立normal_cards
        temp_play = Instantiate(player_instantiate_normal_card, Main_Player_OnplayCard_Panel.transform);
        //設定新建的normal_cards的內容
        temp_play.GetComponent<Normal_Card>().set_normal_card(normal_card);
        //設定name
        temp_play.name = normal_card.get_id().ToString();
        //設定Bitton為unable，這樣以上場的卡牌才不會可以再按一次
        MGS.CGS.VGS.VGMS.set_play_card_button_interable(temp_play,false);
        //更新View，設定大頭照
        MGS.CGS.VGS.VGMS.set_play_card_headshot(temp_play);

        set_player_onplaycard("Add" , normal_card);

        //刪除Main_Player_HandCard_Panel的手牌
        GameObject temp;
        temp = find_handcard_gameobject(normal_card.get_id());
        set_player_handcard("Remove", normal_card);
        DestroyImmediate(temp);

        //使用卡牌能力
        MGS.get_normal_ability(MGS.MGMIS.get_now_round(), player_onplaycard[player_onplaycard.Count-1]);

        //呼叫GameMonitor
        MGS.MGMIS.call_GameMonitor("player", MGS.CADB.get_normal_ablity(player_onplaycard[player_onplaycard.Count - 1].get_islegend(), player_onplaycard[player_onplaycard.Count - 1].get_ability()));

       
    }

    //出牌(Opponent)
    public void play_card_opponent(Normal_Card normal_card)
    {

        //迴圈用
        int i, j;

        //用於設定新建的normal_cards到Main_Player_OnplayCard_Panel
        GameObject temp_play;

        //建立normal_cards
        temp_play = Instantiate(opponent_instantiate_onplay_normal_card, Main_Opponent_OnplayCard_Panel.transform);
        //設定新建的normal_cards的內容
        temp_play.GetComponent<Normal_Card>().set_normal_card(normal_card);
        //設定name
        temp_play.name = normal_card.get_id().ToString();
        //更新View，設定大頭照
        MGS.CGS.VGS.VGMS.set_opponent_card_headshot_onplay(temp_play);

        set_opponent_onplaycard("Add", normal_card);

        //刪除Main_Opponent_HandCard_Panel的手牌
        GameObject temp;
        temp = find_handcard_gameobject_opponent(normal_card.get_id());
        set_opponent_handcard("Remove", normal_card);
        DestroyImmediate(temp);

        
        //使用卡牌能力
        MGS.get_normal_ability(MGS.MGMIS.get_now_round(), opponent_onplaycard[opponent_onplaycard.Count - 1]);

        //呼叫GameMonitor
        MGS.MGMIS.call_GameMonitor("opponent", MGS.CADB.get_normal_ablity(opponent_onplaycard[opponent_onplaycard.Count - 1].get_islegend(), opponent_onplaycard[opponent_onplaycard.Count - 1].get_ability()));
    }

    //移除已上場卡牌(player)
    public void displaycard(Normal_Card normal_card)
    {
        MGS.MCS.set_player_graveyard_card("Add", normal_card);

        GameObject temp;
        temp = find_onplaycard_gameobject(normal_card.get_id());
        set_player_onplaycard("Remove", normal_card);
        Destroy(temp);
        
    }

    //移除全部已上場卡牌(player)
    public void disallplaycard()
    {
        int i;

        int Count_player = player_onplaycard.Count;

        for (i = 0; i < Count_player; i++)
        { 
            displaycard(player_onplaycard[0]);
        }
        
        
    }

    //移除已上場卡牌(opponent)
    public void displaycard_opponent(Normal_Card normal_card)
    {
        MGS.MCS.set_opponent_graveyard_card("Add", normal_card);

        GameObject temp;
        temp = find_onplaycard_gameobject_opponent(normal_card.get_id());
        set_opponent_onplaycard("Remove", normal_card);
        Destroy(temp);
    }

    //移除全部已上場卡牌(opponent)
    public void disallplaycard_opponent()
    {
        int i;

        int Count_opponent = opponent_onplaycard.Count;

        for (i = 0; i < Count_opponent; i++)
        {
            displaycard_opponent(opponent_onplaycard[0]);
        }
    }

    //===========================================================================================
    //Function(內部)
    //===========================================================================================



    //找出Main_Player_HandCard_Panel下的子物件
    private GameObject find_handcard_gameobject(int id)
    {
        
        //迴圈用
        int i, j;

        for (i = 0; i < Main_Player_HandCard_Panel.transform.childCount; i++)
        {
            if (Main_Player_HandCard_Panel.transform.GetChild(i).gameObject.name == id.ToString())
                return Main_Player_HandCard_Panel.transform.GetChild(i).gameObject;
        }

        return null;
    }

    //找出Main_Opponent_HandCard_Panel下的子物件
    private GameObject find_handcard_gameobject_opponent(int id)
    {

        //迴圈用
        int i, j;

        for (i = 0; i < Main_Opponent_HandCard_Panel.transform.childCount; i++)
        {
            if (Main_Opponent_HandCard_Panel.transform.GetChild(i).gameObject.name == id.ToString())
                return Main_Opponent_HandCard_Panel.transform.GetChild(i).gameObject;
        }
        
        return null;
    }

    //找出Main_Player_OnplayCard_Panel下的子物件
    private GameObject find_onplaycard_gameobject(int id)
    {

        //迴圈用
        int i, j;

        for (i = 0; i < Main_Player_OnplayCard_Panel.transform.childCount; i++)
        {
            if (Main_Player_OnplayCard_Panel.transform.GetChild(i).gameObject.name == id.ToString())
                return Main_Player_OnplayCard_Panel.transform.GetChild(i).gameObject;
        }

        return null;
    }

    //找出Main_Opponent_OnplayCard_Panel下的子物件
    private GameObject find_onplaycard_gameobject_opponent(int id)
    {

        //迴圈用
        int i, j;

        for (i = 0; i < Main_Opponent_OnplayCard_Panel.transform.childCount; i++)
        {
            if (Main_Opponent_OnplayCard_Panel.transform.GetChild(i).gameObject.name == id.ToString())
                return Main_Opponent_OnplayCard_Panel.transform.GetChild(i).gameObject;
        }

        return null;
    }


    //增加player_handcard
    private void player_handcard_add(Normal_Card normal_card)
    {
        player_handcard.Add(normal_card);
    }

    //增加opponent_handcard
    private void opponent_handcard_add(Normal_Card normal_card)
    {
        opponent_handcard.Add(normal_card);
    }

    //移除player_handcard
    private void player_handcard_remove(Normal_Card normal_card)
    {
        //如果沒有手牌
        if (player_handcard.Count == 0)
            print("No player_handcard");
        //如果有手牌
        else
        {
            int idx = player_handcard.FindIndex(nc => nc.get_id() == normal_card.get_id());
            
            player_handcard.RemoveAt(idx);
        }
    }

    //移除opponent_handcard
    private void opponent_handcard_remove(Normal_Card normal_card)
    {
        //如果沒有手牌
        if (opponent_handcard.Count == 0)
            print("No opponent_handcard");
        //如果有手牌
        else
        {
            int idx = opponent_handcard.FindIndex(nc => nc.get_id() == normal_card.get_id());

            opponent_handcard.RemoveAt(idx);
        }
    }

    //增加player_onplaycard
    private void player_onplaycard_add(Normal_Card normal_card)
    {
        player_onplaycard.Add(normal_card);
    }

    //增加opponent_onplaycard
    private void opponent_onplaycard_add(Normal_Card normal_card)
    {
        opponent_onplaycard.Add(normal_card);
    }

    //移除player_onplaycard
    private void player_onplaycard_remove(Normal_Card normal_card)
    {
        //如果沒有手牌
        if (player_onplaycard.Count == 0)
            print("No player_onplaycard");
        //如果有手牌
        else
        {
            int idx = player_onplaycard.FindIndex(nc => nc.get_id() == normal_card.get_id());

            player_onplaycard.RemoveAt(idx);
        }
    }

    //移除opponent_onplaycard
    private void opponent_onplaycard_remove(Normal_Card normal_card)
    {
        //如果沒有手牌
        if (opponent_onplaycard.Count == 0)
            print("No opponent_onplaycard");
        //如果有手牌
        else
        {
            int idx = opponent_onplaycard.FindIndex(nc => nc.get_id() == normal_card.get_id());

            opponent_onplaycard.RemoveAt(idx);
        }
    }

    //======================================
    //Getter
    //======================================

    //player_handcard
    public Normal_Card get_player_handcard(int idx)
    {
        return player_handcard[idx];
    }

    //opponent_handcard
    public Normal_Card get_opponent_handcard(int idx)
    {
        return opponent_handcard[idx];
    }

    //全部player_handcard
    public List<Normal_Card> get_all_player_handcard()
    {
        return player_handcard;
    }

    //全部opponent_handcard
    public List<Normal_Card> get_all_opponent_handcard()
    {
        return opponent_handcard;
    }

    //player_onplaycard
    public Normal_Card get_player_onplaycard(int idx)
    {
        return player_onplaycard[idx];
    }

    //opponent_onplaycard
    public Normal_Card get_opponent_onplaycard(int idx)
    {
        return opponent_onplaycard[idx];
    }

    //全部player_onplaycard
    public List<Normal_Card> get_all_player_onplaycard()
    {
        return player_onplaycard;
    }

    //全部opponent_onplaycard
    public List<Normal_Card> get_all_opponent_onplaycard()
    {
        return opponent_onplaycard;
    }

    //======================================
    //Setter
    //======================================

    //player_handcard
    public void set_player_handcard(string mod, Normal_Card normal_card)
    {
        switch (mod)
        {
            case "Add":
                {
                    player_handcard_add(normal_card);
                    break;
                }

            case "Remove":
                {
                    player_handcard_remove(normal_card);
                    break;
                }
        }
    }

    //opponent_handcard
    public void set_opponent_handcard(string mod, Normal_Card normal_card)
    {
        switch (mod)
        {
            case "Add":
                {
                    opponent_handcard_add(normal_card);
                    break;
                }

            case "Remove":
                {
                    opponent_handcard_remove(normal_card);
                    break;
                }
        }
    }

    //player_onplaycard
    public void set_player_onplaycard(string mod, Normal_Card normal_card)
    {
        switch (mod)
        {
            case "Add":
                {
                    player_onplaycard_add(normal_card);
                    break;
                }

            case "Remove":
                {
                    player_onplaycard_remove(normal_card);
                    break;
                }
        }
    }

    //opponent_onplaycard
    public void set_opponent_onplaycard(string mod, Normal_Card normal_card)
    {
        switch (mod)
        {
            case "Add":
                {
                    opponent_onplaycard_add(normal_card);
                    break;
                }

            case "Remove":
                {
                    opponent_onplaycard_remove(normal_card);
                    break;
                }
        }
    }

}
