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
    private bool canJump = false;
    private float jumpPower = 10f;
    private float maxFallSpeed = 20f; //when the player is in maxFallSpeed change settings to avoid the need of changing the velocity every time
    private float fallSpeedIncrease = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        horizontalDirection = Input.GetAxisRaw("Horizontal");
        verticalDirection = Input.GetAxisRaw("Vertical");
        
        if (Input.GetButtonDown("Jump"))
        {
            performJump();
        }
        if(rb.velocity.y < 0)
        {
            
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

    private void fallHander()
    {
        //handle all the stuff related to fall, like maxFallSpeed, Falling increase, and so on
    }
}
