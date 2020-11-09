//磚塊破碎腳本
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broken_Block_Script : MonoBehaviour
{
    //===========================
    //宣告變數****************************************************************************
    //===========================

    //Object:用於生成金幣
    public GameObject Coin_GameObject;


    //===========================
    //副程式:打破Block後銷毀自身
    //===========================
    void Block_Broken_Destory()
    {
        Destroy(this.gameObject);
    }//Block_Broken_Destory

    //===========================
    //觸發****************************************************************************
    //===========================

    //===========================
    //觸發副程式(Block身上)
    //===========================
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //如果Block碰到Player 且 是Player的上方碰到Block
        if (collision.gameObject.tag == "Player" && collision.contacts[0].normal == Vector2.up)
        {
            //播放Block破掉的動畫
            GetComponent<Animation>().Play("Block_BrokenFragment_Animation");

            //打破Block後，依照產生的亂數來決定要不要生成金幣(Random.value: 0~0.9999999...)
            if (Random.value > 0.5) {
                Instantiate(Coin_GameObject , transform.transform.position , transform.rotation);
            }//if (Random.value > 0.5)
        }

    }//OnCollisionEnter2D

    



}//Broken_Block_Script
