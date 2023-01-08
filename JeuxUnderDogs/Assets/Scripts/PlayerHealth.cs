using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    //Function called in EnemyDamage script
    public void TakeDamage(int amount) 
    {
        health -= amount;
        if (health <= 0)
        {
            //What happens if player dies
            Destroy(gameObject);
        }
    }
}
