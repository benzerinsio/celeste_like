using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    public Vector2 spawnPoint;
    //public position para o restart; 

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Spawn: " + spawnPoint);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            dieHandler();
        }
    }

    public void dieHandler()
    {
        bc.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("Death");
    }

    private void restartLevel()
    {
        bc.enabled = true;
        transform.position = spawnPoint;
        rb.bodyType = RigidbodyType2D.Dynamic;
        animator.ResetTrigger("Death");
    }

}
