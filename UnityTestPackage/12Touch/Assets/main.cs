using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkWIN();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pressStart();
        }
        if (Input.GetKeyDown("a"))
        {
            GameObject.Find("Red_block").GetComponent<block>().stopthis();
            GameObject.Find("Right").transform.localScale += new Vector3(0.5f, 0, 0);

        }
        if (Input.GetKeyDown("l"))
        {
            GameObject.Find("Blue_block").GetComponent<block>().stopthis();
            GameObject.Find("Left").transform.localScale += new Vector3(0.5f, 0, 0);
        }
        if (Input.GetKeyUp("a"))
        {
            GameObject.Find("Right").transform.localScale = new Vector3(1, -0.07018062f, 1);

        }
        if (Input.GetKeyUp("l"))
        {
            GameObject.Find("Left").transform.localScale = new Vector3(1, -0.07018062f, 1);
        }
    }
    void checkWIN()
    {
        if (GameObject.Find("Red_block").GetComponent<block>().end &&
        GameObject.Find("Blue_block").GetComponent<block>().end)
        {
            if (GameObject.Find("Red_block").GetComponent<block>().s > GameObject.Find("Blue_block").GetComponent<block>().s)
            {
                GameObject.Find("TextA").GetComponent<UnityEngine.UI.Text>().text = "Win";
                GameObject.Find("TextL").GetComponent<UnityEngine.UI.Text>().text = "Lose";
            }
            else
            {
                GameObject.Find("TextA").GetComponent<UnityEngine.UI.Text>().text = "Lose";
                GameObject.Find("TextL").GetComponent<UnityEngine.UI.Text>().text = "Win";
            }

        }

    }

    public void pressStart()
    {
        GameObject.Find("TextA").GetComponent<UnityEngine.UI.Text>().text = "Press A";
        GameObject.Find("TextL").GetComponent<UnityEngine.UI.Text>().text = "Press L";
        GameObject.Find("TextA_S").GetComponent<UnityEngine.UI.Text>().text = "0";
        GameObject.Find("TextL_S").GetComponent<UnityEngine.UI.Text>().text = "0";
        GameObject.Find("CountDown").GetComponent<countDown>().go();
    }
}
