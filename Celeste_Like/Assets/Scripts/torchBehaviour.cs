using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //start the ilumination
            animator.SetTrigger("Start");
        }
    }
}
