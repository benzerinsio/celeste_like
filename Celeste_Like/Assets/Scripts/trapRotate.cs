using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapRotate : MonoBehaviour
{
    private float rotationTime;
    private float rotateSpeed = 50f;
    private float rotationCounter;
    [SerializeField] rotationAttack variable;

    private void Start()
    {
        rotationTime = 180 / rotateSpeed;
        rotationCounter = 0;
    }

    private void Update()
    {
        rotationCounter -= Time.deltaTime;

        if(rotationCounter < 0f)
        {
            variable.rotateSpeed = 0f;
            variable.resetRotation();
            //move platform back to its original state (upwards)
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && rotationCounter < 0f)
        {
            rotationCounter = rotationTime;
            variable.rotateSpeed = rotateSpeed;
            //move downwards
        }
    }
}
