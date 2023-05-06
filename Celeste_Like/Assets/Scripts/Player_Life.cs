using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public Vector2 spawnPoint = new Vector2(-10f, -3f);
    //public position para o restart; 

    private void Start()
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
        if (collision.gameObject.CompareTag("Trap"))
        {
            dieHandler();
        }
    }

    private void dieHandler()
    {
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("Death");
    }

    private void restartLevel()
    {
        animator.ResetTrigger("Death");
        rb.bodyType = RigidbodyType2D.Dynamic;
        transform.position = spawnPoint;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
