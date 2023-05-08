using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private SpriteRenderer sprite;
    private Vector2 defaultPosition;
    private bool fall = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        defaultPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !fall)
        {
            StartCoroutine(fallHandler());
        }
    }

    private IEnumerator fallHandler()
    {
        fall = true;
        yield return new WaitForSeconds(2f);
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(2f);
        sprite.enabled = false;
        bc.enabled = false;
        yield return new WaitForSeconds(3f);
        transform.position = defaultPosition;
        rb.bodyType = RigidbodyType2D.Kinematic;
        sprite.enabled = true;
        bc.enabled = true;
        fall = false;
    }
}
