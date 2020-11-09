//音樂音效控制
using UnityEngine;
using System.Collections;

public class MusicControl : MonoBehaviour {

	//宣告變數
	public AudioSource JumpVoice1; //跳躍聲音1
	public AudioSource JumpVoice2; //跳躍聲音2


	// Use this for initialization
	void Start () {
	
	}//Start
	
	// Update is called once per frame
	void Update () {
		//按下空白健播放跳躍音效
		if(Input.GetKeyDown (KeyCode.Space)){
			Random.seed = System.Guid.NewGuid().GetHashCode();
			int rand = Random.Range(1, 11);
			if (rand <= 5)JumpVoice1.Play ();
			else JumpVoice2.Play ();
		}


	
	}//Update
}
