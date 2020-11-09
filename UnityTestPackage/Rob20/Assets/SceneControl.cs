//遊戲啟動畫面
/*
原理是先抓視窗的長與寬，再計算出他的位置
場景是title的話方在畫面的中下方，場景是play的話就放在右上角
*/
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;

public class SceneControl : MonoBehaviour
{
	public NetworkManagerHUD hud;

	void Start()
	{
		hud = gameObject.GetComponent<NetworkManagerHUD>();
	}

	void Update()
	{
		if (SceneManager.GetActiveScene().name == "Title")
		{
			hud.offsetX = Screen.width / 2 - 100; 
			hud.offsetY = Screen.height - 200;
		}
		else
		{
			hud.offsetX = Screen.width - 250 ;
			hud.offsetY = 20;
		}
	}
}