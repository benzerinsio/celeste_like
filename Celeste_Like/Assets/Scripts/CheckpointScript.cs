using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Player_Life spawn;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Start");
        }
    }

    private void setSpawn()
    {
        spawn.spawnPoint = transform.position;
    }
}
