using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 5f);
    }
}
