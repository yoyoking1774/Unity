//拖曳視窗腳本
using UnityEngine;
using System.Collections;

public class DragWindows_Script : MonoBehaviour {

	//宣告變數**************************************
	public Vector2 prePos;

	//副程式:抓取滑鼠按下時的座標
	void OnMouseDown(){
		prePos = Input.mousePosition;
	}//OnMouseDown

	//副程式:計算拖曳位置，並改變視窗位置
	void OnMouseDrag(){
		//抓取panel上的RectTransform
		RectTransform rect = GetComponent<RectTransform>();
		//計算移動後的位置，新的位置 - 上面滑鼠按下時的位置
		rect.anchoredPosition = rect.anchoredPosition + ((Vector2)Input.mousePosition - (Vector2)prePos);
		//將舊座標設為移動後的座標
		prePos =  Input.mousePosition;
	}//OnMouseDown


}//DragWindows_Script
