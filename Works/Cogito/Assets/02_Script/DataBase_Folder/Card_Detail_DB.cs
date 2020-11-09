/*
 * Normal_Card、Leader_Card 的基本資料庫(名稱、學派.....)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Detail_DB : MonoBehaviour
{
    //===========================================================================================
    //MVC
    //===========================================================================================

    //Control_Manage_Script:CMS
    public Control_Manage_Script CMS;


    //Control_Game_Script:CGS
    public Control_Game_Script CGS;

    //===========================================================================================
    //Variable
    //===========================================================================================

    //領導卡牌 name
    private string[] leader_name = new string[] {
        "陬邑子",
        "聃苦",
        "路易斐多",
        "圖爾",
        "悠閒",
        "權威"
    };

    //領導卡牌 description
    private string[] leader_description = new string[] {
        "踏實天下，不做浮誇不實的事情而違逆【正道】，不違仁、不違義。",
         "騎牛說書，想理解天。",
         "賢者也許是一個貶抑的頭銜，但是我依然繼續向前，問題並不需要答案，可是需要一個問題來回答。",
         "世界是由兩種獨立的元素所組成，身體和靈魂，我一直試圖理解它們，但我卻無法同時擁有兩者。",
         "相信人們可以依照思想和善良，去對待每一個人，沒有私心的世界。",
         "人們普通的活在世上，只能用準則來控制，人不會一直保持秩序。"
    };

    private void Awake()
    {
       
    }

    //===========================================================================================
    //Function(外部)
    //===========================================================================================

    // 取得 Normal_Card 基本資料，(id:卡牌id，scenename:場景名稱)
    public Normal_Card get_normal_card_detail(int id,string scenename)
    {
        switch (scenename)
        {
            case "ManageScene":
                return get_ManageScene_normal(id);
            case "GameScene":
                return get_GameScene_normal(id);
            default:
                print("Error");
                return null;
               
        }
        
    }

    // 取得 Leader_Card 基本資料，(id:卡牌id，scenename:場景名稱)
    public Leader_Card get_leader_card_detail(int id, string scenename)
    {
        switch (scenename)
        {
            case "ManageScene":
                return get_ManageScene_leader(id);
            case "GameScene":
                return get_GameScene_leader(id);
            default:
                print("Error");
                return null;
        }
        
    }




    //===========================================================================================
    //Function(內部)
    //===========================================================================================

    //================
    //Normal，(id:卡牌id)，(ManageScene)
    //================
    private Normal_Card get_ManageScene_normal(int id)
    {
        switch (id)
        {
            case 0:
                return new Normal_Card(0, "零", "學宮", CMS.VMS.VMDB.get_normalcard_headshot(0), "getgraychip", 2, false);
            case 1:
                return new Normal_Card(1, "一", "哲學家", CMS.VMS.VMDB.get_normalcard_headshot(1), "getgraychip", 1, false);
            case 2:
                return new Normal_Card(2, "二", "分裂者", CMS.VMS.VMDB.get_normalcard_headshot(2), "lockownchip", 2, true);
            case 3:
                return new Normal_Card(3, "三", "哲學家", CMS.VMS.VMDB.get_normalcard_headshot(3), "lockownchip", 1, true);
            case 4:
                return new Normal_Card(4, "四", "哲學家", CMS.VMS.VMDB.get_normalcard_headshot(4), "getgraychip", 4, false);
            case 5:
                return new Normal_Card(5, "五", "學宮", CMS.VMS.VMDB.get_normalcard_headshot(5), "getgraychip", 3, false);
            default:
                return new Normal_Card(0, "零", "學宮", CMS.VMS.VMDB.get_normalcard_headshot(0), "getgraychip", 2, false); 
        }
    }

    //================
    //Leader，(id:卡牌id)，(ManageScene)
    //================
    private Leader_Card get_ManageScene_leader(int id)
    {
        switch (id)
        {
            case 0:
                return new Leader_Card(0, leader_name[0], "學宮", CMS.VMS.VMDB.get_leadercard_headshot(0), "getgraychip", 5, leader_description[0]);
            case 1:
                return new Leader_Card(1, leader_name[1], "學宮", CMS.VMS.VMDB.get_leadercard_headshot(1), "lockownchip", 3, leader_description[1]);
            case 2:
                return new Leader_Card(2, leader_name[2], "哲學家", CMS.VMS.VMDB.get_leadercard_headshot(2), "getoppositechip", 3, leader_description[2]);
            case 3:
                return new Leader_Card(3, leader_name[3], "哲學家", CMS.VMS.VMDB.get_leadercard_headshot(3), "addcard", 2, leader_description[3]);
            case 4:
                return new Leader_Card(4, leader_name[4], "分裂者", CMS.VMS.VMDB.get_leadercard_headshot(4), "backgraychip", 4, leader_description[4]);
            case 5:
                return new Leader_Card(5, leader_name[5], "分裂者", CMS.VMS.VMDB.get_leadercard_headshot(5), "addcard", 2, leader_description[5]);
            default:
                return new Leader_Card(0, leader_name[0], "學宮", CMS.VMS.VMDB.get_leadercard_headshot(0), "getgraychip", 5, leader_description[0]);
        }
    }

    //================
    //Normal，(id:卡牌id)，(GameScene)
    //================
    private Normal_Card get_GameScene_normal(int id)
    {
       
        switch (id)
        {
            case 0:
                return new Normal_Card(0, "零", "學宮", CGS.VGS.VGDB.get_normalcard_headshot(0), "getgraychip", 2, false);
            case 1:
                return new Normal_Card(1, "一", "哲學家", CGS.VGS.VGDB.get_normalcard_headshot(1), "getgraychip", 1, false);
            case 2:
                return new Normal_Card(2, "二", "分裂者", CGS.VGS.VGDB.get_normalcard_headshot(2), "lockownchip", 2, true);
            case 3:
                return new Normal_Card(3, "三", "哲學家", CGS.VGS.VGDB.get_normalcard_headshot(3), "lockownchip", 1, true);
            case 4:
                return new Normal_Card(4, "四", "哲學家", CGS.VGS.VGDB.get_normalcard_headshot(4), "getgraychip", 4, false);
            case 5:
                return new Normal_Card(5, "五", "學宮", CGS.VGS.VGDB.get_normalcard_headshot(5), "getgraychip", 3, false);
            default:
                return new Normal_Card(0, "零", "學宮", CGS.VGS.VGDB.get_normalcard_headshot(0), "getgraychip", 2, false);
        }
    }

    //================
    //Leader，(id:卡牌id)，(GameScene)
    //================
    private Leader_Card get_GameScene_leader(int id)
    {
        switch (id)
        {
            case 0:
                return new Leader_Card(0, leader_name[0], "學宮", CGS.VGS.VGDB.get_leadercard_headshot(0), "getgraychip", 5, leader_description[0]);
            case 1:
                return new Leader_Card(1, leader_name[1], "學宮", CGS.VGS.VGDB.get_leadercard_headshot(1), "getgraychip", 3, leader_description[1]);
            case 2:
                return new Leader_Card(2, leader_name[2], "哲學家", CGS.VGS.VGDB.get_leadercard_headshot(2), "getgraychip", 3, leader_description[2]);
            case 3:
                return new Leader_Card(3, leader_name[3], "哲學家", CGS.VGS.VGDB.get_leadercard_headshot(3), "getgraychip", 2, leader_description[3]);
            case 4:
                return new Leader_Card(4, leader_name[4], "分裂者", CGS.VGS.VGDB.get_leadercard_headshot(4), "getgraychip", 4, leader_description[4]);
            case 5:
                return new Leader_Card(5, leader_name[5], "分裂者", CGS.VGS.VGDB.get_leadercard_headshot(5), "getgraychip", 2, leader_description[5]);
            default:
                return new Leader_Card(0, leader_name[0], "學宮", CGS.VGS.VGDB.get_leadercard_headshot(0), "getgraychip", 5, leader_description[0]);
        }
    }


    /*
     *  nc.Add(new Normal_Card(0, "一", "學宮", CMS.VMS.VMDB.get_normalcard_headshot(0), "getgraychip", 2, false));
        nc.Add(new Normal_Card(1, "二", "哲學家", CMS.VMS.VMDB.get_normalcard_headshot(1), "getgraychip", 1, false));
        nc.Add(new Normal_Card(1, "三", "哲學家", CMS.VMS.VMDB.get_normalcard_headshot(1), "getgraychip", 1, false));
        nc.Add(new Normal_Card(2, "四", "分裂者", CMS.VMS.VMDB.get_normalcard_headshot(2), "addgraychip", 2, true));
        nc.Add(new Normal_Card(5, "五", "學宮", CMS.VMS.VMDB.get_normalcard_headshot(5), "getgraychip", 3, false));
        nc.Add(new Normal_Card(4, "六", "哲學家", CMS.VMS.VMDB.get_normalcard_headshot(4), "getgraychip", 4, false));
        nc.Add(new Normal_Card(2, "七", "分裂者", CMS.VMS.VMDB.get_normalcard_headshot(2), "addgraychip", 2, true));
        nc.Add(new Normal_Card(2, "八", "分裂者", CMS.VMS.VMDB.get_normalcard_headshot(2), "addgraychip", 2, true));
     */

    /*
     * lc.Add(new Leader_Card(0, "義晴_1", "學宮", CMS.VMS.VMDB.get_leadercard_headshot(0), "getgraychip", 3));
        lc.Add(new Leader_Card(1, "義晴_2", "學宮", CMS.VMS.VMDB.get_leadercard_headshot(1), "getgraychip", 3));
        lc.Add(new Leader_Card(2, "行情_1", "哲學家", CMS.VMS.VMDB.get_leadercard_headshot(2), "getgraychip", 2));
        lc.Add(new Leader_Card(3, "行情_2", "哲學家", CMS.VMS.VMDB.get_leadercard_headshot(3), "getgraychip", 2));
        lc.Add(new Leader_Card(4, "咪麻賣_1", "分裂者", CMS.VMS.VMDB.get_leadercard_headshot(4), "getgraychip", 2));
        lc.Add(new Leader_Card(5, "咪麻賣_2", "分裂者", CMS.VMS.VMDB.get_leadercard_headshot(5), "getgraychip", 2));
     */

}
