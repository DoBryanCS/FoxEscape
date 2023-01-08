using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float movementSpeed = 5f;
    public float maxDistance = 5f;
    public Animator anim;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector3 wantedPosition = new Vector3(0, 0, 0);
    private bool playerIsInRange = false;


    // Start is called before the first frame update
    void Start()
    {   
        rb = this.GetComponent<Rigidbody2D>();
        wantedPosition = chooseRandomPoint();
    }

    // Update is called once per frame
    void Update()
    {
        playerIsInRange = playerInRange();

        if (playerIsInRange)
        {
            // Rotation de l'ennemi
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle - 90;
            direction.Normalize();
            movement = direction;

            // Movement de l'ennemi 
            if (Vector3.Distance(player.position, transform.position) > 5)
            {
                anim.SetBool("isWalking", false);
                moveCharacter(movement);
            } else
            {
                anim.SetBool("isWalking", true);
            }

        } else
        {
            // Si le l'ennemi atteint le point, il choisi une nouvelle position
            if (Vector3.Distance(this.transform.position, wantedPosition) < 0.1f)
            {
                wantedPosition = chooseRandomPoint();
            }

            // Rotation de l'ennemi
            Vector3 direction = wantedPosition - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle - 90;
            transform.position = Vector3.MoveTowards(this.transform.position, wantedPosition, 1f * Time.deltaTime);
            movement = new Vector3(0, 0, 0);
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * movementSpeed * Time.deltaTime));
    }

    public Vector3 chooseRandomPoint()
    {
        Vector3 nextPoint = new Vector3(Random.Range(-1 * maxDistance, maxDistance), Random.Range(-1 * maxDistance, maxDistance));
        return nextPoint;
    }

    bool playerInRange()
    {
        if (!player) return false;

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance < 10)
        {
            return true;
        }

        return false;
    }
}
