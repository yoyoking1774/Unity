/*
 * (Model)MVC: MangeScene -> EditCard -> EditCardLeader
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//使用Dictionary的ElementAt
using System.Linq;

public class Model_EditCard_LeaderCard_Script : MonoBehaviour
{
    //===========================================================================================
    //MVC
    //===========================================================================================

    //Model_EditCard_Script:MES
    public Model_EditCard_Script MES;




    //===========================================================================================
    //Function(Event Trigger)
    //===========================================================================================

    //================
    //(Event Trigger)editcardleader的所有資訊(id:領導卡牌編號)
    //================
    public void Do_leadercard_information(int id)
    {
        //更新View，修改editcardleader的所有資訊
        MES.MMS.CMS.VMS.VES.VELS.set_editcardleader_information(MES.MMS.get_player().get_own_card().get_leader_card(id));
    }


    //===========================================================================================
    //Function(Button)
    //===========================================================================================

    //設定領導卡牌(id:領導卡牌編號)
    public void set_leader_card(int id)
    {
        //設定領導卡牌
        MES.MMS.get_player().set_leader_card(id);
        //更新View，領導卡牌資訊
        MES.MMS.CMS.VMS.VES.set_editcardleader_information(MES.MMS.get_player().get_own_card().get_leader_card(id));

        //存檔
        MES.MMS.do_save();
    }



}
