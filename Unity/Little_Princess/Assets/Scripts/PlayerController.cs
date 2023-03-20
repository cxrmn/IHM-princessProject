using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    private Vector3 moveDirection; // X Y Z

    private float inputX;
    private float inputY;

    public CharacterController charController;

    public float gravityScale = 5f;

    public Camera playerCamera; //1º camera

    public float rotateSpeed = 5f;

    public GameObject playerModel;

    public Animator animator;



    void Start()
    {

    }

    void Update()
    {

        float yStore = moveDirection.y;

        // movement private variables
        inputX = Input.GetAxisRaw("Horizontal"); // eje horizontal
        inputY = Input.GetAxisRaw("Vertical"); // eje vertical

        moveDirection = (transform.forward * inputY) + (transform.right * inputX);
        moveDirection.Normalize();


        moveDirection = moveDirection * moveSpeed;
        moveDirection.y = yStore; // guardando valor salto


        // salto
        Debug.Log("hola: " + charController.isGrounded);
        
        if (charController.isGrounded )
        {
            
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("Jump !!!!");
                moveDirection.y = jumpForce;
            }

        }

       

        // gravity
        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

        charController.Move(moveDirection * Time.deltaTime);


        // rotation 
        if (inputX != 0 || inputY != 0)
        {
            // 43:59
            transform.rotation = Quaternion.Euler(0f, playerCamera.transform.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));

            // rotacion + suave
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);

        }

        // animator
        animator.SetFloat("Speed", Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z));
        animator.SetBool("isGrounded", charController.isGrounded);
        

    }
}
