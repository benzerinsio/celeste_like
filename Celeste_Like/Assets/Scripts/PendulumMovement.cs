using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumMovement : MonoBehaviour
{
    public float angularSpeed = 100f;
    private Rigidbody2D rb;
    public float angularRotation = 0.25f;
    private bool changeRotation = true;
    [SerializeField] private GameObject player;
    public float defaultAngulation = -23f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.rotation.z) >= angularRotation && changeRotation)
        {
            StartCoroutine(rotationHandler());
        }
    }
    private void FixedUpdate()
    {
        rb.angularVelocity = angularSpeed;
    }

    private IEnumerator rotationHandler()
    {
        changeRotation = false;
        angularSpeed *= -1;
        yield return new WaitForSeconds(2f);
        changeRotation = true;
    }
    
}
