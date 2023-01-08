using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Screen bounds
    public float screenRight;
    public float screenTop;
    public float screenLeft;
    public float screenBottom;

    // Update is called once per frame
    void Update()
    {
        // Check if the object is out of bounds
        if (transform.position.x > screenRight || transform.position.x < screenLeft ||
            transform.position.y > screenTop || transform.position.y < screenBottom)
        {
            // Destroy the object
            Destroy(gameObject);
        }
    }
}