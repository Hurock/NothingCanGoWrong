using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class BaseItems : MonoBehaviour, IInteractable
{
    Canvas canvas;

    [SerializeField] bool isCameraChanging;

    CinemachineVirtualCamera PuzzleCamera;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInChildren<Canvas>();

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
                PuzzleCamera.enabled = true;
            }
            
            Debug.Log("Interacting with a puzzle");
        }
    }

    public void OnInteractEnd()
    {
        PuzzleCamera.enabled = false;
    }
}
