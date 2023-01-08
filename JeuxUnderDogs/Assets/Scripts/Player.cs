using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    public float maxHealth = 5f;
    public float health;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        HealthDisplay healthDisplay = GetComponent<HealthDisplay>();
        healthDisplay.setEmpty();
        Destroy(gameObject);
    }
}
