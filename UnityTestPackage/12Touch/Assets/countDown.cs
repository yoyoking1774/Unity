using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countDown : MonoBehaviour
{
    bool gogo;
    float goTime;
    int textN;

    // Use this for initialization
    void Start()
    {
        gogo = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (gogo)
        {

            if (Time.time - goTime > 1)
            {

                goTime = Time.time;
                textN--;
                GameObject.Find("CountDown").GetComponent<UnityEngine.UI.Text>().text = textN.ToString("F0");
            }
            if (textN == 0)
            {
                GameObject.Find("Red_block").GetComponent<block>().goStartPos();
                GameObject.Find("Blue_block").GetComponent<block>().goStartPos();
                GameObject.Find("TextA_S").GetComponent<UnityEngine.UI.Text>().text = "";
                GameObject.Find("TextL_S").GetComponent<UnityEngine.UI.Text>().text = "";
                GameObject.Find("Red_block").GetComponent<block>().go();
                GameObject.Find("Blue_block").GetComponent<block>().go();
                GameObject.Find("CountDown").GetComponent<UnityEngine.UI.Text>().text = "Go";
                textN = 3;
                gogo = false;
            }

        }

    }

    public void go()
    {
        gogo = true;
        goTime = Time.time;
        textN = 3;
        GameObject.Find("CountDown").GetComponent<UnityEngine.UI.Text>().text = "3";
        GameObject.Find("Red_block").GetComponent<block>().goStartPos();
        GameObject.Find("Blue_block").GetComponent<block>().goStartPos();

    }
}
