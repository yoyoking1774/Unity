/*
 * 抽象類別
 * 給Leader_Card、Normal_Card兩個子類別繼承
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    //======================================
    //Attribute
    //======================================

    //int: 卡牌的編號
    private int id;
    //string: 卡牌的名稱
    private string name;
    //string: 卡牌的學派
    private string soc;
    //Sprite: 卡牌的大頭照
    private Sprite headshot;
    //string: 卡牌的能力
    private string ability;
    //int: 卡牌的能力倍率
    private int ability_number;



    //======================================
    //Getter
    //======================================

    //id
    public int get_id()
    {
        return id;
    }

    //name
    public string get_name()
    {
        return name;
    }

    //soc
    public string get_soc()
    {
        return soc;
    }

    //headshot
    public Sprite get_headshot()
    {
        return headshot;
    }

    //ability
    public string get_ability()
    {
        return ability;
    }

    //ability_number
    public int get_ability_number()
    {
        return ability_number;
    }

    //======================================
    //Setter
    //======================================

    //id
    public void set_id(int id)
    {
        this.id = id;
    }

    //name
    public void set_name(string name)
    {
        this.name = name;
    }

    //soc
    public void set_soc(string soc)
    {
        this.soc = soc;
    }

    //headshot
    public void set_headshot(Sprite headshot)
    {
        this.headshot = headshot;
    }


    //ability
    public void set_ability(string ability)
    {
        this.ability = ability;
    }

    //ability_number
    public void set_ability_number(int ability_number)
    {
        this.ability_number = ability_number;
    }

}
