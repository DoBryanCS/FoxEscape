using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour
{
    [SerializeField] PlayerController player;

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }    

    }
}
