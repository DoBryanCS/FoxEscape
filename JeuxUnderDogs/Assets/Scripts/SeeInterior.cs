using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeInterior : MonoBehaviour
{
    private SpriteRenderer sprite;
    void Start()
    {
        sprite = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            sprite.enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            sprite.enabled = true;
        }
    }
}
