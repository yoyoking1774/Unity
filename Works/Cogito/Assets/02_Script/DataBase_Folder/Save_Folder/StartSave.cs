/*
 * 存檔，用於被繼承給其它存檔，讓繼承的class可以自由撰寫存檔、讀檔的方法
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSave : MonoBehaviour
{
    public SaveGame_Class Sav = new SaveGame_Class();




    //===========================================================================================
    //Function(外部)
    //===========================================================================================
    
    //存檔
    public void DoSave()
    {

    }

    
    //讀檔
    public void DoLoad()
    {

    }

}
