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
    private float jumpPower = 20f;
    private float maxFallSpeed = 20f; //when the player is in maxFallSpeed change settings to avoid the need of changing the velocity every time
    private float fallSpeedIncrease = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalDirection = Input.GetAxisRaw("Horizontal");
        verticalDirection = Input.GetAxisRaw("Vertical"); 

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalDirection*horizontalSpeed,rb.velocity.y);
    }
}
