using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public int value;

    public GameObject keyEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Hola");
            GameManager.instance.AddKey(value);
            Destroy(gameObject);
            Instantiate(keyEffect, transform.position, transform.rotation);
        }

    }
}
