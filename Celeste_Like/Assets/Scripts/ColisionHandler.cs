using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionHandler : MonoBehaviour
{
    private BoxCollider2D bc;
    private float frameSpeed = 0.1f;
    private float adjustCounter = 0f;
    private float frameCounter = 0f;
    private float yDefaultHeight = 0.42f;
    private float increaseAux = -0.6f;
    private float offsetDefault = 2.75f;
    private float offsetAux = 0.3f;
    private float offsetIncrease = 0;
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
            offsetIncrease += offsetAux;
            frameCounter = 0f;
            adjustCounter -= 1;
            bc.size = new Vector2(bc.size.x, bc.size.y + increaseAux);
            bc.offset = new Vector2(0f, offsetDefault + offsetIncrease);
        }
        updateCounterMethods();
    }

    private void FixedUpdate()
    {
    }

    private void increaseBoxCollider2D()
    {
        bc.size = new Vector2(bc.size.x, yDefaultHeight);
        offsetIncrease = 0;
        offsetAux *= -1;
        adjustCounter = 9f;
        increaseAux *= -1f;
    }
    private void decreaseBoxCollider2D()
    {
        offsetAux *= -1;
        adjustCounter = 9f;
        increaseAux *= -1f;
    }

    private void updateCounterMethods()
    {
        frameCounter += Time.deltaTime;
    }
}
