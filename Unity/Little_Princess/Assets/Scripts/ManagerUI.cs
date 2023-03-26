using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManagerUI : MonoBehaviour
{

    public static ManagerUI instance;

    public Image blackscreen;
    public float fadeSpeed;
    public bool fadeToBlack, fadeFromBlack;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeToBlack)
        {
            blackscreen.color = new Color(blackscreen.color.r, blackscreen.color.g, blackscreen.color.b, Mathf.MoveTowards(blackscreen.color.a, 1f, fadeSpeed * Time.deltaTime));

            if (blackscreen.color.a == 1f )
            {
                fadeToBlack = false;
            }
        }

        if (fadeFromBlack)
        {
            blackscreen.color = new Color(blackscreen.color.r, blackscreen.color.g, blackscreen.color.b, Mathf.MoveTowards(blackscreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (blackscreen.color.a == 0f)
            {
                fadeFromBlack = false;
            }
        }
    }
}
