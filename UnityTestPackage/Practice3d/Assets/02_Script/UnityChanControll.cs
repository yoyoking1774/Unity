//UnityChan控制
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnityChanControll : MonoBehaviour {

	//宣告變數
	private CharacterController UnityChan;        //角色控制器
	private Vector3 moveDirection = Vector3.zero; //指示路徑向量
	private float StartGameTimer;                 //開始遊戲計時器

	public GameObject MainCamera;                 //主要攝影機
	private Vector3 UnityChanPosition;            //unityChan所在位置
	private Vector3 CameraFollowVector;           //攝影機跟隨向量

	private bool StartGameBool;                   //開始遊戲布林值
	private bool EndGameBool;                     //結束遊戲布林值
	public float RunSpeed;                        //跑步速度
	public float JumpSpeed;                       //跳躍速度
	public float Gravity;                         //角色承受的重力值

	private bool LeftMoveBool;                    //是否向左移動
	private bool RightMoveBool;                   //是否向右移動
	private bool JumpBool;                        //是否跳躍
	private float HoriztalMoveTimer;              //水平移動計時器

	public GameObject[] MissionArea;              //關卡陣列 
	public GameObject EndArea;                    //終點區域
	public GameObject SeaArea;                    //海洋區域
	private bool PlayerEnterMissionBool;          //玩家是否進入新關卡 true:進入 fasle:未進入
	private int MissionAreaindex;                 //生成關卡當前數量
	private int MissionAreaMax;                   //生成關卡上限值
	private int MissionCateMax = 4;               //生成關卡種類上限

	private int LiveNumber;                       //生命數
	public Text LiveText;						  //生命Text
	private int ScoreNumber;                      //分數
	public Text ScoreText;						  //分數Text
	private int TreasureNumber;                   //寶藏數
	public Text TreasureText;					  //寶藏Text
	public GameObject SumPlane;                   //總分Plane
	public Text SumText;                          //總分Text

	public AudioSource WinMusic;                  //勝利音樂
	public AudioSource LoseMusic;				  //失敗音樂
	public AudioSource JumpVoice1; 				  //跳躍聲音1
	public AudioSource JumpVoice2; 			      //跳躍聲音2
	public AudioSource MoveVoice;                 //換方向聲音
	public AudioSource DestoryVoice;              //碰到東西聲音

	public Button GameRestartButton;              //重新遊戲Button
	public static bool GameRestartBool = false;   //遊戲重新開始 true:重新開始 fasle:不重新開始
	private float   GameRestartTime = 0.0f; 
	private bool NewGameBool = false;  			  //開啟新關卡bool true:開啟新關卡 fasle:不開啟新關卡

	private bool GamePauseBool = false;           //是否按下暫停 true:按下暫停 false:未按下暫停

	// Use this for initialization
	void Start () {
		//定義角色控制器 = UnityChan的角色控制器
		UnityChan = this.GetComponent<CharacterController> ();
		//UnityChan跑步動畫設為false
		this.GetComponent<UnitychanController> ().Runbool = false;
		//UnityChan向左跑步動畫設為false
		this.GetComponent<UnitychanController> ().RunLbool = false;
		//UnityChan向右跑步動畫設為false
		this.GetComponent<UnitychanController> ().RunRbool = false;
		//UnityChan跳躍動畫設為false
		this.GetComponent<UnitychanController> ().Jumpbool = false;
		//UnityChan勝利動畫設為false
		this.GetComponent<UnitychanController> ().Winbool = false;
		//UnityChan失敗動畫設為false
		this.GetComponent<UnitychanController> ().Losebool = false;

		//開始遊戲設為false
		StartGameBool = false;
		//結束遊戲設為false
		EndGameBool = false;
		//開始遊戲時間設為0秒
		StartGameTimer = 0;
		//向左移動設為false
		LeftMoveBool = false;          
		//向右移動設為false
		RightMoveBool = false;                   
		//跳躍設為false
		JumpBool = false;          
		//水平移動計時器設為0秒
		HoriztalMoveTimer = 0.0f;                

		//初始關卡1隨機值 關卡種類:關卡A - 關卡C 隨機選1個
		int RandMissionint1 = Random.Range (0, MissionCateMax);
		//生成關卡1:設定關卡1位置
		Instantiate (MissionArea [RandMissionint1], new Vector3 (-0.8344555f, -2.068496f, 337.366f), Quaternion.identity);

		//初始關卡2隨機值 關卡種類:關卡A - 關卡C 隨機選1個
		int RandMissionint2 = Random.Range (0, MissionCateMax);
		//生成關卡2:設定關卡2位置
		Instantiate (MissionArea [RandMissionint2], new Vector3 (-0.8344555f, -2.068496f, 344.366f), Quaternion.identity);
	
		//玩家是否進入新關卡 預設 = fasle
		PlayerEnterMissionBool = false;
		//生成關卡當前數量，已生成關卡1和2所已數量為 0 + 2 = 2關
		MissionAreaindex = 2;
		//生成關卡最大數量預設為6，所以會在生成4關
		MissionAreaMax = 6;

		//隱藏重新遊戲Button
		GameRestartButton.interactable = false;

		//隱藏總分畫面
		SumPlane.SetActive (false);


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) GamePause ();

		//如果遊戲開始
		if (StartGameBool == true) {
			//如果UnityChan在地面上
			if (UnityChan.isGrounded) {
				//指示路徑向前走
				moveDirection = new Vector3 (0, 0, 1);
				moveDirection = transform.TransformDirection (moveDirection);

				//設定UnityChan跳躍動畫為false
				this.GetComponent<UnitychanController> ().Jumpbool = false;


				//如果向左移動為true
				if (Input.GetKey ("left")) LeftMoveButton(); //如果按下左健
				if(LeftMoveBool == true){
					//指示路徑向左走
					moveDirection = new Vector3 (-2, 0, 1);
					moveDirection = transform.TransformDirection (moveDirection);
					//計算向左移動時間
					HoriztalMoveTimer = HoriztalMoveTimer + Time.deltaTime;

					//如果向左移動超過0.3秒
					if (HoriztalMoveTimer > 0.3f) {
						//將水平移動計時器設為0秒
						HoriztalMoveTimer = 0.0f;
						//向左移動為false
						LeftMoveBool = false;
						//設定向左跑的動畫為fasle
						this.GetComponent<UnitychanController> ().RunLbool = false;
					}

				}

				//如果向右移動為true
				if (Input.GetKey ("right")) RightMoveButton();  //如果按下右健
				if(RightMoveBool == true){
					//指示路徑向右走
					moveDirection = new Vector3 (2, 0, 1);
					moveDirection = transform.TransformDirection (moveDirection);
					//計算向右移動時間
					HoriztalMoveTimer = HoriztalMoveTimer + Time.deltaTime;

					//如果向右移動超過0.3秒
					if (HoriztalMoveTimer > 0.3f) {
						//將水平移動計時器設為0秒
						HoriztalMoveTimer = 0.0f;
						//向右移動為false
						RightMoveBool = false;
						//設定向右跑的動畫為fasle
						this.GetComponent<UnitychanController> ().RunRbool = false;
					}

				}

				//如果按下空白健，執行跳躍動畫
				if (Input.GetKeyDown (KeyCode.Space)) {
					//指示路徑向上走
					moveDirection = new Vector3 (0, JumpSpeed, 1);
					moveDirection = transform.TransformDirection (moveDirection);
					//設定UnityChan跳躍動畫為true
					this.GetComponent<UnitychanController> ().Jumpbool = true;

					Random.seed = System.Guid.NewGuid().GetHashCode();
					int rand = Random.Range(1, 11);
					if (rand <= 5)JumpVoice1.Play ();
					else JumpVoice2.Play ();

				}

				//設定向前走的速度 =  moveDirection * 移動速度
				moveDirection = moveDirection * RunSpeed*5;
			}

			//設定角色會因為重力向下降
			moveDirection.y = moveDirection.y - (Gravity * Time.deltaTime);
			//UnityChan依照上面指定的路徑移動
			UnityChan.Move (moveDirection * Time.deltaTime);        
		}

		//如果遊戲開始
		if (StartGameBool == true) {
			//改變UnityChan所在位置
			UnityChanPosition = this.GetComponent<Transform> ().position;
			//設定CameraFollowVector的位置
			CameraFollowVector = new Vector3 (UnityChanPosition.x, 0.89f, UnityChanPosition.z - 1.0f);
			//依照CameraFollowVector 設定MainCamera的位置
			MainCamera.GetComponent<Transform> ().position = CameraFollowVector;
			//改變海洋位置，成為無限場景
			SeaArea.GetComponent<Transform> ().position = new Vector3 (SeaArea.GetComponent<Transform> ().position.x, SeaArea.GetComponent<Transform> ().position.y, SeaArea.GetComponent<Transform> ().position.z + 0.05f);
		}

		//如果遊戲沒結束
		if(EndGameBool == false){
			//開起遊戲計時器
			StartGameTimer = StartGameTimer + Time.deltaTime;

			//開起遊戲計時器 > 1秒 且 沒有暫停遊戲， 則開始遊戲
			if (StartGameTimer >= 1 && GamePauseBool == false) {
				StartGameBool = true;
				StartGameTimer = 0;
				//UnityChan跑步動畫設為true
				this.GetComponent<UnitychanController> ().Runbool = true;
			}
		}

		//如果玩家進入遊戲
		if(PlayerEnterMissionBool == true){
			//初始關卡種類 關卡種類:關卡A - 關卡C 隨機選1個
			int RandMissionintindex = Random.Range (0, MissionCateMax);
			//生成關卡:設定關卡位置
			Instantiate (MissionArea [RandMissionintindex], new Vector3 (-0.8344555f, -2.068496f, 331.3f + (MissionAreaindex*6.8f) ), Quaternion.identity);

			//將玩家進入遊戲設為false防止再次生成關卡
			PlayerEnterMissionBool = false;
		}

		//開啟新關卡
		if(GameRestartBool)GameRestartTime = GameRestartTime + Time.deltaTime;  //計算時間用於讓在畫面中的關卡銷毀
		if (GameRestartTime > 0.5f) {  //銷毀完畢
			GameRestartTime = 0.0f;  
			NewGameBool = true;        //設定開啟新關卡 = true
			GameRestartBool = false;   //停止銷毀
		}
			
		if (NewGameBool) {
			//初始關卡1隨機值 關卡種類:關卡A - 關卡C 隨機選1個
			int RandMissionint1 = Random.Range (0, MissionCateMax);
			//生成關卡1:設定關卡1位置
			Instantiate (MissionArea [RandMissionint1], new Vector3 (-0.8344555f, -2.068496f, 337.366f), Quaternion.identity);

			//初始關卡2隨機值 關卡種類:關卡A - 關卡C 隨機選1個
			int RandMissionint2 = Random.Range (0, MissionCateMax);
			//生成關卡2:設定關卡2位置
			Instantiate (MissionArea [RandMissionint2], new Vector3 (-0.8344555f, -2.068496f, 344.366f), Quaternion.identity);

			//重置海洋位置
			SeaArea.GetComponent<Transform> ().position = new Vector3 (-0.99f,-1.7f,468.2f);

			NewGameBool = false;  //防止重新生成關卡
		}
			
			
	}//Update



	//按鈕功能:向左走
	public void LeftMoveButton(){
		//如果沒有向右走，設定向左走，並播放向左走動畫
		if (RightMoveBool == false) {
			LeftMoveBool = true;
			this.GetComponent<UnitychanController> ().RunLbool = true;
			//換方向音效
			MoveVoice.Play();
		}
	}

	//按鈕功能:向右走
	public void RightMoveButton(){
		//如果沒有向左走，設定向右走，並播放向右走動畫
		if (LeftMoveBool == false) {
			RightMoveBool = true;
			this.GetComponent<UnitychanController> ().RunRbool = true;
			//換方向音效
			MoveVoice.Play();
		}
	}

	//按鈕功能:暫停
	public void GamePause(){
		if (GamePauseBool) {
			StartGameBool = true;
			GamePauseBool = false;
			//print ("false");
		} else {
			StartGameBool = false;
			GamePauseBool = true;
			//print ("true");
		}
	}
		

	//UnityChan碰撞事件
	void OnControllerColliderHit(ControllerColliderHit UnityChanhit){
		
		//依照UnityChan碰到的物件Tag，執行不同動作
		switch(UnityChanhit.gameObject.tag){
		 //UnityChan抵達終點 
		case "GoalHouse":
			Debug.Log ("Win");

			//將StartGameBool設為fasle
			StartGameBool = false;
			//將EndGameBool設為true
			EndGameBool = true;
			//將UnityChan移動到起點，準備下一場遊戲
			this.GetComponent<Transform> ().position = new Vector3 (-1.7f, -0.41f, 325.09f);
			//UnityChan勝利動畫設為true
			this.GetComponent<UnitychanController> ().Winbool = true;
			//切換攝影機位置到UnityChan正面
			MainCamera.GetComponent<Transform> ().position = new Vector3 (-1.8f, 0.3f, 326f);
			MainCamera.GetComponent<Transform> ().rotation = Quaternion.Euler (0, 180, 0);

			//勝利音樂
			WinMusic.Play();

			//顯示重新遊戲Button
			GameRestartButton.interactable = true;

			//顯示總分畫面
			SumPlane.SetActive (true);
			//設定總分Text
			SumText.text = " " + (LiveNumber*5 + TreasureNumber*10 + ScoreNumber*20);

			break;

		//UnityChan掉落海
		case "SeaArea":
			Debug.Log ("Lose");


			//將StartGameBool設為fasle
			StartGameBool = false;
			//將EndGameBool設為true
			EndGameBool = true;
			//將UnityChan移動到起點，準備下一場遊戲
			this.GetComponent<Transform> ().position = new Vector3 (-1.7f, -0.41f, 325.09f);
			//UnityChan失敗動畫設為true
			this.GetComponent<UnitychanController> ().Losebool = true;
			//切換攝影機位置到UnityChan正面
			MainCamera.GetComponent<Transform> ().position = new Vector3 (-1.8f, 0.3f, 326f);
			MainCamera.GetComponent<Transform> ().rotation = Quaternion.Euler (0, 180, 0);

			//失敗音樂
			LoseMusic.Play();

			//顯示重新遊戲Button
			GameRestartButton.interactable = true;

			//顯示總分畫面
			SumPlane.SetActive (true);
			//設定總分Text
			SumText.text = " " + (LiveNumber*5 + TreasureNumber*10 + ScoreNumber*20);

			break;

			//UnityChan掉落海
		case "Hurdle":
			Debug.Log ("Lose");


			//將StartGameBool設為fasle
			StartGameBool = false;
			//將EndGameBool設為true
			EndGameBool = true;
			//將UnityChan移動到起點，準備下一場遊戲
			this.GetComponent<Transform> ().position = new Vector3 (-1.7f, -0.41f, 325.09f);
			//UnityChan失敗動畫設為true
			this.GetComponent<UnitychanController> ().Losebool = true;
			//切換攝影機位置到UnityChan正面
			MainCamera.GetComponent<Transform> ().position = new Vector3 (-1.8f, 0.3f, 326f);
			MainCamera.GetComponent<Transform> ().rotation = Quaternion.Euler (0, 180, 0);

			//失敗音樂
			LoseMusic.Play();

			//顯示重新遊戲Button
			GameRestartButton.interactable = true;

			//顯示總分畫面
			SumPlane.SetActive (true);
			//設定總分Text
			SumText.text = " " + (LiveNumber*5 + TreasureNumber*10 + ScoreNumber*20);

			break;

	 }
	}//UnityChan碰撞事件

	//UnityChan觸發事件
	void OnTriggerEnter(Collider UnityChanTrigger){

	  switch(UnityChanTrigger.tag){

		//如果UnityChan遇到NormalGround
		case "NormalGround":
			//跳躍動作設為false
			JumpBool = false;
			//跳躍動畫設為false
			this.GetComponent<UnitychanController> ().Jumpbool = false;
			break;


		//如果UnityChan遇到MissionTrigger
		case "MissionTrigger": 
			if (UnityChanTrigger.tag == "MissionTrigger") {
				//生成關卡數量 < 可生成關卡數量最大值
				if (MissionAreaindex < MissionAreaMax) {
					//生成關卡數量 + 1
					MissionAreaindex = MissionAreaindex + 1;
					//玩家進入遊戲
					PlayerEnterMissionBool = true;
				} 
			//生成關卡數量 等於 可生成關卡數量最大值
			else if (MissionAreaindex == MissionAreaMax) {
					//設定終點區域的角度
					Quaternion EndAreaRotation = Quaternion.Euler (0, 180, 0);
					//生成終點區域
					Instantiate (EndArea, new Vector3 (-3.83f, 0.0f, 331.3f + (MissionAreaindex * 7)), EndAreaRotation);
					//生成關卡數量 + 1，防止再次生成終點區域
					MissionAreaindex = MissionAreaindex + 1;
				}
		
			}
			break;


		//如果UnityChan遇到Goldcoin
		case "Goldcoin":
			Random.seed = System.Guid.NewGuid ().GetHashCode ();
			int Gold = Random.Range (1, 11);
			ScoreNumber = ScoreNumber + Gold;
			ScoreText.text = "X" + ScoreNumber;
			DestoryVoice.Play ();
			break;

		//如果UnityChan遇到TreasureBox
		case "TreasureBox":
			TreasureNumber = TreasureNumber + 1;
			TreasureText.text = "X" + TreasureNumber;
			DestoryVoice.Play ();
			break;

		//如果UnityChan遇到Waffle
		case "Waffle":
			LiveNumber = LiveNumber + 1;
			LiveText.text = "X" + LiveNumber;
			DestoryVoice.Play ();
			break;




	  }
	}//UnityChan觸發事件


	//副程式:遊戲重新開始
	public void GameRestart(){
		//定義角色控制器 = UnityChan的角色控制器
		UnityChan = this.GetComponent<CharacterController> ();
		//UnityChan跑步動畫設為false
		this.GetComponent<UnitychanController> ().Runbool = false;
		//UnityChan向左跑步動畫設為false
		this.GetComponent<UnitychanController> ().RunLbool = false;
		//UnityChan向右跑步動畫設為false
		this.GetComponent<UnitychanController> ().RunRbool = false;
		//UnityChan跳躍動畫設為false
		this.GetComponent<UnitychanController> ().Jumpbool = false;
		//UnityChan勝利動畫設為false
		this.GetComponent<UnitychanController> ().Winbool = false;
		//UnityChan失敗動畫設為false
		this.GetComponent<UnitychanController> ().Losebool = false;

		//重新遊戲
		GameRestartBool = true;

		//開始遊戲設為false
		StartGameBool = false;
		//結束遊戲設為false
		EndGameBool = false;
		//開始遊戲時間設為0秒
		StartGameTimer = 0;
		//向左移動設為false
		LeftMoveBool = false;          
		//向右移動設為false
		RightMoveBool = false;                   
		//跳躍設為false
		JumpBool = false;          
		//水平移動計時器設為0秒
		HoriztalMoveTimer = 0.0f;                

		//勝利音樂
		WinMusic.Stop();
		//失敗音樂
		LoseMusic.Stop();

		//重新遊戲Button設為不可用
		GameRestartButton.interactable = false;

		//隱藏總分畫面
		SumPlane.SetActive (false);

		//玩家是否進入新關卡 預設 = fasle
		PlayerEnterMissionBool = false;
		//生成關卡當前數量，已生成關卡1和2所已數量為 0 + 2 = 2關
		MissionAreaindex = 2;
		//生成關卡最大數量預設為6，所以會在生成4關
		MissionAreaMax = 6;



		//設定CameraFollowVector的位置
		CameraFollowVector = new Vector3 (UnityChanPosition.x, 0.89f, UnityChanPosition.z - 1.0f);
		//依照CameraFollowVector 設定MainCamera的位置
		MainCamera.GetComponent<Transform> ().position = CameraFollowVector;
		MainCamera.GetComponent<Transform> ().rotation = Quaternion.Euler (34.6f, 0, 0);


	}


}//UnityChanControll
