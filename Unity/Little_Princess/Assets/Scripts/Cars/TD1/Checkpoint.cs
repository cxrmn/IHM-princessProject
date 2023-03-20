using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // needed to use UnityEvent


public class Checkpoint : MonoBehaviour
{
    public UnityEvent<CarIdentity, Checkpoint> onCheckpointEnter;
    

    void OnTriggerEnter(Collider collider)
    {

        CarIdentity carIdentity = collider.GetComponent<CarIdentity>();
        // if entering object is tagged as the Player
        if (carIdentity != null)
        {
            //Debug.Log("hola");
            // fire an event giving the entering gameObject and this checkpoint
            //onCheckpointEnter.Invoke(collider.gameObject, this);
            onCheckpointEnter.Invoke(carIdentity, this);
        }
    }
}
