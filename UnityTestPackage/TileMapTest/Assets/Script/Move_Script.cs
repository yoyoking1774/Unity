using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Script : MonoBehaviour
{
    //===========================
    //宣告變數****************************************************************
    //===========================
    //Player移動力
    private float RunSpeed = 5;
    //Player跳躍力
    private float JumpHeight = 250.0f;
    //Player的鋼體
    private Rigidbody2D Body;
    //Player的動畫控制器
    private Animator animator;

    

    //角色sprite
    public GameObject PlayerSpirte;

    //===========================
    //角色狀態******************************************************************
    //===========================
    //是否在跳躍狀態 true:在跳躍狀態 false:不在跳躍狀態
    private bool IsJump = false;
    //是否在地面上，true:在地面 false:不在地面
    private bool IsGround = true;
    //是否受傷， true:受傷 false:未受傷
    private bool IsDamage = false;
    //是否執行二段跳， true:執行二段跳 false:不執行二段跳
    private bool IsDoubleJump = false;

    private void Awake()
    {
        GameState.GameOverBool = false;
        animator = GetComponent<Animator>();
        Body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        if (GameState.GameOverBool == true){
            Body.velocity = Vector3.zero;
        }

        //如果Player沒有受到傷害，則可以操作Player
        if (IsDamage == false){ 
         Move();
         Move_Jump();
        }

        Set_JumpState();
        SetPlayer_To_Animator();

    }//FixedUpdate

    //===========================
    //角色功能:移動
    //===========================
    void Move(){
        //Player移動速度
        float Speed = Input.GetAxis("Horizontal") * RunSpeed;
        //設定Player的移動
        Body.velocity = new Vector3(Speed , Body.velocity.y , 0.0f); 

        if (Speed != 0){
            //如果Body.velocity.x是正數，則角色方向改為右邊
            if (Mathf.Sign(Body.velocity.x) >= 1) PlayerSpirte.transform.localScale = new Vector3(0.5f , 0.5f , 0.5f);
            //如果Body.velocity.x是負數，則角色方向改為左邊
            else PlayerSpirte.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            //transform.localScale.x = Mathf.Sign(Body.velocity.x)
        }

    }//Move

    //===========================
    //角色功能:跳躍
    //===========================
    void Move_Jump() {
        //如果不在地面 或 Body.velocity.y不等於 0 ， 表示角色跳躍中，不能再跳躍(執行這一行限制只能一段跳)
        if (IsGround==false ||  Body.velocity.y != 0) { return; }

        //按下跳躍健
        if (Input.GetButtonDown("Jump")){

            if (IsGround == true){
                //給予Player一個向上的力(一段跳)
                Body.AddForce(Vector3.up * JumpHeight);
            }
            else if (IsDoubleJump) {
                //給予Player一個向上的力(二段跳)
                Body.AddForce(Vector3.up * JumpHeight);
                //已經二段跳，不能再次跳
                IsDoubleJump = false;
            }
            else{
                return;
            }

        }//if (Input.GetButtonDown("Jump"))

    }//Move_Jump

    //===========================
    //設定跳躍狀態
    //===========================
    void Set_JumpState() {
        //如果Plyer的y座標 >= 0.1 ， 則表示跳躍中
        if (Body.velocity.y >= 0.1) {
            //將IsJump設為true，表示跳躍中
            IsJump = true;
            //將IsGround設為flase，表示離開地面
            IsGround = false;
        }
        //如果狀態已經是跳躍中，表示開始下墬，則設為沒有跳躍
        else if(IsJump == true){
            IsJump = false;
        }

    }//Set_JumpState

    //===========================
    //副程式:設定受到傷害
    //===========================
    void Set_Damage_On() {
        //呼叫PlayState的方法Hp_Decrease，減少PlayerHp
        SendMessage("Hp_Decrease", 1.0f);
        //表示受到傷害
        IsDamage = true;
        //播放受到傷害的動畫
        animator.SetTrigger("Ani_Damage_Trigger");
    }//Set_Damage_On

    //===========================
    //副程式:設定傷害終止
    //===========================
    void Set_Damage_Off()
    {
        IsDamage = false;
    }//Set_Damage_On

    //===========================
    //副程式:Player死亡
    //===========================
    void GameOver() {
        //播放死亡動畫
        animator.SetTrigger("Ani_PlayerDie_Trigger");
        //Player死亡
        GameState.GameOverBool = true;
        //Player死亡後，執行PlayerState的SaveGame，儲存Player資料
        SendMessage("SaveGame");
        //Player死亡後，經過3.5秒，轉換場景
        Invoke("GameOver_Change_Scene", 3.5f);

    }//GameOver

    //===========================
    //副程式:Player死亡後，切換場景
    //===========================
    void GameOver_Change_Scene() {
        Application.LoadLevel("Load");
    }

    //===========================
    //設定角色綁定Animator
    //===========================
    void SetPlayer_To_Animator(){
        animator.SetFloat("Ani_Speed" , Mathf.Abs(Body.velocity.x));
        animator.SetBool("Ani_IsJump" , IsJump);
        animator.SetBool("Ani_IsGround", IsGround);
    }//SetPlayer_To_Animator

    //===========================
    //碰撞:進入
    //===========================
    void OnCollisionEnter2D(Collision2D Coll)
    {
        //當Player碰到tag為Ground 且 在 Ground的正上方時，表示碰到地面
        if (Coll.gameObject.tag == "Ground" && Coll.contacts[0].normal == Vector2.up)
        {
            print("碰到地面");
            //表示碰到地面
            IsGround = true;
            //重新開啟二段跳功能
            IsDoubleJump = true;
        }
    }//OnCollisionEnter2D

    //===========================
    //碰撞離開
    //===========================
    void OnCollisionExit2D(Collision2D Coll)
    {
        if (Coll.gameObject.tag == "Ground")
        {
            print("離開地面");
            IsGround = false;
        }
    }//OnCollisionExit2D

}//Move_Script
