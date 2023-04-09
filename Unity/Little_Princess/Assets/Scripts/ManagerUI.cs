using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerUI : MonoBehaviour
{

    public static ManagerUI instance;

    public Image blackscreen;
    public float fadeSpeed;
    public bool fadeToBlack, fadeFromBlack;

    public TextMeshProUGUI Keytext;

    // for input console
    public TMP_Text consoleText;

    public TextMeshProUGUI Chickentext;

    public TextMeshProUGUI Appletext;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        // console struff
        consoleText = GameObject.Find("TextConsole").GetComponent<TMP_Text>();
        Application.logMessageReceived += LogMessageReceived;
    }

    // Update is called once per frame
    void Update()
    {


        // fadeblack stuff
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

    // override
    void LogMessageReceived(string message, string stackTrace, LogType type)
    {
        string consoleString = "";

        switch (type)
        {
            case LogType.Error:
            case LogType.Assert:
            case LogType.Exception:
                consoleString += "<color=red>" + message + "</color>";
                break;
            case LogType.Warning:
                consoleString += "<color=yellow>" + message + "</color>";
                break;
            default:
                consoleString += message;
                break;
        }

        consoleText.text = consoleString + "\n";
    }



}
