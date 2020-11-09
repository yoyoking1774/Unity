//類別:數獨數字
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sudoku : MonoBehaviour {

	//宣告變數*******************************************************
	//屬性:編號
	private int Sudoku_Nober = 0;
	//屬性:數字
	private int Sudoku_Number = 1;
	//屬性:是否為參考數字 true:是 false:不是
	private bool Sudoku_Bool = false;


	// Use this for initialization
	void Start () {
	
	}//Start
	
	// Update is called once per frame
	void Update () {
	
	}//Update

	//建構子
	public Sudoku(){
		Sudoku_Nober = 0;
		Sudoku_Number = 0;
		Sudoku_Bool = false;
	}

	//建構子(多載)
	public Sudoku(int Sudoku_Nober_Value , int Sudoku_Number_Value , bool Sudoku_Bool_Value){
		Sudoku_Nober = Sudoku_Nober_Value;
		Sudoku_Number = Sudoku_Number_Value;
		Sudoku_Bool = Sudoku_Bool_Value;
	}

	//副程式:取得數獨編號
	public int Get_Sudoku_Nober(){
		return Sudoku_Number;
	}

	//副程式:設定數獨編號
	public void Set_Sudoku_Nober(int Value){
		Sudoku_Nober = Value;
	}

	//副程式:取得數獨數字
	public int Get_Sudoku_Number(){
		return Sudoku_Number;
	}

	//副程式:設定數獨數字
	public void Set_Sudoku_Number(int Value){
		Sudoku_Number = Value;
	}

	//副程式:取得是否為參考數字
	public bool Get_Sudoku_Bool(){
		return Sudoku_Bool;
	}

	//副程式:設定是否為參考數字
	public void Set_Sudoku_Bool(bool Value){
		Sudoku_Bool = Value;
	}
		





}//Sudoku
