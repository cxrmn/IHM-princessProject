using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControls : MonoBehaviour
{
    

    private float inputX;
    private float inputY;

    // inputX, inputY
    private Vector2 input;
    public UnityEvent<Vector2> onInput;
    
   
    void Update() // Get keyboard inputs
    {
        inputY = Input.GetAxis("Vertical");
        inputX = Input.GetAxis("Horizontal");

       

        input = new Vector2(inputX, inputY).normalized;

        onInput.Invoke(input);
    }

    
}
