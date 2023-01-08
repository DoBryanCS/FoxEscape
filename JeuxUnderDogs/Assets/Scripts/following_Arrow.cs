using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class following_Arrow : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            this.gameObject.transform.position = player.transform.position + new Vector3(0, 3f, -5f);
        }
        else
        {
            Destroy(this);
        }
    }
}
