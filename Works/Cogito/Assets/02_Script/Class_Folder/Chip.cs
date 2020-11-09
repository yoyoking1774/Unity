/*
 * 棋子
 * 
 * 一般  C8C8C8
 * 我方  D90000
 * 我方(鎖定)FF4100
 * 對手  982BEC
 * 對手(鎖定)EC56C2
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    //======================================
    //Attribute
    //======================================

    //string : 擁有者
    private string owner;

    //Color : 擁有者顏色
    private Color ownercolor;

    //bool : 是否鎖定，true:鎖定、false:没鎖定
    private bool islock;

    //======================================
    //(Default)Constructor
    //======================================
    public Chip()
    {
        this.owner = "empty";
        this.ownercolor = new Color(200, 200, 200);
        this.islock = false;
    }

    //======================================
    //(Value)Constructor
    //======================================
    public Chip(string owner, Color ownercolor, bool islock)
    {
        this.owner = owner;
        this.ownercolor = ownercolor;
        this.islock = islock;
    }



    //======================================
    //Getter
    //======================================

    //owner
    public string get_owner()
    {
        return owner;
    }

    //ownercolor
    public Color get_ownercolor()
    {
        return ownercolor;
    }

    //islock
    public bool get_islock()
    {
        return islock;
    }

    //======================================
    //Setter
    //======================================

    //owner
    public void set_owner(string owner)
    {
        this.owner = owner;
    }

    //ownercolor
    public void set_ownercolor(Color ownercolor)
    {
        this.ownercolor = ownercolor;
    }

    //islock
    public void set_islock(bool islock)
    {
        this.islock = islock;
    }

    //Chip
    public void set_chip(Chip chip)
    {
        set_owner(chip.get_owner());
        set_ownercolor(chip.get_ownercolor());
        set_islock(chip.get_islock());
    }

    //Chip
    public void set_chip(string owner, Color ownercolor, bool islock)
    {
        set_owner(owner);
        set_ownercolor(ownercolor);
        set_islock(islock);
    }

}
