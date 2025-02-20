using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BaseItems : MonoBehaviour, IInteractable
{
    Canvas canvas;

    private bool isCameraChanging;

    private bool puzzleSolved;

    CinemachineVirtualCamera PuzzleCamera;

    private PlayerMovement characterMovement;
    private PlayerInputs playerInputs;

    public UnityEvent OnPuzzleSolved;



    // Start is called before the first frame update
    public virtual void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
        characterMovement = FindObjectOfType<PlayerMovement>();
        playerInputs = FindObjectOfType<PlayerInputs>();
        if (PuzzleCamera = GetComponentInChildren<CinemachineVirtualCamera>())
        {
            isCameraChanging = true;
        }
    }

    public virtual void OnHoverEnd()
    {
        canvas.enabled = false;
    }

    public virtual void OnHoverBegin()
    {
        canvas.enabled = true;
    }

    public virtual void OnInteractBegin()
    {
        if (gameObject.tag == "KeyItem")
        {
            //Debug.Log("Picking key item up");

            PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();
            playerInventory.AddKeyItem(gameObject.name);
            Destroy(gameObject);
        }
        else if (gameObject.tag == "Puzzle")
        {
            playerInputs.setCurrentPuzzle(this);
            if (isCameraChanging)
            {
                characterMovement.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                PuzzleCamera.enabled = true;
                FindObjectOfType<PlayerInputs>().IsPlayerInsidePuzzle = true;
                // Show Puzzle UI - Saira
            }

            //Debug.Log("Interacting with a puzzle");
        }
    }

    public virtual void OnInteractEnd()
    {
        if (isCameraChanging)
        {
            FindObjectOfType<PlayerInputs>().IsPlayerInsidePuzzle = false;
            characterMovement.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            PuzzleCamera.enabled = false;
            // Disable Puzzle UI - Saira
        }
    }

    public virtual void DisableCanvas()
    {
        canvas.enabled = false;
    }
}
