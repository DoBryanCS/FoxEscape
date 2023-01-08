using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{
    [SerializeField]
    private GameObject[] possbibleLoot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("walls") || collision.gameObject.CompareTag("specialBox"))
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("bullets"))
        {
            if (Random.value <= 0.3)
            {
                Instantiate(possbibleLoot[Random.Range(0, possbibleLoot.Length)], this.gameObject.transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
    }
}
