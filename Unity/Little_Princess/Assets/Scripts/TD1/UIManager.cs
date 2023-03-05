using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI lapsCounterText;
    public int currentLap;

    // Start is called before the first frame update
    
    void Start()
    {
        string m = "LAPS 0/3";
        this.UpdateLapText(m);

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateLapText(string message)
    {
        lapsCounterText.text = message; 
    }
}
