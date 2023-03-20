using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Rigidbody rg;
    public float forwardMoveSpeed;
    public float backwardMoveSpeed;
    public float steerSpeed;

    //private float input.x;
    //private float input.y;

    public Vector2 input;


    /*
    void Update() // Get keyboard inputs
    {
        inputY = Input.GetAxis("Vertical");
        inputX = Input.GetAxis("Horizontal");
    }
    */

    
    public void FixedUpdate() // Apply physics here
    {
        // Accelerate
        float speed = input.y > 0 ? forwardMoveSpeed : backwardMoveSpeed;
        if (input.y == 0) speed = 0;
        rg.AddForce(this.transform.forward * speed, ForceMode.Acceleration);
        // Steer
        float rotation = input.x * steerSpeed * Time.fixedDeltaTime;
        transform.Rotate(0, rotation, 0, Space.World);
    }


    public void SetInputs(Vector2 input)
    {
        this.input = input;
    }
    

    /*
    public void SetInputs(Vector2 input)
    {
        this.input = input;
    }

    // Apply physics here
    void FixedUpdate()
    {
        float speed = input.y > 0 ? forwardMoveSpeed : backwardMoveSpeed;
        rg.AddForce(input.y * this.transform.forward * speed, ForceMode.Acceleration);
        float rotation = input.x * steerSpeed * Time.fixedDeltaTime * input.y;
        transform.Rotate(0, rotation, 0, Space.World);
    }
    */

    public float GetSpeed()
    {
        return Vector3.Dot(rg.velocity, transform.forward.normalized);
    }
    
}
