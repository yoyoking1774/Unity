//測試存檔
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartSave : MonoBehaviour {


	//存檔類別****************
	SaveGame Sav = new SaveGame();

	//UI
	public Text Score_1;
	public Text Score_2;
	public Text hp;
	public Text Name;
	public Image Icon;
	public Sprite[] Icon_Picture;

	// Use this for initialization
	void Start () {
		

	}//Start
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Sav.Score [0]++;
			Sav.Score [1]--;
			Sav.hp = Sav.hp + 0.3f;
			Sav.Name = Sav.Name + "o";
			print ("功");
		}


		if (Input.GetKeyDown (KeyCode.S))
			DoSave ();

		if (Input.GetKeyDown (KeyCode.L))
			DoLoad ();
	}//Update

	//副程式:存檔
	void DoSave(){
		PlayerPrefs.SetString ("SaveFile_1", JsonUtility.ToJson (Sav));
		print (PlayerPrefs.GetString("SaveFile_1"));
		print ("存檔成功");
	}

	//副程式:讀檔
	void DoLoad(){
		JsonUtility.FromJsonOverwrite (PlayerPrefs.GetString("SaveFile_1") , Sav);
		Score_1.text = Sav.Score[0] + ""; 
		Score_2.text = Sav.Score[1] + ""; 
		hp.text = Sav.hp + "";
		Name.text = Sav.Name + "";
		Icon.sprite = Icon_Picture [Sav.icon];

		print ("讀檔成功");
	}


}//StartSave
