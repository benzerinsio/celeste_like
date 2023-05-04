using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderHandler : MonoBehaviour
{
    private BoxCollider2D bc;
    private float frameSpeed = 0.12f;
    private float adjustCounter = 0f;
    private float frameCounter = 0f;
    private float yDefaultHeight = 0.42f;
    private float increaseAux = -1f;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()//need to adjust the collider to not hit the block above
    {
        if (frameCounter >= frameSpeed && adjustCounter > 0f)
        {
            frameCounter = 0f;
            adjustCounter -= 1;
            bc.size = new Vector2(bc.size.x, bc.size.y + increaseAux);
            //bc.offset = new Vector2(0f, bc.size.y + increaseAux);
        }
        updateCounterMethods();
    }

    private void FixedUpdate()
    {
    }

    private void increaseBoxCollider2D()
    {
        bc.size = new Vector2(bc.size.x, yDefaultHeight);
        adjustCounter = 5f;
        increaseAux *= -1;
    }
    private void decreaseBoxCollider2D()
    {
        adjustCounter = 4f;
        increaseAux *= -1f;
    }

    private void updateCounterMethods()
    {
        frameCounter += Time.deltaTime;
    }
}
