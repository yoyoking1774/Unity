/*
 * 控制Ball物件的腳本
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl_Script : MonoBehaviour
{

    //==============================================
    //宣告變數
    //==============================================
    //用於控制BallControll底下的Ball的Sprite。
    public SpriteRenderer[] render;

    //儲存所有Ball的座標。
    private Vector3[] BallsPos;

    //要生成的Ball的種類。
    public Sprite[] Balls;

    //儲存所有Ball。
    public Ball[] AllBall;

    


    public LoadScene la;


    //==============================================
    //初始化
    //==============================================
    private void Start()
    {
        //綁定外部BallControl底下的全部SpriteRenderer，包含自己的SpriteRenderer。
        render = GetComponentsInChildren<SpriteRenderer>();
        
        //生成Ball。
        SpawnRandomBall();

        //儲存所有Ball的座標。
        SaveAllBallsPosition();

        //儲存所有Ball。
        SaveAllBall();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) la.Load_GameScene();
    }

    //==============================================
    //副程式:生成Ball
    //==============================================
    public void SpawnRandomBall() {

        for (int i = 0; i < render.Length; i++) {
            
            //因為上面GetComponentsInChildren<SpriteRenderer>會抓到BallControl自身的SpriteRenderer，所以要剔除掉不做。
            if (render[i].transform == transform) continue;

            //隨機設定其它的Sprite。(RandomRange(0, 3)，包含0 ~ (3-1) )
            render[i].sprite = Balls[Random.RandomRange(0, 3)];

        }//for (int i = 0; i < render.Length; i++)

    }

    //==============================================
    //副程式:儲存所有Ball的座標
    //==============================================
    private void SaveAllBallsPosition() {
        //依照Ball的數量生成Vector3
        BallsPos = new Vector3[30];

        //儲存Ball的座標
        for (int i = 0; i < transform.childCount; i++) {
            BallsPos[i] = transform.GetChild(i).position;
        }
    }

    //==============================================
    //副程式:儲存所有Ball
    //==============================================
    private void SaveAllBall()
    {
        //依照Ball的數量生成Ball
        AllBall = new Ball[30];

        //取得BallControl_Sceipt底下所有的Ball物件
        AllBall = GetComponentsInChildren<Ball>();
    }


    //==============================================
    //副程式檢查所有Ball的連線
    //==============================================
    public void AllBallCheckLink()
    {
        //依照Ball的數量檢查連線
        for (int i = 0; i < AllBall.Length; i++) AllBall[i].CheckLink();
    }

    //==============================================
    //副程式檢查所有Ball的掉落
    //==============================================
    public void AllBallCheckFall()
    {
        //由於Ball的id有些是負的，且要從最底下一排開始掉落，所以從29開始到-29。
        for (int i = 29; i >= -29; i--) {
            //每個Ball
            for (int j = 0; j < AllBall.Length; j++) {
                if (AllBall[j].id == i) AllBall[j].CheckFall();                  
            }                   
        }
        
        

    }



    //====================================================
    //Getter
    //====================================================
    public Vector3 Get_BallPos(int id)
    {
       
        return BallsPos[id];
    }
    
    public Vector3[] GetAll_BallPos()
    {
        return BallsPos;
    }

}//BallControl_Script
