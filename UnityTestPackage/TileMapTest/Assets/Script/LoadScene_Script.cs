//載入場景腳本
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("WaitAndGo",3);
    }

    void WaitAndGo() {
        Application.LoadLevel("SampleScene");
    }//WaitAndGo


}
