//生成數獨題目
using UnityEngine;
using System.Collections;

public class Create_Sudoku_Question : MonoBehaviour {

	//宣告變數*****************************************************
	//預設題目[10][81]，共10題每1題有81個數字
	public static int [,] Initial_Question = new int[,]
	{
		{6,3,5,
		 7,4,8,
		 2,1,9,

		9,4,7,
		1,5,2,
		8,6,3,

		2,8,1,
		9,3,6,
		5,4,7,

		4,7,6,
		8,9,3,
		1,5,2,

		3,9,1,
		5,2,6,
		4,7,8,

		8,5,2,
		7,1,4,
		6,9,3,

		3,6,1,
		9,8,7,
		5,2,4,

		7,8,5,
		2,3,4,
		6,1,9,

		4,2,9,
		1,6,5,
		3,7,8},

		{6,3,5,
		1,8,9,
		2,4,7,

		7,1,9,
		2,5,4,
		8,3,6,

		4,8,2,
		6,7,3,
		5,1,9,

		4,5,1,
		7,2,8,
		3,9,6,

		3,2,8,
		6,9,5,
		1,4,7,

		7,9,6,
		1,3,4,
		2,5,8,

		9,6,4,
		8,1,2,
		5,7,3,

		5,8,1,
		4,7,3,
		9,6,2,

		3,2,7,
		9,6,5,
		8,4,1},

		{3,6,9,
		7,4,1,
		2,5,8,

		8,4,7,
		5,9,2,
		1,3,6,

		2,1,5,
		8,6,3,
		9,4,7,

		4,7,3,
		1,8,6,
		5,9,2,

		6,8,5,
		9,2,3,
		4,7,1,

		1,9,2,
		7,5,4,
		3,8,6,

		6,3,5,
		8,1,7,
		9,2,4,

		7,1,9,
		2,6,4,
		3,5,8,

		4,2,8,
		5,3,9,
		6,7,1}

	};

	//預設參考數字[10][81]，共10題每1題有81個數字
	public static bool [,] Initial_Question_Sudoku_Bool = new bool[,]
	{
		{true , false , true,
		false,false,true,
		false,false,true,
		
		false,false,false,
		false,false,true,
		false,false,true,

		false,false,false,
		false,false,true,
		true,true,false,

		false,true,false,
		true,false,false,
		false,false,false,

		true,false,false,
		false,false,false,
		false,false,false,

		false,false,false,
		true,false,false,
		false,true,true,

		true,false,true,
		false,false,false,
		false,true,true,

		false,true,true,
		false,false,false,
		false,true,true,

		false,false,true,
		false,true,false,
		false,false,false},
		
		{false,false,true,
		false,false,false,
		true,false,false,

		true,true,true,
		false,false,false,
		false,false,false,

		false,false,false,
		false,false,false,
		false,false,false,

		false,true,false,
		false,false,false,
		true,false,false,

		false,true,false,
		false,true,false,
		false,false,false,

		true,false,true,
		true,false,false,
		true,true,false,

		false,true,true,
		true,true,false,
		false,false,false,

		true,false,true,
		false,false,true,
		false,false,true,

		false,false,true,
		false,false,true,
		false,true,false},

		{true,false,true,
			false,false,false,
			false,false,true,

			false,false,false,
			true,false,true,
			false,false,true,

			true,false,false,
			false,false,true,
			true,true,false,

			true,true,false,
			true,false,false,
			false,false,false,

			true,false,false,
			false,false,false,
			false,false,false,

			false,false,false,
			false,false,false,
			false,false,true,

			true,false,true,
			false,false,false,
			false,true,true,

			false,true,false,
			false,false,false,
			false,true,true,

			false,false,true,
			false,true,true,
			false,false,false}
	};
		

	// Use this for initialization[10][81][1]
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//副程式:生成數獨題目
	public static void Create_Question(){
		//題庫題目編號，從題庫隨機挑選(UnityEngine.Random.Range( 最小值, 最大值+1 );)
		Main_Executive.Question_Number = UnityEngine.Random.Range( 0, 3 );

		for(int i=0; i<Main_Executive.Sudoku_Array.Length; i++){
			//參考數字
			if (Initial_Question_Sudoku_Bool[Main_Executive.Question_Number,i] == true) {
				Main_Executive.Sudoku_Array [i].Set_Sudoku_Number (Answer_Check.Answer_Array[Main_Executive.Question_Number,i]);
				//設定為參考數字
				Main_Executive.Sudoku_Array [i].Set_Sudoku_Bool (true);
			}//if(i % 2 == 0)
			//不是參考數字
			else {
				Main_Executive.Sudoku_Array [i].Set_Sudoku_Number (0);
				//設定為不是參考數字
				Main_Executive.Sudoku_Array [i].Set_Sudoku_Bool (false);
			}//else
		}//for_i
	}//Create_Question


}//Create_Sudoku_Question
