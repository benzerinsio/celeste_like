using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private UnityEngine.Rendering.Universal.Light2D light;

    private void Start()
    {
        light = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        light.enabled = false;
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

    private void activateLight()
    {
        light.enabled = true;
    }
}
