/*
 * 使用於 Cogito 整個遊戲的存檔，繼承StartSave
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//使用Dictionary的ElementAt
using System.Linq;

public class GameSave : StartSave
{
    //===========================================================================================
    //MVC
    //===========================================================================================

    //===========================================================================================
    //DataBase
    //===========================================================================================

    //Card_Detail_DB
    private Card_Detail_DB CDDB;
    
    //===========================================================================================
    //Variable
    //===========================================================================================

    //迴圈用
    private int i, j;

    //擁有的卡牌:普通卡牌
    private List<Normal_Card> nc = new List<Normal_Card>();
    //要上場的卡牌:普通卡牌
    private List<Normal_Card> pl_nc = new List<Normal_Card>();
    //擁有的卡牌:領導卡牌
    private List<Leader_Card> lc = new List<Leader_Card>();

    

    //===========================================================================================
    //Function(外部)
    //===========================================================================================

    //初始化
    public void ini(List<Normal_Card> nc, List<Normal_Card> pl_nc, List<Leader_Card> lc)
    {
        //抓取外部元件 Card_Detail_DB，底下的 Card_Detail_DB 腳本
        CDDB = GameObject.Find("Card_Detail_DB").GetComponent<Card_Detail_DB>();

        this.nc = new List<Normal_Card>(nc);
        this.pl_nc = new List<Normal_Card>(pl_nc);
        this.lc = new List<Leader_Card>(lc);

        

    }


    //============
    //存檔(ManageScene用)，(own_card:擁有的卡牌，play_card:要上場的卡牌)
    //============

    public void DoSave_ManageScene(Own_cards own_card, Play_cards play_card)
    {
        //清空，防止資料重疊
        Sav.own_leader_cards.Clear();
        Sav.own_normal_cards.Clear();
        Sav.play_normal_cards.Clear();

        //temp_own_normal 暫存擁有的卡牌的普通卡牌
        List<Normal_Card> temp_own_normal = own_card.get_all_normal_card();
        //一一將id儲存起來
        for (i = 0; i < temp_own_normal.Count; i++)
        {
            Sav.own_normal_cards.Add(temp_own_normal[i].get_id());
            //print("Sav.own_normal_cards"+temp_own_normal[i].get_id());
        }

        //temp_own_normal 暫存擁有的卡牌的領導卡牌
        List<Leader_Card> temp_own_leader = own_card.get_all_leader_card();
        //一一將id儲存起來
        for (i = 0; i < temp_own_leader.Count; i++)
        {
            Sav.own_leader_cards.Add(temp_own_leader[i].get_id());

            //print("Sav.temp_own_leader : "+ temp_own_leader[i].get_id());
        }

        //儲存要上場的領導卡牌的id
        Sav.play_leader_card = play_card.get_leader_card().get_id();

        //temp_own_normal 暫存要上場的卡牌的普通卡牌
        List<Normal_Card> temp_play_normal = play_card.get_all_normal_card();
        //一一將id儲存起來
        for (i = 0; i < temp_play_normal.Count; i++)
        {
            Sav.play_normal_cards.Add(temp_play_normal[i].get_id());

            //print("Sav.play_normal_cards"+ temp_play_normal[i].get_id());
        }

       

        //============
        //進行存檔
        //============
        PlayerPrefs.SetString("SaveFile_2", JsonUtility.ToJson(Sav));

        print(PlayerPrefs.GetString("SaveFile_2"));

        print("Save" + "ManageScene存檔成功。");

        //SceneManager.LoadScene("GameScene");

    }

    //============
    //讀檔(ManageScene用)，(own_card:擁有的卡牌，play_card:要上場的卡牌)
    //============
    public void DoLoad_ManageScene(Own_cards own_card, Play_cards play_card)
    {
        //============
        //進行讀檔
        //============
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("SaveFile_2"), Sav);

        print(PlayerPrefs.GetString("SaveFile_2"));


        

        //====================================================
        //第1次讀檔
        //====================================================
        if (Sav.FirstSave == true)
        {
            //清空，防止資料重疊
            Sav.own_leader_cards.Clear();
            Sav.own_normal_cards.Clear();
            Sav.play_normal_cards.Clear();

            //預設牌組(擁有的普通卡牌)
            nc.Add(CDDB.get_normal_card_detail(0, "ManageScene"));
            nc.Add(CDDB.get_normal_card_detail(1, "ManageScene"));
            nc.Add(CDDB.get_normal_card_detail(2, "ManageScene"));
            nc.Add(CDDB.get_normal_card_detail(3, "ManageScene"));
            nc.Add(CDDB.get_normal_card_detail(4, "ManageScene"));
            nc.Add(CDDB.get_normal_card_detail(5, "ManageScene"));

            //預設牌組(要上場的的普通卡牌)
            pl_nc.Add(CDDB.get_normal_card_detail(0, "ManageScene"));
            pl_nc.Add(CDDB.get_normal_card_detail(1, "ManageScene"));
            pl_nc.Add(CDDB.get_normal_card_detail(2, "ManageScene"));
            pl_nc.Add(CDDB.get_normal_card_detail(3, "ManageScene"));

            //預設牌組(擁有的領導卡牌)
            lc.Add(CDDB.get_leader_card_detail(0, "ManageScene"));
            lc.Add(CDDB.get_leader_card_detail(1, "ManageScene"));
            lc.Add(CDDB.get_leader_card_detail(2, "ManageScene"));
            lc.Add(CDDB.get_leader_card_detail(3, "ManageScene"));
            lc.Add(CDDB.get_leader_card_detail(4, "ManageScene"));
            lc.Add(CDDB.get_leader_card_detail(5, "ManageScene"));

            //放入預設資料
            for (i = 0; i < lc.Count; i++)
                Sav.own_leader_cards.Add(lc[i].get_id());

            //放入預設資料
            for (i = 0; i < nc.Count; i++)
                Sav.own_normal_cards.Add(nc[i].get_id());

            //放入預設資料
            Sav.play_leader_card = 0;

            //放入預設資料
            for (i = 0; i < pl_nc.Count; i++)
                Sav.play_normal_cards.Add(pl_nc[i].get_id());
                


            //將FirstSave設為false，表示已有讀檔
            Sav.FirstSave = false;

            
            //進行存檔，儲存FirstSave設為false
            PlayerPrefs.SetString("SaveFile_2", JsonUtility.ToJson(Sav));

            print("第1次讀檔" + PlayerPrefs.GetString("SaveFile_2"));

        }

        //====================================================
        //第2次以上(含)讀檔
        //====================================================
        else
        {
            //清空，防止資料重疊
            this.nc.Clear();
            this.pl_nc.Clear();
            this.lc.Clear();



            //讀取卡牌資料，放入領導卡牌
            for (i = 0; i < Sav.own_leader_cards.Count; i++)
                //lc.Add(new Leader_Card(Sav.own_leader_cards[i]));
                lc.Add(CDDB.get_leader_card_detail(Sav.own_leader_cards[i],"ManageScene"));
            
            //讀取卡牌資料，放入普通卡牌
            for (i = 0; i < Sav.own_normal_cards.Count; i++)
                //nc.Add(new Normal_Card(Sav.own_normal_cards[i]));
                nc.Add(CDDB.get_normal_card_detail(Sav.own_normal_cards[i], "ManageScene"));

            //讀取卡牌資料，放入普通卡牌
            for (i = 0; i < Sav.play_normal_cards.Count; i++)
                //pl_nc.Add(new Normal_Card(Sav.play_normal_cards[i]));
                pl_nc.Add(CDDB.get_normal_card_detail(Sav.play_normal_cards[i], "ManageScene"));

            //設定擁有的卡牌
            own_card.set_own_card(lc, nc);

            //設定要上場的卡牌
            play_card.set_play_card(CDDB.get_leader_card_detail(Sav.play_leader_card, "ManageScene"), pl_nc);

           
            //底下兩行是當存檔有錯誤時，重新恢復到第一次讀檔
            //將FirstSave設為false，表示已有讀檔
            //Sav.FirstSave = true;

            //進行存檔，儲存FirstSave設為false
            //PlayerPrefs.SetString("SaveFile_2", JsonUtility.ToJson(Sav));
        }


        print("Load" + "ManageScene讀檔成功。");

    }


    //============
    //存檔(GameScene用)，()
    //============
    public void DoSave_GameScene()
    {
        /*
         * 主要記錄勝利後要獲得的卡牌
         * 建議創一個list，儲存要獲得的卡牌的id，然後在DoLoad_ManageScene()中一一放入nc。
         */


        //============
        //進行存檔
        //============
        PlayerPrefs.SetString("SaveFile_2", JsonUtility.ToJson(Sav));

        print(PlayerPrefs.GetString("SaveFile_2"));

        print("Save" + "GameScene存檔成功。");
        
    }

    //============
    //讀檔(GameScene用)，(play_card:要上場的卡牌)
    //============
    public void DoLoad_GameScene(Play_cards play_card)
    {
        //============
        //進行讀檔
        //============
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("SaveFile_2"), Sav);

        print(PlayerPrefs.GetString("SaveFile_2"));


        //抓取外部元件 Card_Detail_DB，底下的 Card_Detail_DB 腳本
        CDDB = GameObject.Find("Card_Detail_DB").GetComponent<Card_Detail_DB>();

        //清空，防止資料重疊
        this.pl_nc.Clear();

        //讀取卡牌資料，放入普通卡牌
        for (i = 0; i < Sav.play_normal_cards.Count; i++)
            //pl_nc.Add(new Normal_Card(Sav.play_normal_cards[i]));
            pl_nc.Add(CDDB.get_normal_card_detail(Sav.play_normal_cards[i], "GameScene"));

        //設定要上場的卡牌
        play_card.set_play_card(CDDB.get_leader_card_detail(Sav.play_leader_card, "GameScene"), pl_nc);

        print("Load" + "GameScene讀檔成功。");
    }


    //===========================================================================================
    //Function(內部)
    //===========================================================================================

}
