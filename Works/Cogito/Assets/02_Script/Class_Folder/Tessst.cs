using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tessst : MonoBehaviour
{

    //Normal_Card nc = new Normal_Card(0 , "亞特拉大帝" , "哲學家" , null , "getgraychip" , 2 , false);
    List<Normal_Card> nc;
    List<Normal_Card> pl_nc;
    List<Leader_Card> lc;
    Own_cards ow;
    Play_cards pl;
    Player play;

    int i, j;

    
    //Legend_Card lc = new Legend_Card();
    // Start is called before the first frame update
    void Start()
    {

        nc = new List<Normal_Card>();
        nc.Add(new Normal_Card(0, "一", "哲學家", null, "getgraychip", 2, false));
        nc.Add(new Normal_Card(1, "二", "哲學家", null, "getgraychip", 2, false));
        nc.Add(new Normal_Card(1, "三", "哲學家", null, "getgraychip", 2, false));
        nc.Add(new Normal_Card(2, "四", "哲學家", null, "getgraychip", 2, false));
        nc.Add(new Normal_Card(5, "五", "哲學家", null, "getgraychip", 2, false));
        nc.Add(new Normal_Card(4, "六", "哲學家", null, "getgraychip", 2, false));
        nc.Add(new Normal_Card(2, "七", "哲學家", null, "getgraychip", 2, false));
        nc.Add(new Normal_Card(2, "八", "哲學家", null, "getgraychip", 2, false));


        pl_nc = new List<Normal_Card>();


        lc = new List<Leader_Card>();
        lc.Add(new Leader_Card(0, "咪麻賣", "分裂者", null, "getgraychip", 2));
        lc.Add(new Leader_Card(1, "義晴", "學宮", null, "getgraychip", 3));
        lc.Add(new Leader_Card(2, "行情", "哲學家", null, "getgraychip", 2));


        ow = new Own_cards(lc, nc);

        pl = new Play_cards(null, pl_nc);

        play = new Player(ow, pl);


        /*
        * Remove card
       int Temp;
       Temp = nc.FindIndex(xa => xa.get_id() == 5);
       nc.RemoveAt(Temp);

       for (i = 0; i < nc.Count; i++)
       {
           print(nc[i].get_name());
       }
       print("---------------------");
       nc.Add(new Normal_Card(5, "五", "哲學家", null, "getgraychip", 2, false));
       for (i = 0; i < nc.Count; i++)
       {
           print(nc[i].get_name());
       }
       */


        /*
        //交換卡牌

         Normal_Card Temp = new Normal_Card(1, "八", "哲學家", null, "getgraychip", 2, false);
         pl_nc.Add(new Normal_Card(2, "八", "哲學家", null, "getgraychip", 2, false));
         pl_nc.Add(new Normal_Card(1, "六", "哲學家", null, "getgraychip", 2, false));

         List<Normal_Card> Temp_nc = play.get_own_card().get_all_normal_card();

         for (i = 0; i < play.get_own_card().get_all_normal_card().Count; i++) {
             print(Temp_nc[i].get_name());
         }

         play.do_change_card(Temp,1);

         print("改變後---------------");

         Temp_nc = play.get_own_card().get_all_normal_card();

         for (i = 0; i < play.get_own_card().get_all_normal_card().Count; i++)
         {
             print(Temp_nc[i].get_name());
         }
         */
        //create_card();
    }

    /*
    public void create_card()
    {
        for (i = 1; i <= 15; i++) Instantiate(card,content.transform);
    }
    */
    /*
    public void bbb(GameObject gameObject)
    {
        print(gameObject.GetComponent<Normal_Card>().get_name());
    }
    */

}
