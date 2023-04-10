using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationNPC : MonoBehaviour
{
    public GameObject npc;
    public Animator animator;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("WaveCharacter", true);
        }
    }
}
