using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAppearing : MonoBehaviour
{
    GameManager gameManager;
    
    public void ActivarObjetos()
    {
            if(gameObject != null)
            {
                gameObject.SetActive(true);

                Debug.Log("Go back to take the key");
            }
        
    }

     void Update()
    {
        if(gameManager.currentChicken == 1){
            gameObject.SetActive(true);
        }
    }
}
