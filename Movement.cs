using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    
    [SerializeField] float speed = 5f;
    [SerializeField] float gravity = -30f;

    [SerializeField] LayerMask groundMask;
    
    
    [SerializeField] float jumpHeight = 4f;
    bool jump;
    bool isGrounded;

    Vector3 verticalVelocity = Vector3.zero;
    Vector2 horizontalInput;

    private void Update()
    {
        GroundMovement();
    }
    public void RecieveInput(Vector2 horizontal_Input)
    {
        horizontalInput = horizontal_Input;

    }

    void GroundMovement()
    {
        isGrounded = Physics.CheckSphere(transform.position - (new Vector3(0, transform.localScale.y, 0)),0.2f, groundMask);

        if (isGrounded)
        {
            verticalVelocity.y = 0;
        }

        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);

          //jump
        if (jump)
        {
            if (isGrounded)
            {
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            }
            jump = false;
        }

        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);

      
    }

    public void OnJumpPress()
    {
        jump = true;
    }
}
