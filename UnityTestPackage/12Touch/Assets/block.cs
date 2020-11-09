using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    public bool end;
    public float s;
    bool gola;
    Vector3 startPos;

    // Use this for initialization
    void Start()
    {
        startPos = this.transform.position;
        end = false;
        gola = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (gola)
        {
            this.transform.position += Vector3.down * 0.1f * Random.RandomRange(0.5f, 5.5f);
            if (this.transform.position.y < -6)
            {
                GameObject.Find("TextA_S").GetComponent<UnityEngine.UI.Text>().text = "Miss";
                gola = false;
                end = true;
            }
        }

    }
    public void goStartPos()
    {
        this.transform.position = startPos;
        end = false;

    }
    public void go()
    {
        end = false;
        gola = true;

    }
    public void stopthis()
    {
        if (this.name == "Blue_block")
        {
            s = Vector3.Distance(this.transform.position, new Vector3(1.55f, -4.62f, -1.63f));
            s = 1 - s;
            if (s < 0 || s > 1)
            {
                GameObject.Find("TextL_S").GetComponent<UnityEngine.UI.Text>().text = "Miss";
            }
            else
            {
                GameObject.Find("TextL_S").GetComponent<UnityEngine.UI.Text>().text = (s * 100).ToString("F0");
            }
        }
        if (this.name == "Red_block")
        {
            s = Vector3.Distance(this.transform.position, new Vector3(-1.65f, -4.62f, -1.63f));
            s = 1 - s;
            if (s < 0 || s > 1)
            {
                GameObject.Find("TextA_S").GetComponent<UnityEngine.UI.Text>().text = "Miss";
            }
            else
            {
                GameObject.Find("TextA_S").GetComponent<UnityEngine.UI.Text>().text = (s * 100).ToString("F0");
            }

        }
        end = true;
        gola = false;

    }
}
