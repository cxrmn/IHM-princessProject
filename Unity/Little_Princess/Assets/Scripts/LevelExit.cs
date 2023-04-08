using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Current Keys: " + gameManager.currentKeys);

        if (other.tag == "Player" && gameManager.currentKeys == 3)
        {
            // End Game
            Debug.Log("END LEVEL");

            StartCoroutine(GameManager.instance.LevelEndWaiter());


        } else if (other.tag == "Player" && gameManager.currentKeys < 3)
        {
            Debug.Log("You need more keys");
        }
    }
}
