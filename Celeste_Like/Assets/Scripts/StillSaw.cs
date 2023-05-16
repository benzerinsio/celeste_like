using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillSaw : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Player_Life die;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            die.dieHandler();
        }
    }
}
