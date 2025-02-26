using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public bool IsPlayerInsidePuzzle { get; set; }

    IInteractable currentPuzzle;

    public void setCurrentPuzzle(IInteractable puzzle)
    {
        currentPuzzle = puzzle as IInteractable;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerInsidePuzzle && Input.GetKey(KeyCode.Escape))
        {
            if (currentPuzzle != null)
            {
                currentPuzzle.OnInteractEnd();
            }
            else
            {
                Debug.Log("No puzzle found");
            }
        }
    }
}
