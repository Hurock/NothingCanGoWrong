using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class BaseItems : MonoBehaviour, IInteractable
{
    Canvas canvas;

    [SerializeField] bool isCameraChanging;

    CinemachineVirtualCamera PuzzleCamera;

    private PlayerMovement characterMovement;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
        characterMovement = FindObjectOfType<PlayerMovement>();
        if (PuzzleCamera = GetComponentInChildren<CinemachineVirtualCamera>())
        {
            isCameraChanging = true;
        }
    }

    public void OnHoverEnd()
    {
        canvas.enabled = false;
    }

    public void OnHoverBegin()
    {
        canvas.enabled = true;
    }

    public void OnInteractBegin()
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
            if (isCameraChanging) 
            {
                characterMovement.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                PuzzleCamera.enabled = true;
                // Show Puzzle UI - Saira
            }
            
            Debug.Log("Interacting with a puzzle");
        }
    }

    public void OnInteractEnd()
    {
        if (isCameraChanging)
        {
            characterMovement.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            PuzzleCamera.enabled = false;
            // Disable Puzzle UI - Saira
        }
    }
}
