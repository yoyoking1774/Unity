//動畫控制腳本
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Animation_Controll : MonoBehaviour {

	//宣告變數------------------------------------------------------------
	//執行哪一個動畫(0:不執行 1:輸入條上升 2:輸入條下降 )
	public static int Animation_Number = 0;

	//宣告物件------------------------------------------------------------
	//用於抓取在Input_Bar身上的Animator
	public GameObject Input_Bar_GameObject;
	//宣告動畫------------------------------------------------------------
	public Animator Input_Bar_Animator;
	//Input_Bar_Up
	//public Animation Input_Bar_Up_Animation;
	//Input_Bar_Down
	//public Animation Input_Bar_Down_Animation;


	// Use this for initialization
	void Start () {
		Input_Bar_Animator = Input_Bar_GameObject.GetComponent<Animator>();
	}//Start
	
	// Update is called once per frame
	void Update () {
		//播放--------------------------------------------------------------
		//播放Input_Bar_Up
		if(Animation_Number == 1){
			Input_Bar_Animator.SetInteger("Input_Bar_Number",Animation_Number);
		}//if(Animation_Number == 1)
		//播放Input_Bar_Down
		else if(Animation_Number == 2){
			Input_Bar_Animator.SetInteger("Input_Bar_Number",Animation_Number);
		}//if(Animation_Number == 2)



	}//Update




}//Animation_Controll
