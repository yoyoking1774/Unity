//TopBar_UI腳本
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BottomBar : MonoBehaviour {

	//宣告UI---------------------------------------------------
	//Search按扭
	public Button Search_Button;
	//PS平台按扭
	public Button PS_Button;
	//Xbox平台按扭
	public Button Xbox_Button;
	//PC平台按扭
	public Button PC_Button;
	//Nibtendo平台按扭
	public Button Nintendo_Button;
	//Android平台按扭
	public Button Android_Button;
	//ios平台按扭
	public Button ios_Button;

	//SearchPage
	public GameObject SearchPageGameObject;

	//副程式:使用平台切換按扭(平台編號)
	public void Update_ButtomBar(int PageNumber){
		//先將全部按扭設為可用
		Search_Button.interactable = true;
		PS_Button.interactable = true;
		Xbox_Button.interactable = true;
		PC_Button.interactable = true;
		Nintendo_Button.interactable = true;
		ios_Button.interactable = true;
		//隱藏搜尋欄
		SearchPageGameObject.SetActive (false);

		//再將選定的平台按扭設為不可用
		switch (PageNumber) {
		//PS
		case 0:
			PS_Button.interactable = false;
			break;
		//Xbox
		case 1:
			Xbox_Button.interactable = false;
			break;
		//PC
		case 2: 
			PC_Button.interactable = false;
			break;
		//Nintendo
		case 3: 
			Nintendo_Button.interactable = false;
			break;
		//Android
		case 4:
			Android_Button.interactable = false;
			break;
		//ios
		case 5:
			ios_Button.interactable = false;
			break;
		//如果沒有，Search按扭設為不可用
		default:
			Search_Button.interactable = false;
			//顯示搜尋欄
			SearchPageGameObject.SetActive (true); 
			break;
		
		}//switch
	}//Update_ButtomBar

}//BottomBar
