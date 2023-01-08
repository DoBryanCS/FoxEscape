using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Collider2D PlayerBullet;
    public Collider2D BossBullet;

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Renderer>().isVisible)
        { 
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player" || collision.gameObject.tag=="borders" || collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
