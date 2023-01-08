using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoxe : MonoBehaviour
{
    [SerializeField]
    private GameObject possbibleLoot;
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
        if (collision.gameObject.CompareTag("walls") || collision.gameObject.CompareTag("bullets"))
        {
            Instantiate(possbibleLoot, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
