//數獨答案判定
using UnityEngine;
using System.Collections;

public class Answer_Check : MonoBehaviour {
	
	//答案表
	public static int[,] Answer_Array = new int[,]
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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//副程式:數獨答案判定
	public static bool Check(){
		//共有九大格要檢查，一次檢查一大格
		for (int i = 0; i <= 8; i++) {
			int N = 4;
			//每1大格中間格子的編號
			N = 4 + (i*9);

			//從中間格子為主比較外圍8個格子的數字，一但有一大格是錯的則結束檢查，但只比較不是參考數字，以減少比較次數
			if (Main_Executive.Sudoku_Array [N].Get_Sudoku_Number () != Answer_Array[Main_Executive.Question_Number,N] && Main_Executive.Sudoku_Array[N].Get_Sudoku_Bool()==false)
				return false;
			else if (Main_Executive.Sudoku_Array [N - 4].Get_Sudoku_Number () != Answer_Array [Main_Executive.Question_Number,N - 4] && Main_Executive.Sudoku_Array[N - 4].Get_Sudoku_Bool()==false)
				return false;
			else if (Main_Executive.Sudoku_Array [N - 3].Get_Sudoku_Number () != Answer_Array [Main_Executive.Question_Number,N - 3] && Main_Executive.Sudoku_Array[N - 3].Get_Sudoku_Bool()==false)
				return false;
			else if (Main_Executive.Sudoku_Array [N - 2].Get_Sudoku_Number () != Answer_Array [Main_Executive.Question_Number,N - 2] && Main_Executive.Sudoku_Array[N - 2].Get_Sudoku_Bool()==false)
				return false;
			else if (Main_Executive.Sudoku_Array [N - 1].Get_Sudoku_Number () != Answer_Array [Main_Executive.Question_Number,N - 1] && Main_Executive.Sudoku_Array[N - 1].Get_Sudoku_Bool()==false)
				return false;
			else if (Main_Executive.Sudoku_Array [N + 1].Get_Sudoku_Number () != Answer_Array [Main_Executive.Question_Number,N + 1] && Main_Executive.Sudoku_Array[N + 1].Get_Sudoku_Bool()==false)
				return false;
			else if (Main_Executive.Sudoku_Array [N + 2].Get_Sudoku_Number () != Answer_Array [Main_Executive.Question_Number,N + 2] && Main_Executive.Sudoku_Array[N + 2].Get_Sudoku_Bool()==false)
				return false;
			else if (Main_Executive.Sudoku_Array [N + 3].Get_Sudoku_Number () != Answer_Array [Main_Executive.Question_Number,N + 3] && Main_Executive.Sudoku_Array[N + 3].Get_Sudoku_Bool()==false)
				return false;
			else if (Main_Executive.Sudoku_Array [N + 4].Get_Sudoku_Number () != Answer_Array [Main_Executive.Question_Number,N + 4] && Main_Executive.Sudoku_Array[N + 4].Get_Sudoku_Bool()==false)
				return false;
		}
			//上面都沒檢查出錯誤表示正確，回傳true
			return true;

	}//Check()


		/*print (Answer_Check.Answer_Array [0] + " " + Answer_Check.Answer_Array [1] + " " + Answer_Check.Answer_Array [2]);
		print (Answer_Check.Answer_Array [3] + " " + Answer_Check.Answer_Array [4] + " " + Answer_Check.Answer_Array [5]);
		print (Answer_Check.Answer_Array [6] + " " + Answer_Check.Answer_Array [7] + " " + Answer_Check.Answer_Array [8]);
		print (Sudoku_Array [0].Get_Sudoku_Number () + " " + Sudoku_Array [1].Get_Sudoku_Number () + " " + Sudoku_Array [2].Get_Sudoku_Number ());
		print (Sudoku_Array [3].Get_Sudoku_Number () + " " + Sudoku_Array [4].Get_Sudoku_Number () + " " + Sudoku_Array [5].Get_Sudoku_Number ());
		print (Sudoku_Array [6].Get_Sudoku_Number () + " " + Sudoku_Array [7].Get_Sudoku_Number () + " " + Sudoku_Array [8].Get_Sudoku_Number ());
		
		9,10,11,
		12,13,14,
		15,16,17,

		18,19,20,
		21,22,23,
		24,25,26,

		27,28,29,
		30,31,32,
		33,34,35,

		36,37,38,
		39,40,41,
		42,43,44,

		45,46,47,
		48,49,50,
		51,52,53,

		54,55,56,
		57,58,59,
		60,61,62,

		63,64,65,
		66,67,68,
		69,70,71,

		72,73,74,
		75,76,77,
		78,79,80

		0,1,2,
		3,4,5,
		6,7,8,

		0,1,2,
		3,4,5,
		6,7,8,

		0,1,2,
		3,4,5,
		6,7,8,

		0,1,2,
		3,4,5,
		6,7,8,

		0,1,2,
		3,4,5,
		6,7,8,

		0,1,2,
		3,4,5,
		6,7,8,

		0,1,2,
		3,4,5,
		6,7,8,

		0,1,2,
		3,4,5,
		6,7,8,

		0,1,2,
		3,4,5,
		6,7,8

	*/
	


}//Answer_Check