/*
 * AI，用於和玩家比賽
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learn_AI : MonoBehaviour
{


    //======================================
    //Attribute
    //======================================

    //name
    private string name;

    //======================================
    //(Default)Constructor
    //======================================
    public Learn_AI()
    {
        name = "opponent";
    }



    //======================================
    //Function(外部)
    //======================================

    //外部呼叫
    public int call()
    {
        return do_optimization();
    }

    //======================================
    //Function(內部)
    //======================================

    //計算最佳解
    private int do_optimization()
    {
        return 0;
    }


    //======================================
    //Getter
    //======================================

    //name
    public string get_name()
    {
        return name;
    }

    //======================================
    //Setter
    //======================================

    //name
    public void set_name(string name)
    {
        this.name = name;
    }

}
