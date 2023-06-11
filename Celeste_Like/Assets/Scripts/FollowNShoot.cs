using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowNShoot : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    public float defaultRotation;
    private bool playerClose = false;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < 10f)
        {
            playerClose = true;
        } else
        {
            rb.rotation = defaultRotation;
            playerClose = false;
        }

        if (playerClose)
        {
            Follow();
        }
    }


    private void Follow()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
