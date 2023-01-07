using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform player;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    private float timer = 0f;
    public float timeBetweenShots = 2f;
    public float fireDistance = 8f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenShots)
        {
            float distance = Vector3.Distance(player.position, transform.position);
 

            if (distance <= fireDistance)
            {
                timer = 0f;
                Shoot();
            }
        }
    }

    void Shoot()
    {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
