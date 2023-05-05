using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private Rigidbody2D rb;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //animator.SetTrigger("Fall"); -> call the fallHandler function when the animation is over
            fallHandler();
        }
    }

    private void fallHandler()
    {
        //rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, 1.5f);
    }
}
