using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SpikeHeadScript spikeScript;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        spikeScript.spikeHeadDrop();
    }
}
