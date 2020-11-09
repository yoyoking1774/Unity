/*
 * Object: Ball
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    //====================================================
    //宣告變數
    //====================================================

    //編號
    public int id = 0;

    //BallControl
    private BallControl_Script BallControl;

    //是否移動，true:移動 false:不移動
    private bool isMove = false;

    private void Update()
    {
        //如果移動
        if (isMove == true) {
            //將Ball的位置移動到新的位置，Vector3.MoveTowards(原本位置，新位置，移動速度)
            transform.position = Vector3.MoveTowards(transform.position, BallControl.Get_BallPos(id) , 0.15f); 
            if (transform.position == BallControl.Get_BallPos(id)) isMove = false;
        }
    }

    //====================================================
    //初始化
    //====================================================
    private void Awake()
    {
        //綁定父物件BallControl底下的BallControl_Script腳本
        BallControl = transform.parent.GetComponent<BallControl_Script>();
    }

    //====================================================
    //滑鼠按住
    //====================================================
    private void OnMouseDrag()
    {
        //取得Hierarchy上的MainCamera。
        Camera camera = Camera.main;

        //將camera中的滑鼠座標轉為世界座標，也就是拖曳後的新座標。
        Vector3 newPos = camera.ScreenToWorldPoint(Input.mousePosition);

        //邊界
        Bounds bound = transform.parent.GetComponent<BoxCollider>().bounds;

        //邊界最大值(大概是最右上角，最大的XYZ)
        Vector3 max = bound.max;

        //邊界最小值(大概是最左下角，最小的XYZ)
        Vector3 min = bound.min;

        //判斷newPos.x是否在最小的X、最大的X範圍內，並限制移動範圍。
        //newPos.x <  min.x，newPos.x = min.x
        //newPos.x >  max.x，newPos.x = max.x
        newPos = new Vector3(Mathf.Clamp(newPos.x, min.x, max.x) , Mathf.Clamp(newPos.y, min.y, max.y) , 0);

        //將Ball舊的座標改為新座標。
        transform.position = new Vector3(newPos.x, newPos.y, 0);

        
    }


    //====================================================
    //滑鼠放開
    //====================================================
    private void OnMouseUp()
    {
        //Ball回到原本的座標。
        transform.position = transform.parent.GetComponent<BallControl_Script>().Get_BallPos(id);

        //檢查是否有連線。
        BallControl.AllBallCheckLink();

        //檢查掉落(等Ball的BallFade_Animation播放結束再執行)
        //BallControl.Invoke("AllBallCheckFall" , 0.6f);
        StartCoroutine(StartCheckFall());
        
    }

    //協程:等Ball的BallFade_Animation播放結束再執行檢查
    IEnumerator StartCheckFall()
    {
        //等待0.5秒
        yield return new WaitForSeconds(0.5f);
        //執行檢查掉落
        BallControl.AllBallCheckFall();       
    }

    //====================================================
    //副程式:檢查是否有連結
    //====================================================
    public void CheckLink() {
        //Ball的右邊，發射一條線，往右邊射去，並將碰到的Collider存進hits_R(自身位置 ， 自身位置的右邊，哪一層的Layer(2^n，n表示哪一層))
        RaycastHit2D[] hits_R = Physics2D.LinecastAll(transform.position , transform.position + transform.right*10 , 256);
        //Ball的左邊，發射一條線，往左邊射去，並將碰到的Collider存進hits_L(自身位置 ， 自身位置的左邊，哪一層的Layer(2^n，n表示哪一層))
        RaycastHit2D[] hits_L = Physics2D.LinecastAll(transform.position, transform.position - transform.right * 10, 256);
        //Ball的上面，發射一條線，往上面射去，並將碰到的Collider存進hits_UP(自身位置 ， 自身位置的上面，哪一層的Layer(2^n，n表示哪一層))
        RaycastHit2D[] hits_UP = Physics2D.LinecastAll(transform.position, transform.position + transform.up * 10, 256);
        //Ball的下面，發射一條線，往下面射去，並將碰到的Collider存進hits_Down(自身位置 ， 自身位置的下面，哪一層的Layer(2^n，n表示哪一層))
        RaycastHit2D[] hits_Down = Physics2D.LinecastAll(transform.position, transform.position - transform.up * 10, 256);

        //Ball自身的Sprite
        Sprite BallSprite = GetComponent<SpriteRenderer>().sprite;

        //水平(Horizontal)連線的Ball數量
        int Count_H = 0;
        //垂直(Vertical)連線的Ball數量
        int Count_V = 0;

        //迴圈用
        int i;

        
        //=====================================================================================================
        //判斷連線標準
        //=====================================================================================================

        //判斷是否有達到連線標準，如果沒有，下面的判斷連線就不用執行
        for (i = 0; i < hits_R.Length; i++) {
            //如果hits_R射出去的碰到的collider的Sprite == Ball自身的Sprite，則Count_H數量+1
            if (hits_R[i].collider.GetComponent<SpriteRenderer>().sprite == BallSprite) Count_H = Count_H + 1;
            //如果右邊沒有"連續"跟Ball自身相同的Sprite，則停止判斷。
            else break;
        }

        //判斷是否有達到連線標準，如果沒有，下面的判斷連線就不用執行
        for (i = 0; i < hits_L.Length; i++)
        {
            //如果hits_L射出去的碰到的collider的Sprite == Ball自身的Sprite，則Count_H數量+1
            if (hits_L[i].collider.GetComponent<SpriteRenderer>().sprite == BallSprite) Count_H = Count_H + 1;
            //如果左邊沒有"連續"跟Ball自身相同的Sprite，則停止判斷。
            else break;
        }

        //判斷是否有達到連線標準，如果沒有，下面的判斷連線就不用執行
        for (i = 0; i < hits_UP.Length; i++)
        {
            //如果hits_UP射出去的碰到的collider的Sprite == Ball自身的Sprite，則Count_V數量+1
            if (hits_UP[i].collider.GetComponent<SpriteRenderer>().sprite == BallSprite) Count_V = Count_V + 1;
            //如果上面沒有"連續"跟Ball自身相同的Sprite，則停止判斷。
            else break;
        }

        //判斷是否有達到連線標準，如果沒有，下面的判斷連線就不用執行
        for (i = 0; i < hits_Down.Length; i++)
        {
            //如果hits_Down射出去的碰到的collider的Sprite == Ball自身的Sprite，則Count_V數量+1
            if (hits_Down[i].collider.GetComponent<SpriteRenderer>().sprite == BallSprite) Count_V = Count_V + 1;
            //如果下面沒有"連續"跟Ball自身相同的Sprite，則停止判斷。
            else break;
        }


        //=====================================================================================================
        //判斷連線標準補正
        //=====================================================================================================

        //因為上面在執行判斷連線標準時，LinecastAll會將自身算進去，造成多1次的Count_H，所以減1。
        Count_H = Count_H - 1;
        //因為上面在執行判斷連線標準時，LinecastAll會將自身算進去，造成多1次的Count_V，所以減1。
        Count_V = Count_V - 1;


        //=====================================================================================================
        //判斷連線
        //=====================================================================================================

        //如果有Ball水平兩邊達3顆Ball以上的連線
        if (Count_H >= 3) {
            //判斷連線(右邊)
            for (i = 0; i < hits_R.Length; i++)
            {
                //如果hits_R射出去的碰到的collider的Sprite == Ball自身的Sprite
                if (hits_R[i].collider.GetComponent<SpriteRenderer>().sprite == BallSprite)
                {
                    //消除Ball
                    hits_R[i].collider.GetComponent<Ball>().Fade();                   
                }
                //如果右邊沒有"連續"跟Ball自身相同的Sprite，則停止判斷。
                else break;
            }

            //判斷連線(左邊)
            for (i = 0; i < hits_L.Length; i++)
            {
                //如果hits_L射出去的碰到的collider的Sprite == Ball自身的Sprite
                if (hits_L[i].collider.GetComponent<SpriteRenderer>().sprite == BallSprite)
                {
                    //消除Ball
                    hits_L[i].collider.GetComponent<Ball>().Fade();               
                }
                //如果左邊沒有"連續"跟Ball自身相同的Sprite，則停止判斷。
                else break;
            }
        }

        //如果有Ball垂直兩邊達3顆Ball以上的連線
        if (Count_V >= 3) {
            //判斷連線(上面)
            for (i = 0; i < hits_UP.Length; i++)
            {
                //如果hits_UP射出去的碰到的collider的Sprite == Ball自身的Sprite
                if (hits_UP[i].collider.GetComponent<SpriteRenderer>().sprite == BallSprite)
                {
                    //消除Ball
                    hits_UP[i].collider.GetComponent<Ball>().Fade();      
                }
                //如果上面沒有"連續"跟Ball自身相同的Sprite，則停止判斷。
                else break;
            }

            //判斷連線(下面)
            for (i = 0; i < hits_Down.Length; i++)
            {
                //如果hits_Down射出去的碰到的collider的Sprite == Ball自身的Sprite
                if (hits_Down[i].collider.GetComponent<SpriteRenderer>().sprite == BallSprite)
                {
                    //消除Ball
                    hits_Down[i].collider.GetComponent<Ball>().Fade();    
                }
                //如果下面沒有"連續"跟Ball自身相同的Sprite，則停止判斷。
                else break;
            }
        }

          
    }

    //====================================================
    //副程式:如果連線，消除Ball
    //====================================================
    public void Fade() {
        //將Ball的Sprite透明度，設為0。
        GetComponent<Animation>().Play("BallFade_Animation");
    }

    

    //====================================================
    //副程式:將消除的Ball放到鏡射座標
    //====================================================
    public void FadeMoveToUp() {

        //轉換成-id，為了計算掉落之後的id
        id = id * (-1);
       
        //鏡射位置(Ball原本的X座標 , (0+(0-transform.position.y)) , Ball原本的Z座標)，0代表鏡射基準線的位置，可依情況修改。
        transform.position = new Vector3(transform.position.x, (-transform.position.y) , transform.position.z);

        //給予Ball新的Sprite
        GetComponent<SpriteRenderer>().sprite = BallControl.Balls[Random.RandomRange(0, 3)];

    }

    //====================================================
    //副程式:Ball掉落
    //====================================================
    public void CheckFall(){

        //恢復成有顏色的狀態
        GetComponent<SpriteRenderer>().color = new Color(1 , 1 , 1 , 1);

        //Ball的下面，發射一條線，往下面射去，並將碰到的Collider存進hits_Down(自身位置 ， 自身位置的下面，哪一層的Layer(2^n，n表示哪一層))
        RaycastHit2D[] hits_Down = Physics2D.LinecastAll(transform.position, transform.position - transform.up * 10, 256);

        //如果Ball下方沒有其它Ball存在，所以要掉落到最底下，因為LinecastAll會算到自己，所以至少為1。
        if (hits_Down.Length == 1){
            //因為id在FadeMoveToUp已經變成負的，使用Abs轉成正的，在加上24(看第一排~最後一排插幾排在 乘上 一排有幾個Ball)
            id = Mathf.Abs(id % 6) + 24;          
        }
        //如果Ball下方有其它Ball存在，則將自己的id改為下方第1個Ball的id - 6，因為idp已經變成負的所以減6
        else{
            id = (hits_Down[1].collider.GetComponent<Ball>().id) - 6;        
        }

        //Ball移動到掉落後的位置
        isMove = true;
        
    }

    //====================================================
    //Trigger進入
    //====================================================
    private void OnTriggerEnter2D(Collider2D Ball_Slot)
    {
        //找出Ball_Slot是跟畫面上的哪一個Ball重疊，因為當交換之後AllBall的id也會改變。
        for (int i=0; i<transform.parent.GetComponent<BallControl_Script>().AllBall.Length; i++)
        {
            //如果Ball碰到Ball_Slot，且Ball_Slot的id == Ball的id，則交換。(BallControl.AllBall[i]代表被交換的Ball)
            if (Ball_Slot.GetComponent<BallSlot>().id == BallControl.AllBall[i].id) {
                //暫存Ball的id
                int temp = id;
                //將Ball的id 變成 現在在Ball_Slot上的Ball的id
                id = BallControl.AllBall[i].id;
                //現在在Ball_Slot上的Ball的id 變成 Ball的id
                BallControl.AllBall[i].id = temp;
                //設定新的位置
                BallControl.AllBall[i].isMove = true;
                //BallControl.AllBall[i].OnMouseUp();
            }
        }//for (int i=0; i<transform.parent.GetComponent<BallControl_Script>().AllBall.Length; i++)

    }

    //====================================================
    //Getter
    //====================================================
    public int Get_Id() {
        return id;     
    }
}//Ball
