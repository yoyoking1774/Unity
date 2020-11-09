using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class View_Begin_Script : MonoBehaviour
{

    //===========================================================================================
    //MVC
    //===========================================================================================

    //View_Manage_Script:VMS
    public View_Manage_Script VMS;


    //===========================================================================================
    //UI(Sprite、Text、Image、Button、GameObject)
    //===========================================================================================

    //======================================
    //Text
    //======================================

    //entereditcard_number_text
    public Text entereditcard_number_text;






    //===========================================================================================
    //Function(外部)
    //===========================================================================================


    //======================================
    //Text
    //======================================

    //entereditcard_number_text
    public void set_entereditcard_number_text(int number)
    {
        entereditcard_number_text.text = number + "張";
    }


}
