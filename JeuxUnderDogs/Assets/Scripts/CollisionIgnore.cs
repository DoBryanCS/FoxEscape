using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionIgnore : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;

    void Start()
    {
        // Get the colliders for the two objects
        Collider2D collider1 = object1.GetComponent<Collider2D>();
        Collider2D collider2 = object2.GetComponent<Collider2D>();

        // Create a Layer Mask for the layer that the objects are on
        int layerMask = 1 << LayerMask.NameToLayer("bullet");


        // Ignore collisions between the two objects
        Physics2D.IgnoreCollision(collider1, collider2, true);
    }
}
