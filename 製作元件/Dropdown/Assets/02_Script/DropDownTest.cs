using UnityEngine;
using System.Collections;

public class DropDownTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//下拉式選單自訂
	public void ConsoleResult(int value)
	{
		//這裡用 if else if也可，看自己喜欢
		//分別對應第1項、第2項.........
		switch (value) {
		case 0:
			//要做的事情
			print ("第1項");
			break;
		case 1:
			print ("第2項");
			break;
		case 2:
			print ("第3項");
			break;
		case 3:
			print ("第4項");
			break;

		//有多少case就要在DropDown中手動增加
		case 4:
			print ("第5页");
			break;
		}//switch
	}//ConsoleResult



}//DropDownTest
