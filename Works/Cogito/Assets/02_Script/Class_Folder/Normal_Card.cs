/*
 * 普通卡牌，分為一般卡牌、傳說卡牌，繼承Card
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_Card : Card
{
    //======================================
    //Attribute
    //======================================
    //bool:是否為傳說卡牌，true: 傳說卡牌 false:一般卡牌
    private bool islegend;


    //======================================
    //(Default)Constructor
    //======================================
    public Normal_Card()
    {
        set_id(0);
        set_name("亞特拉大帝");
        set_soc("哲學家");
        set_headshot(null);
        set_ability("getgraychip");
        set_ability_number(2);
        set_islegend(false);
    }

    //======================================
    //(Value)Constructor
    //======================================
    public Normal_Card(int id , string name = "亞特拉大帝", string soc = "哲學家", Sprite headshot = null, string ability = "getgraychip", int ability_number = 2 , bool islegend = false)
    {
        set_id(id);
        set_name(name);
        set_soc(soc);
        set_headshot(headshot);
        set_ability(ability);
        set_ability_number(ability_number);
        set_islegend(islegend);
    }

    //======================================
    //(Value)Constructor
    //======================================
    public Normal_Card(Normal_Card normal_card)
    {
        set_id(normal_card.get_id());
        set_name(normal_card.get_name());
        set_soc(normal_card.get_soc());
        set_headshot(normal_card.get_headshot());
        set_ability(normal_card.get_ability());
        set_ability_number(normal_card.get_ability_number());
        set_islegend(normal_card.get_islegend());
    }

    //======================================
    //Getter
    //======================================

    //islegend
    public bool get_islegend()
    {
        return islegend;
    }

    //======================================
    //Setter
    //======================================

    //Normal_Card
    public void set_normal_card(Normal_Card normal_card)
    {
        set_id(normal_card.get_id());
        set_name(normal_card.get_name());
        set_soc(normal_card.get_soc());
        set_headshot(normal_card.get_headshot());
        set_ability(normal_card.get_ability());
        set_ability_number(normal_card.get_ability_number());
        set_islegend(normal_card.get_islegend());
    }


    //islegend
    public void set_islegend(bool islegend)
    {
        this.islegend = islegend;
    }

  

}
