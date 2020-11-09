/*
 * Class: 儲存資料的格式
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame_Class : MonoBehaviour
{
    //======================================================
    //Attribute(要儲存的資料，後面為初始值)
    //======================================================

    //name
    public string name = "MIM";

    //============
    //owncard
    //============

    //Leader_Card: 領導卡牌
    public List<int> own_leader_cards;
    //Dictionary<string(編號), int(數量)>: 領導卡牌種類和數量
    //public Dictionary<string, int> own_leader_cards_number;

    //Normal_Card: 普通卡牌
    public List<int> own_normal_cards;
    //Dictionary<string(編號), int(數量)>: 普通卡牌種類和數量
    //public Dictionary<string, int> own_normal_cards_number;


    //============
    //playcard
    //============

    //Leader_Card: 領導卡牌
    public int play_leader_card;

    //Normal_Card: 普通卡牌
    public List<int> play_normal_cards;
    //Dictionary<string(編號), int(數量)>: 普通卡牌種類和數量
   // public Dictionary<string, int> play_normal_cards_number;


    //============
    //是否為第1次存檔，true:第1次 false:非第1次
    //============
    public bool FirstSave = true;


}
