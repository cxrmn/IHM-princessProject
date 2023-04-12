using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickerPickup : MonoBehaviour
{
    public GameObject chickenEffect;
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
            GameManager.instance.AddChicken(1);
            Destroy(gameObject);
            Instantiate(chickenEffect, transform.position, transform.rotation);
        }
    }
}
