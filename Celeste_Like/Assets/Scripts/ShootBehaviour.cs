using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    private float shootTimer = 1f;
    private float shootCounter;


    private void Start()
    {
        shootCounter = shootTimer;
    }
    // Update is called once per frame
    void Update()
    {
        shootCounter -= Time.deltaTime;

        if (shootCounter <= 0f)
        {
            shootCounter = shootTimer;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab,firePoint.position, firePoint.rotation);
    }
}
