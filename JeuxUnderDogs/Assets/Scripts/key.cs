using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    private GameObject exitPoint;
    private GameObject pointingArrow;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        exitPoint = GameObject.FindGameObjectWithTag("exitPoint");
        pointingArrow = GameObject.FindGameObjectWithTag("arrow");
        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            audio.Play();
            exitPoint.GetComponent<BoxCollider2D>().enabled = true;
            Destroy(this.gameObject.GetComponent<SpriteRenderer>());
            Destroy(this.gameObject.GetComponent<BoxCollider2D>());
            pointingArrow.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
