/*
 *載入場景Script
 *
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//使用SceneManagement，取代Application
using UnityEngine.SceneManagement;

public class LoadScene_Script : MonoBehaviour
{

    //======================================
    //載入GameScene
    //======================================
    public void Load_GameScene() {
        //載入GameScene
        SceneManager.LoadScene("GameScene");
    }




}//LoadScene_Script
