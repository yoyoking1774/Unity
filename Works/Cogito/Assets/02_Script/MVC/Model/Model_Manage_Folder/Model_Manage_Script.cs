/*
 * (Model)MVC : ManageScene
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Model_Manage_Script : MonoBehaviour
{



    //===========================================================================================
    //MVC
    //===========================================================================================

    //Control_Manage_Script:CMS
    public Control_Manage_Script CMS;

    //Model_Begin_Script:MBS
    public Model_Begin_Script MBS;

    //Model_EditCard_Script:MES
    public Model_EditCard_Script MES;

    //LoadScene_Script:LSS
    public LoadScene_Script LSS;

    //===========================================================================================
    //Variable
    //===========================================================================================

    //SaveGame_Class : 存檔
    private GameSave gamesave = new GameSave();

    //Player:player
    private Player player;

    private List<Normal_Card> nc;
    private List<Normal_Card> pl_nc;
    private List<Leader_Card> lc;
    private Own_cards ow = new Own_cards();
    private  Play_cards pl = new Play_cards();

    //==================
    //迴圈用
    //==================
    int i, j;

    //==================
    //State
    //==================

    //int : 現在頁面，預設1表示總體頁面
    private int now_page = 2;


    //===========================================================================================
    //Awake
    //===========================================================================================
    private void Awake()
    {
        /*nc = new List<Normal_Card>();
        nc.Add(new Normal_Card(0, "一", "學宮", CMS.VMS.VMDB.get_normalcard_headshot(0), "getgraychip", 2, false));
        nc.Add(new Normal_Card(1, "二", "哲學家", CMS.VMS.VMDB.get_normalcard_headshot(1), "getgraychip", 1, false));
        nc.Add(new Normal_Card(1, "三", "哲學家", CMS.VMS.VMDB.get_normalcard_headshot(1), "getgraychip", 1, false));
        nc.Add(new Normal_Card(2, "四", "分裂者", CMS.VMS.VMDB.get_normalcard_headshot(2), "addgraychip", 2, true));
        nc.Add(new Normal_Card(5, "五", "學宮", CMS.VMS.VMDB.get_normalcard_headshot(5), "getgraychip", 3, false));
        nc.Add(new Normal_Card(4, "六", "哲學家", CMS.VMS.VMDB.get_normalcard_headshot(4), "getgraychip", 4, false));
        nc.Add(new Normal_Card(2, "七", "分裂者", CMS.VMS.VMDB.get_normalcard_headshot(2), "addgraychip", 2, true));
        nc.Add(new Normal_Card(2, "八", "分裂者", CMS.VMS.VMDB.get_normalcard_headshot(2), "addgraychip", 2, true));


        pl_nc = new List<Normal_Card>();
        pl_nc.Add(new Normal_Card(0, "一", "哲學家", CMS.VMS.VMDB.get_normalcard_headshot(0), "getgraychip", 2, false));
        pl_nc.Add(new Normal_Card(1, "二", "哲學家", CMS.VMS.VMDB.get_normalcard_headshot(1), "getgraychip", 2, false));
        pl_nc.Add(new Normal_Card(1, "三", "哲學家", CMS.VMS.VMDB.get_normalcard_headshot(1), "getgraychip", 2, false));
        pl_nc.Add(new Normal_Card(7, "四", "哲學家", CMS.VMS.VMDB.get_normalcard_headshot(7), "getgraychip", 2, false));
        
        lc = new List<Leader_Card>();
        lc.Add(new Leader_Card(0, "義晴_1", "學宮", CMS.VMS.VMDB.get_leadercard_headshot(0), "getgraychip", 3));
        lc.Add(new Leader_Card(1, "義晴_2", "學宮", CMS.VMS.VMDB.get_leadercard_headshot(1), "getgraychip", 3));
        lc.Add(new Leader_Card(2, "行情_1", "哲學家", CMS.VMS.VMDB.get_leadercard_headshot(2), "getgraychip", 2));
        lc.Add(new Leader_Card(3, "行情_2", "哲學家", CMS.VMS.VMDB.get_leadercard_headshot(3), "getgraychip", 2));
        lc.Add(new Leader_Card(4, "咪麻賣_1", "分裂者", CMS.VMS.VMDB.get_leadercard_headshot(4), "getgraychip", 2));
        lc.Add(new Leader_Card(5, "咪麻賣_2", "分裂者", CMS.VMS.VMDB.get_leadercard_headshot(5), "getgraychip", 2));
        */

        nc = new List<Normal_Card>();
        pl_nc = new List<Normal_Card>();
        lc = new List<Leader_Card>();

        ow = new Own_cards(lc, nc);

        pl = new Play_cards(new Leader_Card(0), pl_nc);
        
        //存檔初始化
        gamesave.ini(nc, pl_nc, lc);
        //讀檔
        gamesave.DoLoad_ManageScene(ow, pl);

        player = new Player(ow, pl);

       

        //更新View，一次修改一次修改BeginBase...在內所有頁面到畫面外
        CMS.VMS.set_AllManageBasePosition(100.0f, 0.0f, 0.0f);
        //更新View，一次修改Begin頁面到畫面中
        CMS.VMS.set_AllBeginPosition(0.0f, 0.0f, 0.0f);
        //更新View，領導卡牌資訊
        CMS.VMS.VES.set_editcardleader_information(player.get_own_card().get_leader_card(player.get_play_card().get_leader_card().get_id()));

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) gamesave.DoSave_ManageScene(player.get_own_card(), player.get_play_card());
    }


    //======================================================
    //Function(Button)
    //======================================================

    //============
    //(Button)返回
    //============
    public void back_now_page()
    {
        //依照現在狀態，決定返回編號
        switch (now_page)
        {
            //EditCard、GameSelect、Manual頁面 返回到 Begin頁面
            case 2:
            case 3:
            case 4:
                {
                    now_page = 1;
                    break;
                }
            //EditCardLeaderCanvas 返回到 EditCard頁面
            case 5:
                {
                    now_page = 2;
                    break;
                }
            //預設
            default:
                {
                    now_page = 1;
                    break;
                }


        }//switch

        //切換狀態後，更新backbutton
        set_backbutton();

        //切換狀態後，更新View的Position
        set_nowposition();
    }


    //============
    //(Button)存檔
    //============

    public void do_save()
    {
        gamesave.DoSave_ManageScene(player.get_own_card(), player.get_play_card());
    }

    //===========================================================================================
    //Function(外部)
    //===========================================================================================

    //==================
    //設定現在狀態編號(id : 狀態編號)
    //==================
    public void set_now_page(int id)
    {
        now_page = id;

        //存檔
        gamesave.DoSave_ManageScene(player.get_own_card(), player.get_play_card());

        //切換狀態後，設定BackButton
        set_backbutton();

        //切換狀態後，更新View的Position
        set_nowposition();
    }

    //==================
    //取得現在狀態編號
    //==================
    public int get_now_page()
    {
        return now_page; 
    }


    //======================================================
    //Function(內部)
    //======================================================

    //============
    //切換狀態後，更新View的Position
    //============
    private void set_nowposition()
    {
        //更新View，一次修改一次修改BeginBase...在內所有頁面到畫面外
        CMS.VMS.set_AllManageBasePosition(100.0f, 0.0f, 0.0f);
        //更新View，一次修改EditCardLeaderCanvas畫面外
        CMS.VMS.set_EditCardLeaderCanvasPosition(false);

        //依照現在狀態，決定顯示頁面
        switch (now_page)
        {
            case 1:
                {
                    //更新View，一次修改Begin頁面到畫面中
                    CMS.VMS.set_AllBeginPosition(0.0f, 0.0f, 0.0f);
                    break;
                }

            case 2:
                {
                    //更新View，一次修改EditCard頁面到畫面中
                    CMS.VMS.set_AllEditCardPosition(0.0f, 0.0f, 0.0f);
                    break;
                }

            case 3:
                {
                    //更新View，一次修改GameSelect頁面到畫面中(這裡先註解掉，用於測試載入GameScene)
                    //CMS.VMS.set_AllGameSelectPosition(0.0f, 0.0f, 0.0f);
                    //切換到GameScene
                    LSS.LoadScene("GameScene");
                    break;
                }

            case 4:
                {
                    //更新View，一次修改Manual頁面到畫面中
                    CMS.VMS.set_AllManualPosition(0.0f, 0.0f, 0.0f);
                    break;
                }
            case 5:
                {
                    //更新View，一次修改EditCardLeader頁面到畫面中
                    CMS.VMS.set_AllEditCardPosition(0.0f, 0.0f, 0.0f);
                    //更新View，一次修改EditCardLeaderCanvas畫面中
                    CMS.VMS.set_EditCardLeaderCanvasPosition(true);
                    break;
                }

        }//switch
    }

    //============
    //切換狀態後，設定BackButton
    //============
    private void set_backbutton()
    {
       //除了總體頁面，其它都是開啟BackButton
        if (now_page == 1)
        {
            //關閉BackButton
            CMS.VMS.set_back_button_interactable(false);
        }
        else
        {
            //開啟BackButton
            CMS.VMS.set_back_button_interactable(true);
        }
        
    }

    

    //======================================
    //Getter
    //======================================

    //player
    public Player get_player()
    {
        return player;
    }

    


}
