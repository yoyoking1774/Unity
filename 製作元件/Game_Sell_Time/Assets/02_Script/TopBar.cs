//TopBar_UI腳本
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TopBar : MonoBehaviour {

	//宣告變數--------------------------------------------
	//頁面圖片Sprite
	public Sprite[] PageImageSprite = new Sprite[4];

	//宣告UI----------------------------------------------
	//頁面名稱
	public Text PageName_Text;
	//頁面圖片
	public Image Page_Image;


	//副程式:更新TopBar的UI
	public void UpDate_TopBar_UI(){
		switch (PageChangeScript.PageNumber){
		//PS平台
		case 0:
			//設定頁面名稱
			PageName_Text.text = "PS4";
			//設定頁面圖片
			Page_Image.sprite = PageImageSprite [0];
			break;
		//Xbox平台
		case 1:
			//設定頁面名稱
			PageName_Text.text = "Xbox";
			//設定頁面圖片
			Page_Image.sprite = PageImageSprite [1];
			break;
		//PC平台
		case 2:
			//設定頁面名稱
			PageName_Text.text = "PC";
			//設定頁面圖片
			Page_Image.sprite = PageImageSprite[2];
			break;
		//Nintendo平台
		case 3:
			//設定頁面名稱
			PageName_Text.text = "Nintendo";
			//設定頁面圖片
			Page_Image.sprite = PageImageSprite[3];
			break;
			//Nintendo平台
		case 4:
			//設定頁面名稱
			PageName_Text.text = "Android";
			//設定頁面圖片
			Page_Image.sprite = PageImageSprite[4];
			break;
			//Nintendo平台
		case 5:
			//設定頁面名稱
			PageName_Text.text = "ios";
			//設定頁面圖片
			Page_Image.sprite = PageImageSprite[5];
			break;
		//搜尋頁面
		default:
			//設定頁面名稱
			PageName_Text.text = "搜尋";
			//設定頁面圖片
			Page_Image.sprite = PageImageSprite [6];
			break;

		}//switch
	}//UpDate_TopBar_UI

}//TopBar
