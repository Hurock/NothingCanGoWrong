using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItems : MonoBehaviour, IInteractable
{
    Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInChildren<Canvas>();

    }

    public void InteractEnd()
    {
        canvas.enabled = false;
    }

    public void InteractBegin()
    {
        canvas.enabled = true;
    }

    public void OnInteract()
    {
        if (gameObject.tag == "KeyItem")
        {
            Debug.Log("Picking key item up");

            PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();
            playerInventory.AddKeyItem(gameObject.name);
            Destroy(gameObject);
        }
        else if (gameObject.tag == "Puzzle")
        {
            Debug.Log("Interacting with a puzzle");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        canvas.enabled = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        canvas.enabled = false;
    }
}
