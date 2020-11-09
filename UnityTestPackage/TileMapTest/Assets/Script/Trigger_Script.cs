//給予地面的腳本，用於判斷Player是否碰到地面
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Script : MonoBehaviour
{

    //public Move_Script Man;

    void OnCollisionEnter2D(Collision2D Coll)
    {
       
       // print("碰到地面" );
          
    }

    /*void OnCollisionExit2D(Collision2D Coll)
    {
        if (Coll.gameObject.tag == "Player")
        
            print("Trigger - B");
    }
    void OnCollisionStay2D(Collision2D Coll)
    {
        if (Coll.gameObject.tag == "Player")
        
            print("Trigger - C" );
    }*/


    

}
