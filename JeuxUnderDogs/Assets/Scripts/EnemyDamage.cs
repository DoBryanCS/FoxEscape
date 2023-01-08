using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    //Linking PlayerHealth script
    [SerializeField]
    private PlayerHealth playerHealth;
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //TakeDamage() function created in PlayerHealth script
            playerHealth.TakeDamage(damage);
        }
    }
}
