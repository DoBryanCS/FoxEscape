using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement speed
    public float speed = 5f;

    // Weapon prefab
    public Rigidbody2D rb;
    public Camera cam;

    public Animator animator;

    Vector2 movement;
    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        // Get input axis for horizontal and vertical movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animator.SetFloat("Speed", 1);
            animator.enabled = true;
        } else {
            animator.SetFloat("Speed", 0.01f);
            animator.enabled = false;
        }

        // animator.SetFloat("Horizontal", movement.x);
        // animator.SetFloat("Vertical", movement.y);
        // animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        // Move the player
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}