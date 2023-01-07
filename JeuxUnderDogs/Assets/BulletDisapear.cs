using UnityEngine;

public class BulletDisapear : MonoBehaviour
{

    void onCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
