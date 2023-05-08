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
            fall = true;
            StartCoroutine(fallHandler());
        }
    }

    private IEnumerator fallHandler()
    {
        yield return new WaitForSeconds(2f);
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(2f);
        sprite.enabled = false;
        bc.enabled = false;
        yield return new WaitForSeconds(2f);
        bc.enabled = true;
        sprite.enabled = true;
        rb.bodyType = RigidbodyType2D.Static;
        transform.position = defaultPosition;
        yield return new WaitForSeconds(1f);
        fall = false;
    }
}
