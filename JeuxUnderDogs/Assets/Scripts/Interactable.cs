using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isInteractable = true;
    public float interactionRange = 2.0f; // The maximum distance at which the player can interact with the object
    public KeyCode interactionKey = KeyCode.E; // The key that the player can press to interact with the object

    public GameObject player; // The player game object

    public GameObject mesh; // The meshtextField;

    private void Update()
    {
        if (!player)
        {
            Destroy(this);
        } else
        {
            // Check if the player is close enough to the object and if they are pressing the interaction key
            if (isInteractable && Vector3.Distance(transform.position, player.transform.position) <= interactionRange)
            {
                Debug.Log("In range");
                mesh.SetActive(true);
                if(Input.GetKeyDown(interactionKey)) {
                    Interact();
                }
            } else {
                mesh.SetActive(false);
            }
        }

    }

    public virtual void Interact()
    {
        // This method can be overridden in derived classes
        Debug.Log("Interacted with " + gameObject.name);
        gameObject.SetActive(false);
    }
}
