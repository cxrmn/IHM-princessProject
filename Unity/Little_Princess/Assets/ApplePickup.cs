using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePickup : MonoBehaviour
{

    public GameObject appleEffect;
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
            GameManager.instance.AddApple(1);
            Destroy(gameObject);
            Instantiate(appleEffect, transform.position, transform.rotation);
        }
    }
}
