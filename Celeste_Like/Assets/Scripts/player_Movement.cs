using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Movement : MonoBehaviour
{
    //Tools
    [SerializeField] private LayerMask jumpableGround;
    private BoxCollider2D bc;
    private Rigidbody2D rb;
    private float horizontalDirection;
    private float verticalDirection;

    //Horizontal movement
    private float horizontalSpeed = 10f;

    //Vertical movement
    private float jumpBuffer = 0.1f;
    private float coyoteTimer = 0.1f;
    private float jumpBufferCounter = 0f;
    private float coyoteCounter = 0f;
    private bool fallHandled = false;
    private float rbDefaultGravity;
    private float jumpPower = 13f;
    private float maxFallSpeed = -20f; //when the player is in maxFallSpeed change settings to avoid the need of changing the velocity every time
    private float fallSpeedIncrease = -50f;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        rbDefaultGravity = rb.gravityScale;
    }

    void Update()
    {
        horizontalDirection = Input.GetAxisRaw("Horizontal");
        verticalDirection = Input.GetAxisRaw("Vertical");

        jumpBufferCounter -= Time.deltaTime;
        coyoteCounter -= Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBuffer;
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            performJumpCut();
        }
        if (coyoteCounter >= 0f && jumpBufferCounter >= 0f)
        {
            jumpBufferCounter = 0f;//if not setting one of the conditions to 0, it perform the jump a few times (until the counters go to less than 0)
            performJump();
        }
        if(rb.velocity.y >= 0f || isGrounded())
        {
            rb.gravityScale = rbDefaultGravity;
            fallHandled = false;
        }
        if (isGrounded())
        {
            coyoteCounter = coyoteTimer;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalDirection*horizontalSpeed,rb.velocity.y);
        if (rb.velocity.y < 0 && !fallHandled)
        {
            fallHandler();
        }
    }

    private void performJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
    }

    private void performJumpCut()
    {
        rb.velocity = new Vector2(rb.velocity.x,2f);
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

    private bool isGrounded()
    {
        return Physics2D.BoxCast(bc.bounds.center/*the actual position*/, bc.bounds.size/*size of each axis*/, 0f, Vector2.down/*or Vector2(0, -1)*/, .1f, jumpableGround);
    }
}
