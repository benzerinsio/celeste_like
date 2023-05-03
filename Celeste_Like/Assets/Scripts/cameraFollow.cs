using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody2D playerRb;
    private float correctYpos = 1.75f;
    public float followSpeed = 10f;

    void Update()
    {
        Vector3 newPos = new Vector3(player.position.x + playerRb.velocity.x, player.position.y + correctYpos + playerRb.velocity.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
        //transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}


