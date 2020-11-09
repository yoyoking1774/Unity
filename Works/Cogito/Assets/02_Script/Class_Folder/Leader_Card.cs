/*
 * 領導卡牌，繼承Card
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader_Card : Card
{
    //======================================
    //Attribute
    //======================================
    //string:領導卡牌描述
    private string description;

    //======================================
    //(Default)Constructor
    //======================================
    public Leader_Card()
    {
        set_id(0);
        set_name("大帝");
        set_soc("哲學家");
        set_headshot(null);
        set_ability("getgraychip");
        set_ability_number(2);
        set_description("-------");
    }

    //======================================
    //(Value)Constructor
    //======================================
    public Leader_Card(int id, string name = "大帝", string soc = "哲學家", Sprite headshot = null, string ability= "getgraychip", int ability_number = 2, string description = "-------")
    {
        set_id(id);
        set_name(name);
        set_soc(soc);
        set_headshot(headshot);
        set_ability(ability);
        set_ability_number(ability_number);
        set_description(description);
    }

    //======================================
    //(Value)Constructor
    //======================================
    public Leader_Card(Leader_Card leader_card)
    {
        set_id(leader_card.get_id());
        set_name(leader_card.get_name());
        set_soc(leader_card.get_soc());
        set_headshot(leader_card.get_headshot());
        set_ability(leader_card.get_ability());
        set_ability_number(leader_card.get_ability_number());
        set_description(leader_card.get_description());
    }


    //======================================
    //Getter
    //======================================

    //description
    public string get_description()
    {
        return description;
    }

    //======================================
    //Setter
    //======================================

    //Leader_Card
    public void set_leader_card(Leader_Card leader_card)
    {
        set_id(leader_card.get_id());
        set_name(leader_card.get_name());
        set_soc(leader_card.get_soc());
        set_headshot(leader_card.get_headshot());
        set_ability(leader_card.get_ability());
        set_ability_number(leader_card.get_ability_number());
        set_description(leader_card.get_description());
    }

    //description
    public void set_description(string description)
    {
        this.description = description;
    }











}
