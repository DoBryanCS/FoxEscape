using UnityEngine;

public class BulletDisapear : MonoBehaviour
{

    void Update()
    {
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "borders" || collision.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
        }


    }
}
