/*
 * Scene載入腳本
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    //====================================
    //載入GameScene
    //====================================
    public void Load_GameScene() {
        SceneManager.LoadScene("GameScene");
    }

}//LoadScene
