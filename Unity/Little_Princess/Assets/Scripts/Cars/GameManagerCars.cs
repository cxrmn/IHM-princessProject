using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerCars : MonoBehaviour
{
    public PlayerControls playerControls;
    public AIControls[] aiControls;
    public LapManager lapTracker;
    public TricolorLights tricolorLights;

    public AudioSource audioSource;
    public AudioClip lowBeep;
    public AudioClip highBeep;

    public Animator cameraIntroAnimator;
    public FollowPlayer followPlayerCamera; // script_ FollowPlayer
    
   

    void Awake()
    {
        //StartGame();
        StartIntro();
    }

    public void StartIntro()
    {
        
        followPlayerCamera.enabled = false;
        

        cameraIntroAnimator.enabled = true;
        FreezePlayers(true);
    }

    
    public void StartGame()
    {
        FreezePlayers(true);
        StartCoroutine("Countdown");
    }
    

    public void StartCountdown()
    {
        followPlayerCamera.enabled = true;
        cameraIntroAnimator.enabled = false;
        

        StartCoroutine("Countdown"); // go to Ienumerator countdown
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("3");
        tricolorLights.SetProgress(1);
        audioSource.PlayOneShot(lowBeep);

        yield return new WaitForSeconds(1);
        Debug.Log("2");
        tricolorLights.SetProgress(2);
        audioSource.PlayOneShot(lowBeep);

        yield return new WaitForSeconds(1);
        Debug.Log("1");
        tricolorLights.SetProgress(3);


        yield return new WaitForSeconds(1);
        Debug.Log("GO");
        tricolorLights.SetProgress(4);
        audioSource.PlayOneShot(highBeep);
        StartRacing();
        yield return new WaitForSeconds(2f);
        tricolorLights.SetAllLightsOff();
    }


    public void StartRacing()
    {
        FreezePlayers(false);
    }


    void FreezePlayers(bool freeze)
    {
        //TODO : freeze players here

        // Get all PlayerControls and AIControls components in the scene
        PlayerControls[] playerControls = FindObjectsOfType<PlayerControls>();
        AIControls[] aiControls = FindObjectsOfType<AIControls>();

        // Loop through all PlayerControls and AIControls components
        foreach (PlayerControls playerControl in playerControls)
        {
            // Disable the input control component if freeze is true
            playerControl.enabled = !freeze;
        }
        foreach (AIControls aiControl in aiControls)
        {
            // Disable the input control component if freeze is true
            aiControl.enabled = !freeze;
        }
    }
}
