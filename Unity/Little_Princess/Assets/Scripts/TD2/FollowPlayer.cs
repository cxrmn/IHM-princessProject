using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 marginFromPlayer;
    public Vector3 rotationFromPlayer;
    public bool flipCamera = true;

    private Quaternion initialRotation; // 0 0 0

    void Start()
    {
        initialRotation = transform.rotation; 
        transform.rotation = initialRotation * Quaternion.Euler(80f, 180f, 0f);

    }

    void Update() 
    {
        //transform.position = player.transform.position + marginFromPlayer;
        //transform.rotation = player.rotation * Quaternion.Euler(0f, 25f, 0f);
        transform.position = player.transform.position + marginFromPlayer;
        
    }
}
