/*
 * (Model)MVC: MangeScene -> Begin
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_Begin_Script : MonoBehaviour
{
    //===========================================================================================
    //MVC
    //===========================================================================================

    //Model_Manage_Script:MMS
    public Model_Manage_Script MMS;



    //Start
    private void Start()
    {
        //更新View，設定總卡牌數量
        set_entereditcard_number_text();
    }





    //===========================================================================================
    //Function(內部)
    //===========================================================================================


    //更新View，設定總卡牌數量
    private void set_entereditcard_number_text()
    {
        //擁有卡牌的普通卡牌數量
        int own_card_normal_cards_number = MMS.get_player().get_own_card().get_all_normal_card().Count;
        //上場卡牌的普通卡牌數量
        int play_card_normal_cards_number = MMS.get_player().get_play_card().get_all_normal_card().Count;

        //更新View，設定總卡牌數量EnterEditCard_Number_Text
        MMS.CMS.VMS.VBS.set_entereditcard_number_text(own_card_normal_cards_number + play_card_normal_cards_number);
    }










}
