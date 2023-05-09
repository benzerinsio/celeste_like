using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHeadScript : MonoBehaviour
{
    [SerializeField] private LayerMask collisionGround;
    [SerializeField] private GameObject defaultPosition;
    private Animator animator;
    private float blinkTimer = 2f;
    private float blinkCounter = 0f;
    private bool falling = false;
    private bool canFall = true;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private float gravityScaleIncrement = 3f;
    private float defaultGravity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        defaultGravity = rb.gravityScale;
        blinkCounter = blinkTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (blinkCounter <= 0f)
        {
            blinkCounter = blinkTimer;
            animator.SetTrigger("blink");
        }
        if (Vector2.Distance(defaultPosition.transform.position, transform.position) < 0.1f && !falling)
        {
            canFall = true;
            rb.gravityScale = defaultGravity;
            rb.bodyType = RigidbodyType2D.Static;
        }
        timersHandler();
    }

    public void spikeHeadDrop()
    {
        if (canFall)
        {
            canFall = false;
            falling = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale += gravityScaleIncrement;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collided();
    }

    private void timersHandler()
    {
        blinkCounter -= Time.deltaTime;
    }

    private void resetCollision()
    {
        animator.ResetTrigger("collision");
    }
    private void resetBlink()
    {
        animator.ResetTrigger("blink");
    }

    private void collided()
    {
        if(Physics2D.BoxCast(bc.bounds.center/*the actual position*/, bc.bounds.size/*size of each axis*/, 0f, Vector2.down/*or Vector2(0, -1)*/, .1f, collisionGround)){
            rb.velocity = new Vector2(0f,0f);
            rb.gravityScale = -defaultGravity / 3;
            animator.SetTrigger("collision");
            falling = false;
        }
    }
}
