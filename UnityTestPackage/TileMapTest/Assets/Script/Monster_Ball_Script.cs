//怪物:小毛球腳本
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Ball_Script : MonoBehaviour
{
    //===========================
    //宣告屬性*************************************************************
    //===========================
    //Player碰到自身時，給予反饋的力量
    private float Force = 50.0f;
    //小毛球的移動速度
    private float Speed = 0.5f;
    //小毛球的Sprite
    //public GameObject Monster_Ball_GameObject;
    //小毛球的鋼體
    //private Rigidbody2D Body;

    //是否碰到Player， true: 碰到Player false: 未碰到Player 
    private bool IsPlayer = false;
    //小毛球移動方向 true:左邊 false:右邊
    private bool MoveDirectionBool = true;


   

    private void Update()
    {
        //如果Player死亡，則停止所有動作
        if (GameState.GameOverBool == true)
        {
            return;
        }

        //如果沒碰到Plyer
        if (IsPlayer == false) { 
         //持續向左移動
         transform.Translate(Vector2.left * Speed * Time.deltaTime);
        }//if(IsPlayer == false) 

       
    }//Update

    //===========================
    //副程式:碰到玩家後繼續移動
    //===========================
    void ContinueMove() {
        IsPlayer = false;
    }//ContinueMove

    /* //副程式:改變小毛球方向
     void Set_Monster_Ball_ChangeDirection() {
         //如果小毛球的移動方向在右邊，則方向改為左邊
         if (MoveDirectionBool == false) Monster_Ball_GameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
         //如果小毛球的移動方向在左邊，則方向改為右邊
         else Monster_Ball_GameObject.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

         //變換方向
         MoveDirectionBool = !MoveDirectionBool;
     }//Set_Monster_Ball_ChangeDirection*/

    //===========================
    //Collision**************************************************************
    //===========================

    //===========================
    //碰撞:碰到Player
    //===========================
    private void OnCollisionEnter2D(Collision2D collision)
    {
       /* //如果碰到Ground，則變換方向
        if (collision.gameObject.tag == "Ground")
        {
            Set_Monster_Ball_ChangeDirection();
        }*/

        //如果碰到Player 且 是palyer的 下方 碰到自身，則銷毀自身
        if (collision.gameObject.tag == "Player" && collision.contacts[0].normal == Vector2.down)
        {
            Destroy(this.gameObject);
        }

        //如果碰到Player 且 是Palyer的 左方或右方，則給予Player一個反向的力量
        if (collision.gameObject.tag == "Player" && (collision.contacts[0].normal == Vector2.right || collision.contacts[0].normal == Vector2.left) )
        {
            //Player執行自身的Set_Damage_On副程式
            collision.gameObject.SendMessage("Set_Damage_On");
            //小毛球給予Player一個反向的力量
            collision.rigidbody.AddForce(collision.contacts[0].normal * Force);
            //小毛球碰到Player，停止移動
            IsPlayer = true;
            //碰到Player停止移動後，經過1秒，回復移動
            Invoke("ContinueMove" , 1.0f);
        }

    }//OnCollisionEnter2D




}//Monster_Ball_Script
