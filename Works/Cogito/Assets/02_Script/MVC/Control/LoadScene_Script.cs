using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene_Script : MonoBehaviour
{

    //===========================================================================================
    //Function(外部)
    //===========================================================================================
    public void LoadScene(string scenename)
    {
        // Use a coroutine to load the Scene in the background
        StartCoroutine(LoadAsyncScene(scenename));
    }

    //===========================================================================================
    //Function(內部)
    //===========================================================================================

    //協程:用於在背景載入場景(名稱可自訂)
    IEnumerator LoadAsyncScene(string scenename)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scenename);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }


    }



}