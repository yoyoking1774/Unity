/*
 * 玩家
 * Own_cards、Play_cards is part of Player 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //======================================
    //Attribute
    //======================================

    //Own_cards: 玩家擁有的卡牌
    private Own_cards own_card;

    //Play_cards: 玩家上場的卡牌
    private Play_cards play_card;

    //string:玩家名稱
    private string name;

    //Sprite:大頭照
    private Sprite headshot;

    //======================================
    //(Default)Constructor
    //======================================
    public Player()
    {
        this.own_card = new Own_cards();
        this.play_card = new Play_cards();
        this.name = "empty";
        this.headshot = null;
    }


    //======================================
    //(Value)Constructor
    //======================================
    public Player(Own_cards own_card, Play_cards play_card , string name= "empty", Sprite headshot=null)
    {
        this.own_card = own_card;
        this.play_card = play_card;
        this.name = name;
        this.headshot = headshot;
    }



    //======================================
    //Function
    //======================================

    //================
    //交換卡牌(到play_card)(normal_card_object:要交換的卡牌 , editplaycard_content:新增到editplaycard_content底下)
    //================
    public void do_change_normal_card_to_play(GameObject normal_card_object, GameObject editplaycard_content)
    {
        play_card.add_nomal_card(normal_card_object, editplaycard_content);
        own_card.remove_nomal_card(normal_card_object);        
    }

    //================
    //交換卡牌(到own_card)(normal_card_object:要交換的卡牌 , editowncard_content:新增到editplaycard_content底下)
    //================
    public void do_change_normal_card_to_own(GameObject normal_card_object, GameObject editowncard_content)
    {        
        own_card.add_nomal_card(normal_card_object , editowncard_content);
        play_card.remove_nomal_card(normal_card_object);
    }


    //======================================
    //Getter
    //======================================

    //own_card
    public Own_cards get_own_card()
    {
        return own_card;
    }

    //play_card
    public Play_cards get_play_card()
    {
        return play_card;
    }

    //name
    public string get_name()
    {
        return name;
    }

    //headshot
    public Sprite get_headshot()
    {
        return headshot;
    }

    //======================================
    //Setter
    //======================================

    //設定leader_card
    public void set_leader_card(int id)
    {
        play_card.set_leader_card(own_card.get_leader_card(id));
    }

    //name
    public void set_name(string name)
    {
        this.name = name;
    }

    //headshot
    public void set_headshot(Sprite headshot)
    {
        this.headshot = headshot;
    }

}
