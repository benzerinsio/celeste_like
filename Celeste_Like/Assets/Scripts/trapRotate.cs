using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapRotate : MonoBehaviour
{
    private float rotationTime;
    private float rotateSpeed = 50f;
    private float rotationCounter;
    [SerializeField] rotationAttack variable;
    public Vector2 defaultPosition;

    private void Start()
    {
        rotationTime = 180 / rotateSpeed;
        rotationCounter = 0;
        defaultPosition = transform.position;
    }

    private void Update()
    {
        rotationCounter -= Time.deltaTime;

        if(rotationCounter < 0f)
        {
            variable.rotateSpeed = 0f;
            variable.resetRotation();
            transform.position = defaultPosition;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && rotationCounter < 0f)
        {
            rotationCounter = rotationTime;
            variable.rotateSpeed = rotateSpeed;
            transform.position = new Vector2(defaultPosition.x, defaultPosition.y - 0.2f);
        }
    }
}
