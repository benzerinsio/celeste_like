using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] Player_Life die;
    private int currentPoint = 0;
    private float planSpeed = 6f;
    private void FixedUpdate()
    {
        if (Vector2.Distance(waypoints[currentPoint].transform.position, transform.position) < .1f)
        {
            currentPoint++;
            if (currentPoint >= waypoints.Length)
            {
                currentPoint = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentPoint].transform.position, Time.deltaTime * planSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            die.dieHandler();
        }
    }
}
