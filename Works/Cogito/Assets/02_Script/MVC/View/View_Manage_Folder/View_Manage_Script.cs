/*
 * (View)MVC : ManageScene
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View_Manage_Script : MonoBehaviour
{
    //===========================================================================================
    //MVC
    //===========================================================================================

    //Control_Manage_Script:CMS
    public Control_Manage_Script CMS;

    //View_Begin_Script:VBS
    public View_Begin_Script VBS;

    //View_EditCard_Script:VES
    public View_EditCard_Script VES;

    //===========================================================================================
    //DataBase
    //===========================================================================================

    //View_ManageScene_DB
    public View_ManageScene_DB VMDB;

    //Normal_Card、Leader_Card 的能力資料庫
    public Card_Ability_DB CADB;

    //===========================================================================================
    //Variable
    //===========================================================================================


    //===========================================================================================
    //UI(Sprite、Text、Image、Button、GameObject)
    //===========================================================================================

    //======================================
    //Button
    //======================================
    public Button back_button;


    //======================================
    //GameObject
    //======================================
    public GameObject BeginBase;

    public GameObject EditCardBase;

    public GameObject GameSelectBase;

    public GameObject ManualBase;

    //============
    //(GameObjectCanvas)
    //============
    public GameObject BeginCanvas;

    public GameObject EditCardCanvas;

    public GameObject EditCardLeaderCanvas;

    public GameObject GameSelectCanvas;

    public GameObject ManualCanvas;

    public GameObject EditCardDetailCanvas;

    public GameObject EditCardDetail_Out_Panel;

    public GameObject EditCardDetail_Out_Panel_left;

    public GameObject EditCardDetail_Out_Panel_right;

    //===========================================================================================
    //Function(外部)
    //===========================================================================================
    public void set_back_button_interactable(bool interactable)
    {
        back_button.interactable = interactable;
    }

    

    //============
    //(GameObject)
    //============

    //============
    //BeginBase
    //============
    public void set_BeginBasePosition(float x, float y, float z)
    {
        BeginBase.transform.position = new Vector3(x, y, z);
    }

    //============
    //EditCardBase
    //============
    public void set_EditCardBasePosition(float x, float y, float z)
    {
        EditCardBase.transform.position = new Vector3(x, y, z);
    }


    //============
    //GameSelectBase
    //============
    public void set_GameSelectBasePosition(float x, float y, float z)
    {
        GameSelectBase.transform.position = new Vector3(x, y, z);
    }

    //============
    //BeginBase
    //============
    public void set_ManualBasePosition(float x, float y, float z)
    {
        ManualBase.transform.position = new Vector3(x, y, z);
    }

    //============
    //(GameObjectCanvas)
    //============

    //============
    //BeginCanvas
    //============
    public void set_BeginCanvasPosition(float x, float y, float z)
    {
        BeginCanvas.transform.position = new Vector3(x, y, z);
    }

    //============
    //EditCardCanvas
    //============
    public void set_EditCardCanvasPosition(float x, float y, float z)
    {
        EditCardCanvas.transform.position = new Vector3(x, y, z);
    }

    //============
    //EditCardLeaderCanvas
    //============
    public void set_EditCardLeaderCanvasPosition(bool active)
    {
        EditCardLeaderCanvas.SetActive(active);
    }
    

    //============
    //GameSelectCanvas
    //============
    public void set_GameSelectCanvasPosition(float x, float y, float z)
    {
        GameSelectCanvas.transform.position = new Vector3(x, y, z);
    }

    //============
    //ManualCanvas
    //============
    public void set_ManualCanvasPosition(float x, float y, float z)
    {
        ManualCanvas.transform.position = new Vector3(x, y, z);
    }

    //============
    //EditCardDetail_Out_Panel
    //============
    public void set_EditCardDetail_Out_Panel_Position(bool state)
    {
        //editowncard_content
        if (state == true) EditCardDetail_Out_Panel.transform.position = new Vector3(EditCardDetail_Out_Panel_right.transform.position.x, EditCardDetail_Out_Panel_right.transform.position.y, EditCardDetail_Out_Panel_right.transform.position.z);
        //editplaycard_content
        else EditCardDetail_Out_Panel.transform.position = new Vector3(EditCardDetail_Out_Panel_left.transform.position.x, EditCardDetail_Out_Panel_left.transform.position.y, EditCardDetail_Out_Panel_left.transform.position.z);
    }

    

    //============
    //一次修改BeginBase...在內的Position
    //============
    public void set_AllManageBasePosition(float x, float y, float z)
    {
        set_BeginBasePosition(x / 5.0f, y, z);
        set_EditCardBasePosition(x / 5.0f, y, z);
        set_GameSelectBasePosition(x / 5.0f, y, z);
        set_ManualBasePosition(x / 5.0f, y, z);


        set_BeginCanvasPosition(x * 10.0f, y, z);
        set_EditCardCanvasPosition(x * 10.0f, y, z);
        set_GameSelectCanvasPosition(x * 10.0f, y, z);
        set_ManualCanvasPosition(x * 10.0f, y, z);
       
    }



    //============
    //一次修改Begin的Position
    //============
    public void set_AllBeginPosition(float x, float y, float z)
    {
        set_BeginBasePosition(x / 5.0f, y, z);

        set_BeginCanvasPosition(x * 10.0f, y, z);
    }

    //============
    //一次修改EditCard的Position
    //============
    public void set_AllEditCardPosition(float x, float y, float z)
    {
        set_EditCardBasePosition(x / 5.0f, y, z);

        set_EditCardCanvasPosition(x * 10.0f, y, z);
    }

    //============
    //一次修改GameSelect的Position
    //============
    public void set_AllGameSelectPosition(float x, float y, float z)
    {
        set_GameSelectBasePosition(x / 5.0f, y, z);

        set_GameSelectCanvasPosition(x * 10.0f, y, z);
    }

    //============
    //一次修改GameSelect的Position
    //============
    public void set_AllManualPosition(float x, float y, float z)
    {
        set_ManualBasePosition(x / 5.0f, y, z);

        set_ManualCanvasPosition(x * 10.0f, y, z);
    }

    //===========================================================================================
    //Function(內部)
    //===========================================================================================




}
