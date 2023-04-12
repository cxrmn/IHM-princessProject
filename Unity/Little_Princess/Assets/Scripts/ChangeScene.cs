using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
   GameManager gameManager;

    void Start()
    {
      // gameManager = FindObjectsOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.EnableCursor();
            SceneManager.LoadScene(3);

        }
    }
}