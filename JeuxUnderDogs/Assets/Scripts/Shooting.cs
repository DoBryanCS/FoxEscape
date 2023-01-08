using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private int numberOfAmmo = 100;

    public float bulletForce;

    // Update is called once per frame
    void Update()
    {
        if (numberOfAmmo > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                numberOfAmmo--;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.transform.localScale = new Vector3(2, 2, 0);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ammoBox"))
        {
            numberOfAmmo += 30;
            Destroy(collision.gameObject);
        }
    }
}
