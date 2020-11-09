/*
 * (Model)MVC: MangeScene -> EditCard
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//使用Dictionary的ElementAt
using System.Linq;
using UnityEngine.UI;

public class Model_EditCard_Script : MonoBehaviour
{
    //===========================================================================================
    //MVC
    //===========================================================================================

    //Model_Manage_Script:MMS
    public Model_Manage_Script MMS;

    //editowncard_content:卡牌新增到editowncard_content
    public GameObject editowncard_content;

    //editplaycard_content:卡牌新增到editplaycard_content
    public GameObject editplaycard_content;

    //EditCardDetailCanvas
    public GameObject editcarddetailcanvas;

    //===========================================================================================
    //Variable
    //===========================================================================================

    //最大可上場的卡牌數量
    private int max_play_card = 30;

    //最少上場的卡牌數量
    private int min_play_card = 5;


    //外部新建normal_cards的Prefab
    public GameObject instantiate_normal_card;
    //新建normal_cards的Prefab底下的Text
    public Text instantiate_normal_card_text; 

    //現在滑鼠是在哪個的content，true: editowncard_content、false: editplaycard_content
    private bool state = true;


    //===========================================================================================
    //Start
    //===========================================================================================
    private void Start()
    {
        Create_card();    
    }


    //===========================================================================================
    //Function(Event Trigger)
    //===========================================================================================

    //================
    //(Event Trigger)設定滑鼠現在是在哪個的content
    //================
    public void Do_EditCard_state(bool new_state)
    {
        state = new_state;

        //更新View，修改EditCardDetail_Out_Panel位置
        set_EditCardDetail_Out_Panel_Position();
    }

    //================
    //(Event Trigger)開啟EditCardDetailCanvas(gameObject:卡牌自身)
    //================
    public void Do_Enter_EditCardDetailCanvas(GameObject gameObject)
    {
        editcarddetailcanvas.SetActive(true);
        
        //更新View，一次修改現在editcarddetail資訊
        MMS.CMS.VMS.VES.set_editcarddetail_information(gameObject.GetComponent<Normal_Card>());
    }

    //================
    //(Event Trigger)關閉EditCardDetailCanvas
    //================
    public void Do_Exit_EditCardDetailCanvas()
    {
        editcarddetailcanvas.SetActive(false);
    }

    //===========================================================================================
    //Function(Button)
    //===========================================================================================

    //================
    //(Button)交換卡牌(normal_card_object:要交換的卡牌)
    //================
    public void Do_change(GameObject normal_card_object)
    {

        //箱子的卡牌數量
        int owncard_number = MMS.get_player().get_own_card().get_all_normal_card().Count;
        //已上場的卡牌數量
        int playcard_number = MMS.get_player().get_play_card().get_all_normal_card().Count;


        if (state == true)
        {
            //如果 已上場的卡牌 < 最大可上場數量，則繼續增加已上場的卡牌
            if (playcard_number < max_play_card) Do_play(normal_card_object);
            //否則，不增加已上場的卡牌
            else print("最多上場 " + max_play_card + " 張牌");
        }
        else if (state == false)
        {
            //如果 已上場的卡牌 > 最少上場數量，則繼續增加已上場的卡牌
            if (playcard_number > min_play_card) Do_own(normal_card_object);
            //否則，不減少已上場的卡牌
            else print("最少上場 " + min_play_card + " 張牌");
        }

        //更新View，修改單一卡牌剩餘數量
        View_single_card_number(normal_card_object, state);
        //更新View，修改owncard、playcard的卡牌總數量
        View_card_number();
    }

    
    //===========================================================================================
    //Function(MVC)
    //===========================================================================================

    //================
    //呼叫View修改單一卡牌剩餘數量(normal_card_object:要交換的卡牌 , state:是在哪個的content)
    //================
    public void View_single_card_number(GameObject normal_card_object , bool state)
    {
        //own_card普通卡牌種類和數量
        Dictionary<string, int> own_card_normal_cards_number = MMS.get_player().get_own_card().get_normal_cards_number();
        //play_card普通卡牌種類和數量
        Dictionary<string, int> play_card_normal_cards_number = MMS.get_player().get_play_card().get_normal_cards_number();
        //另一個頁面的卡牌
        GameObject other_card;

        //找出要交換卡片在另一個頁面的卡牌
        other_card = Find_single_card(normal_card_object , state);
        
        //更新View，修改交換卡牌的剩餘卡牌數量
        MMS.CMS.VMS.VES.View_single_card_number(normal_card_object , other_card, own_card_normal_cards_number , play_card_normal_cards_number , state);
    }

    //================
    //找出要交換卡片在另一個頁面的卡牌(state:是在哪個的content)
    //================
    private GameObject Find_single_card(GameObject normal_card_object , bool state)
    {
        //暫存另一個頁面的卡牌
        GameObject Temp;
        //在外部GameObject的名稱
        string name;

        //editowncard_content -> editplaycard_content
        if (state == true)
        {
            name = normal_card_object.GetComponent<Normal_Card>().get_id().ToString();
            Temp = editplaycard_content.transform.Find(name).gameObject;
        }
        //editplaycard_content -> editowncard_content
        else
        {
            name = normal_card_object.GetComponent<Normal_Card>().get_id().ToString();
            Temp = editowncard_content.transform.Find(name).gameObject;
        }

        return Temp;
    }

    //================
    //呼叫View修改卡牌總數量
    //================
    public void View_card_number()
    {
        //箱子的卡牌數量
        int owncard_number = MMS.get_player().get_own_card().get_all_normal_card().Count;
        //已上場的卡牌數量
        int playcard_number = MMS.get_player().get_play_card().get_all_normal_card().Count;

        //更新View，修改owncard、playcard的卡牌總數量    
        MMS.CMS.VMS.VES.set_EditOwnCard_Number_Text(owncard_number);
        MMS.CMS.VMS.VES.set_EditPlayCard_Number_Text(playcard_number);
    }




    //===========================================================================================
    //Function(內部)
    //===========================================================================================

    //================
    //交換卡牌(到play_card)(normal_card_object:要交換的卡牌)
    //================
    private void Do_play(GameObject normal_card_object)
    {
        MMS.get_player().do_change_normal_card_to_play(normal_card_object, editplaycard_content);
    }

    //================
    //交換卡牌(到own_card)(normal_card_object:要交換的卡牌)
    //================
    private void Do_own(GameObject normal_card_object)
    {
        MMS.get_player().do_change_normal_card_to_own(normal_card_object , editowncard_content);
    }


    //================
    //新建Object:normal_cards
    //================
    private void Create_card()
    {
        Create_card_own_card();
        Create_card_play_card();

        //更新View，修改owncard、playcard的卡牌總數量
        View_card_number();
    }


    //================
    //新建Object:normal_cards(play_card)
    //================
    private void Create_card_own_card()
    {
        //own_card普通卡牌種類和數量
        Dictionary<string, int> own_card_normal_cards_number = MMS.get_player().get_own_card().get_normal_cards_number();
        //用於設定新建的normal_cards
        GameObject temp_own;

        int i, j;

        //editowncard_content
        for (i = 0; i < own_card_normal_cards_number.Count; i++)
        {
            //取得own_card_normal_cards_number的Key
            j = int.Parse(own_card_normal_cards_number.ElementAt(i).Key);
            
            //建立normal_cards
            temp_own = Instantiate(instantiate_normal_card, editowncard_content.transform);
            //設定name
            temp_own.name = own_card_normal_cards_number.ElementAt(i).Key;
            //設定新建的normal_cards的內容
            temp_own.GetComponent<Normal_Card>().set_normal_card(MMS.get_player().get_own_card().get_normal_card(j));
            //設定卡牌數量
            temp_own.transform.GetChild(0).GetComponent<Text>().text = "X" + own_card_normal_cards_number[own_card_normal_cards_number.ElementAt(i).Key];
            //設定卡牌大頭照
            temp_own.GetComponent<Image>().sprite = temp_own.GetComponent<Normal_Card>().get_headshot();
        }

    }

    //================
    //新建Object:normal_cards(own_card)
    //================
    private void Create_card_play_card()
    {
        //play_card普通卡牌種類和數量
        Dictionary<string, int> play_card_normal_cards_number = MMS.get_player().get_play_card().get_normal_cards_number();
        //用於設定新建的normal_cards
        GameObject temp_play;

        int i, j;

        //editplaycard_content
        for (i = 0; i < play_card_normal_cards_number.Count; i++)
        {
            //取得play_card_normal_cards_number的Key
            j = int.Parse(play_card_normal_cards_number.ElementAt(i).Key);

            //建立normal_cards
            temp_play = Instantiate(instantiate_normal_card, editplaycard_content.transform);
            //設定name
            temp_play.name = play_card_normal_cards_number.ElementAt(i).Key;
            //設定新建的normal_cards的內容
            temp_play.GetComponent<Normal_Card>().set_normal_card(MMS.get_player().get_play_card().get_normal_card(j));
            //設定卡牌數量
            temp_play.transform.GetChild(0).GetComponent<Text>().text = "X" + play_card_normal_cards_number[play_card_normal_cards_number.ElementAt(i).Key];
            //設定卡牌大頭照
            temp_play.GetComponent<Image>().sprite = temp_play.GetComponent<Normal_Card>().get_headshot();
        }

    }

    //================
    //修改EditCardDetail_Out_Panel位置
    //================
    private void set_EditCardDetail_Out_Panel_Position()
    {
        MMS.CMS.VMS.set_EditCardDetail_Out_Panel_Position(state);
    }

}
