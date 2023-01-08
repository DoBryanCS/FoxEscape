using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isInteractable = true;
    public float interactionRange = 0.3f; // The maximum distance at which the player can interact with the object
    public KeyCode interactionKey = KeyCode.E; // The key that the player can press to interact with the object
    private AudioSource audio = null;
    private bool destroyable = false;
    [SerializeField]
    private GameObject player; // The player game object

   // public GameObject mesh; // The meshtextField;
    private void Awake()
    {
        if (gameObject.GetComponent<AudioSource>())
        {
            audio = gameObject.GetComponent<AudioSource>();
        }
        player = GameObject.FindGameObjectWithTag("player");
    }
    private void Update()
    {
        if (player)
        {
        //    mesh.SetActive(true);
            if(Input.GetKeyDown(interactionKey) && Vector3.Distance(player.transform.position,this.transform.position)<=interactionRange) {
                Interact();
            }
        } else {
         //   mesh.SetActive(false);
        }
        if (audio != null)
        {
            if (audio.isPlaying == true)
            {
                destroyable = true;
            }
            if (audio.isPlaying == false && destroyable == true)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public virtual void Interact()
    {
        // This method can be overridden in derived classes
        Debug.Log("Interacted with " + gameObject.name);
        if (audio != null)
        {
            audio.Play();
        }
        Destroy(this.gameObject.GetComponent<SpriteRenderer>());
        Destroy(this.gameObject.GetComponent<BoxCollider2D>());
        
    }
}
