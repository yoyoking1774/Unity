using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicText_Script : MonoBehaviour
{
    //=========================================================
    //宣告變數
    //=========================================================
    //隨機數
    private int Number;


    //=========================================================
    //宣告UI
    //=========================================================
    //Button
    public Button button;

    //Text
    public TextMesh ARtext;
    




    // Start is called before the first frame update
    void Start()
    {
        Random.seed = System.Guid.NewGuid().GetHashCode();
    }



    //=====================================================
    //Button功能
    //=====================================================
    public void PushButton() {
        Number = Random.Range(0, 10);

        ARtext.text = "隨機數: " + Number; 
    }


}
