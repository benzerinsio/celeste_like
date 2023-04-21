using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Movement : MonoBehaviour
{
    //Tools
    private Rigidbody2D rb;
    private float horizontalDirection;
    private float verticalDirection;

    //Horizontal movement
    private float horizontalSpeed = 10f;

    //Vertical movement
    private bool fallHandled = false;
    private bool canJump = false;
    private float rbDefaultGravity;
    private float jumpPower = 15f;
    private float maxFallSpeed = -20f; //when the player is in maxFallSpeed change settings to avoid the need of changing the velocity every time
    private float fallSpeedIncrease = -15f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbDefaultGravity = rb.gravityScale;
        
    }

    void Update()
    {
        horizontalDirection = Input.GetAxisRaw("Horizontal");
        verticalDirection = Input.GetAxisRaw("Vertical");

        // Debug.Log("Fall Handled: "+fallHandled);
        Debug.Log("velocidade: " + rb.velocity.y);  

        if (Input.GetButtonDown("Jump"))
        {
            performJump();
        }
        if(rb.velocity.y >= 0f)//When the player is grounded or is in some sort of upwards momentum, the fallSpeed is defaulted
        {
            rb.gravityScale = rbDefaultGravity;
            fallHandled = false;
        }
        if(rb.velocity.y < 0 && !fallHandled)
        {
            
            fallHandler();
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalDirection*horizontalSpeed,rb.velocity.y);
    }

    private void performJump()//Do some checks in here to assure that it can jump
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
    }

    private void fallHandler()
    {
        if(rb.velocity.y <= maxFallSpeed)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, maxFallSpeed);
            fallHandled = true;
        }
        else
        {
            rb.AddForce(new Vector2(0f, fallSpeedIncrease), ForceMode2D.Force);
        }
    }
}
