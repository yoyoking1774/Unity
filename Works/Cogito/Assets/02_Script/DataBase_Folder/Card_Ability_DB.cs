/*
 * Normal_Card、Leader_Card 的能力資料庫
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Ability_DB : MonoBehaviour
{
    //===========================================================================================
    //MVC
    //===========================================================================================


    //===========================================================================================
    //Variable
    //===========================================================================================





    //===========================================================================================
    //Function(外部)
    //===========================================================================================

    //取得普通、傳說卡牌能力(islegend:是否為傳說卡牌 , ability : 能力名稱)
    public string get_normal_ablity(bool islegend, string ability)
    {
        string card_ability;

        if (islegend == true)
            card_ability = distribute_legend_ability(ability);

        else
            card_ability = distribute_normal_ability(ability);
       
        return card_ability;
    }


    //取得領導卡牌能力(ability : 能力名稱)
    public string get_leader_ablity(string ability)
    {
        string card_ability;

        card_ability = distribute_leader_ability(ability);

        return card_ability;
    }


    //===========================================================================================
    //Function(內部)
    //===========================================================================================

    //================
    //Normal
    //================

    //getgraychip
    private string get_normal_getgraychip()
    {
        //return "取得灰色棋子";
        return "getgraychip";
    }

    //getoppositechip
    private string get_normal_getoppositechip()
    {
        //return "取得對方棋子";
        return "getoppositechip";
    }

    //backgraychip
    private string get_normal_backgraychip()
    {
        //return "變回灰色棋子";
        return "backgraychip";
    }


    //================
    //Legend
    //================

    //addgraychip
    private string get_legend_addgraychip()
    {
        //return "增加灰色棋子數量";
        return "addgraychip";
    }

    //lockownchip
    private string get_legend_lockownchip()
    {
        //return "鎖定我方棋子";
        return "lockownchip";
    }

    //================
    //Leader
    //================

    //addcard
    private string get_leader_addcard()
    {
        //return "抽牌";
        return "addcard";
    }

    //getgraychip
    private string get_leader_getgraychip()
    {
        //return "取得灰色棋子";
        return "getgraychip";
    }

    //getoppositechip
    private string get_leader_getoppositechip()
    {
        //return "取得對方棋子";
        return "getoppositechip";
    }

    //backgraychip
    private string get_leader_backgraychip()
    {
        //return "變回灰色棋子";
        return "backgraychip";
    }

    //lockownchip
    private string get_leader_lockownchip()
    {
        //return "鎖定我方棋子";
        return "lockownchip";
    }

    //===========================================================================================
    //Function(統合)
    //===========================================================================================

    //================
    //Normal
    //================
    private string distribute_normal_ability(string ability)
    {
        switch (ability)
        {
            case "getgraychip":
                {
                    return get_normal_getgraychip();
                }
            case "getoppositechip":
                {
                    return get_normal_getoppositechip();
                }
            case "backgraychip":
                {
                    return get_normal_backgraychip();
                }
            default:
                {
                    return get_normal_getgraychip();
                }
        }
    }


    //================
    //Legend
    //================
    private string distribute_legend_ability(string ability)
    {
        switch (ability)
        {
            case "addgraychip":
                {
                    return get_legend_addgraychip();
                }
            case "lockownchip":
                {
                    return get_legend_lockownchip();
                }
            default:
                {
                    return get_legend_addgraychip();
                }
        }
    }


    //================
    //Leader
    //================
    private string distribute_leader_ability(string ability)
    {
        switch (ability)
        {
            case "addcard":
                {
                    return get_leader_addcard();
                }
            case "getgraychip":
                {
                    return get_leader_getgraychip();
                }
            case "getoppositechip":
                {
                    return get_leader_getoppositechip();
                }
            case "backgraychip":
                {
                    return get_leader_backgraychip();
                }
            case "lockownchip":
                {
                    return get_leader_lockownchip();
                }
            default:
                {
                    return get_leader_addcard();
                }
        }
    }




}
