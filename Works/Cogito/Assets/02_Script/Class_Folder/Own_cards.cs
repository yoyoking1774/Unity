/*
 * 擁有的卡牌
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Own_cards : MonoBehaviour, IChange_cards
{
    //======================================
    //Attribute
    //======================================

    //Leader_Card: 領導卡牌
    private List<Leader_Card> leader_cards;
    //Dictionary<string(編號), int(數量)>: 領導卡牌種類和數量
    private Dictionary<string, int> leader_cards_number;

    //Normal_Card: 普通卡牌
    private List<Normal_Card> normal_cards;
    //Dictionary<string(編號), int(數量)>: 普通卡牌種類和數量
    private Dictionary<string, int> normal_cards_number;

    //======================================
    //(Default)Constructor
    //======================================
    public Own_cards() {
        this.leader_cards = new List<Leader_Card>();
        this.leader_cards_number = new Dictionary<string, int>();

        this.normal_cards = new List<Normal_Card>();
        this.normal_cards_number = new Dictionary<string, int>();

    }

    //======================================
    //(Value)Constructor
    //======================================
    public Own_cards(List<Leader_Card> leader_cards, List<Normal_Card> normal_cards)
    {
        this.leader_cards = leader_cards;
        this.leader_cards_number = new Dictionary<string, int>();
        intcount_leader_cards_number();

        this.normal_cards = normal_cards;
        this.normal_cards_number = new Dictionary<string, int>();
        inicount_normal_cards_number();

    }


    //======================================
    //Function
    //======================================


    //初始化卡牌種類和數量
    public void call_intcount()
    {
        intcount_leader_cards_number();
        inicount_normal_cards_number();
    }

    //================
    //初始化領導卡牌種類和數量
    //================
    private void intcount_leader_cards_number()
    {
        int i, j;

        for (i = 0; i < leader_cards.Count; i++)
        {
            //如果leader_cards_number已存在卡片編號，則依編號將數量 + 1
            if (leader_cards_number.ContainsKey(leader_cards[i].get_id().ToString())) leader_cards_number[leader_cards[i].get_id().ToString()]++;
            //否則新增卡片編號欄位，並設數量為1
            else leader_cards_number.Add(leader_cards[i].get_id().ToString(), 1);
        }
    }

    //================
    //初始化普通卡牌種類和數量
    //================
    private void inicount_normal_cards_number()
    {
        int i, j;

        for (i = 0; i < normal_cards.Count; i++) {
            //如果normal_cards_number已存在卡片編號，則依編號將數量 + 1
            if (normal_cards_number.ContainsKey(normal_cards[i].get_id().ToString())) normal_cards_number[normal_cards[i].get_id().ToString()]++; 
            //否則新增卡片編號欄位，並設數量為1
            else normal_cards_number.Add(normal_cards[i].get_id().ToString(), 1);
        }
    }


    //================
    //重新計算普通卡牌種類和數量
    //================
    private void recount_normal_cards_number(string id, int value)
    {
        //如果normal_cards_number已存在卡片編號，則依編號將數量 + 1
        if (normal_cards_number.ContainsKey(id)) normal_cards_number[id] = normal_cards_number[id] + value;
        //否則新增卡片編號欄位，並設數量為1
        else normal_cards_number.Add(id, 1);
    }


    //================
    //搜尋Leader_Card
    //================
    private Leader_Card find_leader_card(int id)
    {
        int i, j;

        for (i = 0; i < leader_cards.Count; i++)
        {
            if (leader_cards[i].get_id() == id)  return leader_cards[i]; 
        }

        return null;
    }


    //================
    //搜尋Noraml_Card
    //================
    private Normal_Card find_normal_card(int id) {

        int i, j;

        for (i = 0; i < normal_cards.Count; i++)
        {
            if (normal_cards[i].get_id() == id) return normal_cards[i];
        }
   
        return null;
    }


    //================
    //判斷是否要新增一個normal_card_object
    //================
    private bool judge_create_normal_card_object(GameObject normal_card_object)
    {
        //如果normal_cards_number沒有此id存在，則新增normal_card_object
        if (normal_cards_number.ContainsKey(normal_card_object.GetComponent<Normal_Card>().get_id().ToString()) == false) return true;
        //如果normal_cards_number有此id存在，但value==0，則新增normal_card_object
        else if (normal_cards_number[normal_card_object.GetComponent<Normal_Card>().get_id().ToString()] == 0) return true;

        //預設回傳false
        return false;
    }


    //================
    //判斷是否要移除一個normal_card_object
    //================
    private bool judge_remove_normal_card_object(GameObject normal_card_object)
    {
        //如果normal_cards_number有此id存在，且value==1，則移除normal_card_object，因為要先新增，才能移除，所以一定有Key存在。
        if (normal_cards_number[normal_card_object.GetComponent<Normal_Card>().get_id().ToString()] == 1) return true;

        //預設回傳false
        return false;
    }


    //======================================
    //(interface)IChange_cards
    //======================================

    //================
    //新增nomal card
    //================
    public void add_nomal_card(GameObject normal_card_object, GameObject editowncard_content)
    {
        //用於設定新建的normal_cards
        GameObject temp_own;

        //如果play_card沒有此卡牌存在，則新增一個normal_card_object       
        if (judge_create_normal_card_object(normal_card_object))
        {
            //建立normal_cards
            temp_own = Instantiate(normal_card_object, editowncard_content.transform);
            //設定新建的normal_cards的內容
            temp_own.GetComponent<Normal_Card>().set_normal_card(normal_card_object.GetComponent<Normal_Card>());
            //設定name
            temp_own.name = normal_card_object.GetComponent<Normal_Card>().get_id().ToString();
        }

        //新增normal card
        normal_cards.Add(normal_card_object.GetComponent<Normal_Card>());
        //重新計算普通卡牌種類和數量
        recount_normal_cards_number(normal_card_object.GetComponent<Normal_Card>().get_id().ToString(), 1);


       
    }

    //================
    //移除nomal card
    //================
    public void remove_nomal_card(GameObject normal_card_object)
    {
        
        //移除normal_card_object
        if (judge_remove_normal_card_object(normal_card_object)) Destroy(normal_card_object);

        //暫存要移除的card在normal_cards的index
        int Temp;
        //找出index
        Temp = normal_cards.FindIndex(nc => nc.get_id() == normal_card_object.GetComponent<Normal_Card>().get_id());  
        //依照index移除normal_cards中的card
        normal_cards.RemoveAt(Temp);
        //重新計算普通卡牌種類和數量
        recount_normal_cards_number(normal_card_object.GetComponent<Normal_Card>().get_id().ToString(), -1);
        
    }



    //======================================
    //Getter
    //======================================

    //一張leader_cards
    public Leader_Card get_leader_card(int id) {
        return find_leader_card(id);
    }

    //全部leader_cards
    public List<Leader_Card> get_all_leader_card()
    {
        return leader_cards;
    }

    //leader_cards_number
    public Dictionary<string, int> get_leader_cards_number()
    {
        return leader_cards_number;
    }

    //一張normal_card
    public Normal_Card get_normal_card(int id) {
        return find_normal_card(id);
    }

    //全部normal_cards
    public List<Normal_Card> get_all_normal_card()
    {
        return normal_cards;
    }

    //normal_cards_number
    public Dictionary<string, int> get_normal_cards_number()
    {
        return normal_cards_number;
    }


    //======================================
    //Setter
    //======================================

    //own card
    public void set_own_card(List<Leader_Card> leader_cards, List<Normal_Card> normal_cards)
    {
        this.leader_cards = leader_cards;
        leader_cards_number.Clear();
        intcount_leader_cards_number();

        this.normal_cards = normal_cards;
        normal_cards_number.Clear();
        inicount_normal_cards_number();

    }

    //全部leader_cards
    public void set_all_leader_card(List<Leader_Card> leader_cards)
    {
        this.leader_cards = leader_cards;
    }

    //leader_cards_number
    public void set_leader_cards_number(Dictionary<string, int> leader_cards_number)
    {
        this.leader_cards_number = leader_cards_number;
    }

    //全部normal_cards
    public void set_all_normal_cards(List<Normal_Card> normal_cards)
    {
        this.normal_cards = normal_cards;
    }

    //normal_cards_number
    public void set_normal_cards_number(Dictionary<string, int> normal_cards_number)
    {
        this.normal_cards_number = normal_cards_number;
    }






}
