//類別:遊戲資料
using UnityEngine;
using System.Collections;
using System.Timers;
using UnityEngine.UI;

public class GameDetail_Class : MonoBehaviour {

	//宣告屬性----------------------------------------------------
	//圖片
	private Sprite Game_Image;
	//名稱
	private string Game_Name;
	//英文名稱
	private string Game_EName;
	//語言
	private string Game_Language;
	//日期
	private string Game_Date;

	//宣告UI
	//圖片
	public Image Game_UI_Image;
	//名稱
	public Text Game_Name_Text;
	//英文名稱
	public Text Game_EName_Text;
	//語言
	public Text Game_Language_Text;
	//日期
	public Text Game_Date_Text;

	//建構子--------------------------------------------------------------------------------------------------
	public GameDetail_Class (Sprite game_Image, string game_Name , string game_ename, string game_Language, string game_Date){
		//屬性
		this.Game_Image = game_Image;
		this.Game_Name = game_Name;
		this.Game_EName = game_ename;
		this.Game_Language = game_Language;
		this.Game_Date = game_Date;

		//UI
		this.Game_UI_Image.sprite = game_Image;
		this.Game_Name_Text.text = "" + game_Name;
		this.Game_EName_Text.text = "" + game_ename;
		this.Game_Language_Text.text = "" + game_Language;
		this.Game_Date_Text.text = "" + game_Date;
	}

	//Setter-----------------------------------------------------------------------------------------------------
	//統一設定
	public void Set_All_Detail(Sprite GameIm , string GameName , string GameEName, string GameLanguage , string GameDate){
		//圖片
		Game_Image = GameIm;
		this.Game_UI_Image.sprite = GameIm;
		//名稱
		Game_Name = GameName;
		this.Game_Name_Text.text = "" + GameName;
		//英文名稱
		Game_EName = GameEName;
		this.Game_EName_Text.text = "" + GameEName;
		//語言
		Game_Language = GameLanguage;
		this.Game_Language_Text.text = "" + GameLanguage;
		//日期
		Game_Date = GameDate;
		this.Game_Date_Text.text = "" + GameDate;
	}

	//圖片
	public void Set_Game_Image(Sprite GameIm){
		Game_Image = GameIm;
		this.Game_UI_Image.sprite = GameIm;
	}

	//名稱
	public void Set_Game_Name(string GameName){
		Game_Name = GameName;
		this.Game_Name_Text.text = "" + GameName;
	}

	//英文名稱
	public void Set_Game_EName(string GameEName){
		Game_EName = GameEName;
		this.Game_EName_Text.text = "" + GameEName;
	}

	//語言
	public void Set_Game_Language(string GameLanguage){
		Game_Language = GameLanguage;
		this.Game_Language_Text.text = "" + GameLanguage;
	}

	//日期
	public void Set_Game_Date(string GameDate){
		Game_Date = GameDate;
		this.Game_Date_Text.text = "" + GameDate;
	}

	//Getter-----------------------------------------------------------------------------------------------------
	//圖片
	public Sprite Get_Game_Image(){
		return Game_Image;
	}

	//名稱
	public string Get_Game_Name(){
		return Game_Name;
	}

	//英文名稱
	public string Get_Game_EName(){
		return Game_EName;
	}

	//語言
	public string Get_Game_Language(){
		return Game_Language;
	}

	//日期
	public string Get_Game_Date(){
		return Game_Date;
	}
	
}//GameDetail_Class
