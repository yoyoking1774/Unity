using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChange_cards
{
    //================
    //新增nomal card
    //================
    void add_nomal_card(GameObject normal_card_object, GameObject content);

    //================
    //移除nomal card
    //================
    void remove_nomal_card(GameObject normal_card_object);

}
