//LoadingBar顯示載入進度
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading_Script : MonoBehaviour
{
    //=======================================
    //宣告變數
    //=======================================
    //UI平台Canvas
    public GameObject Canvas_GameObject;
    //進度條
    private Image LoadBar_In;
    //進度條文字
    private Text Load_Number_Text;

    void Start()
    {
        //綁定進度條，抓取Canvas_GameObject底下的子物件(LoadBar_Out)的子物件(LoadBar__In)
        LoadBar_In = Canvas_GameObject.transform.GetChild(1).transform.GetChild(0).GetComponent<UnityEngine.UI.Image>();
        //綁定進度條文字，抓取Canvas_GameObject底下的子物件(Load_Number_Text)
        Load_Number_Text = Canvas_GameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
        //啟用IEnumerator
        StartCoroutine(LoadScene("SampleScene")); 
    }

    //=======================================
    //進度條協程(string 要載入的場景)
    //=======================================
    IEnumerator LoadScene(string sceneName)
    {
        //UI顯示的進度數字
        int displayProgress = 0;
        //實際執行載入中的進度數字
        int toProgress = 0;
        //宣告非同步執行，載入要載入的場景
        AsyncOperation asyncOperation = Application.LoadLevelAsync(sceneName);
        //防止Unity加載完畢後直接切換場景的問題
        asyncOperation.allowSceneActivation = false;

        //*************************
        //如果尚未載入全部資源
        //*************************
        while (asyncOperation.progress < 0.9f)
        {
            //toProgress = 現在實際載入的資源
            toProgress = (int)(asyncOperation.progress * 100);
            //如果UI顯示的進度數字 < 實際執行載入中的進度數字
            while (displayProgress < toProgress)
            {
                //將每一幀的UI顯示的進度數字+1，以呈現連貫加載數字的畫面
                ++displayProgress;
                //設定進度條UI
                SetLoadingPercentage(displayProgress);
                //等待這一幀結束,等待直到所有的攝像機和GUI被渲染完成後，在該幀顯示在螢幕之前執行
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForEndOfFrame();

        }//while (asyncOperation.progress < 0.9f)

        //*************************
        //全部資源載入完成
        //*************************
        //實際執行載入中的進度數字 = 100，表示全部資源載入完成
        toProgress = 100;

        //如果UI顯示的進度數字 < 實際執行載入中的進度數字，則將UI顯示的進度數字逐漸加到100
        while (displayProgress < toProgress)
        {
            ++displayProgress;
            SetLoadingPercentage(displayProgress);
            yield return new WaitForEndOfFrame();
        }
        //載入場景
        asyncOperation.allowSceneActivation = true;

    }//LoadScene

    //=======================================
    //設定進度條UI
    //=======================================
    void SetLoadingPercentage(int percentage)
    {
        LoadBar_In.fillAmount = (float)percentage / 100;
        Load_Number_Text.text = percentage + "%";
    }//SetLoadingPercentage


}//Loading_Script
