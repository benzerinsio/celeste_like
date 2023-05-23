using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapRotate : MonoBehaviour
{
    private float rotationTime; //set the time that takes to the trap to fully rotate
    private float rotationCounter;

    private void Start()
    {
        rotationCounter = 0;
    }

    private void Update()
    {
        rotationCounter -= Time.deltaTime;

        if(rotationCounter < 0f)
        {
            //move platform back to its original state (upwards)
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && rotationCounter < 0f)
        {
            rotationCounter = rotationTime;
            //move downwards
            //call the rotate trap script
        }
    }
}
