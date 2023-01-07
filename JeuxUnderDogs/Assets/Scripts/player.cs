using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime);
    }
}
