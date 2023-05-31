using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    void Shoot()
    {
        Instantiate(bulletPrefab,firePoint.position, firePoint.rotation);
    }
}
