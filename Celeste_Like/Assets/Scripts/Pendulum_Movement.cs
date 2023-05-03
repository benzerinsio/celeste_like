using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum_Movement : MonoBehaviour
{
    private float angularSpeed = 10f;
    private Rigidbody2D rb;
    private float angularRotation = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.rotation.z) >= angularRotation) //perhaps will not work because it will turn the direction back and forth too fast
        {
            angularSpeed *= -1;
        }
    }

    private void FixedUpdate()
    {
        rb.angularVelocity = angularSpeed;
    }
}
