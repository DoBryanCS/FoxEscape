using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 20;
    // public GameObject hitEffect;
    // public float screenTop;
    // public float screenBottom;

    //  void Update()
    // {
    //     if (transform.position.y > screenTop || transform.position.y < screenBottom)
    //     {
    //         Destroy(this.gameObject);
    //     }
    // }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(this.gameObject);
        // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        // Destroy(effect, 5f);
        Debug.Log(collision.gameObject.name);
    }

    // void OnTriggerEnter2D(Collider2D hitInfo)
    // {
    //     // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
    //     // Destroy(effect, 5f);
    //     Destroy(this.gameObject);
    // }
}
