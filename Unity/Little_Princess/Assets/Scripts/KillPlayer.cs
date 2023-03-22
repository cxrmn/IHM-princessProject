using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") //El jugador toca el killzone
        {
            GameManager.instance.Respawn();
        }
    }
}
