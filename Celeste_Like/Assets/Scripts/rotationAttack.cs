using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationAttack : MonoBehaviour
{
    private float rotateSpeed;
    public void rotateToHitPlayer()
    {
        //rotate the Game Object on its axis
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //call the playerDie method
        }
    }
}
