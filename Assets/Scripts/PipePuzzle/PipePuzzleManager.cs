using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePuzzleManager : BaseItems
{
    private BoxCollider bc;

    private GameObject currentPipe;
    private float currentPipeRotation;
    private float correctPipeRotation = 0;
    private int correctPipes = 0;
    private int finishedPipes = 19;

    bool isEnabled;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        bc = GetComponent<BoxCollider>();
    }

    public void PipeClicked(string puzzlePiece)
    {
        currentPipe = GameObject.Find(puzzlePiece);
        currentPipe.transform.rotation = Quaternion.Euler(currentPipe.transform.eulerAngles.x + 90, currentPipe.transform.eulerAngles.y, currentPipe.transform.eulerAngles.z);
        currentPipeRotation = currentPipe.transform.rotation.x;
    }

    public void CorrectPipeRotation(int rotation)
    {
        correctPipeRotation = rotation;
    }

    private void CheckPipe()
    {
        if(currentPipeRotation == correctPipeRotation)
        {
            Debug.Log("correct position");
            correctPipes++;
        }

        if (correctPipes == finishedPipes)
        {
            Debug.Log("Pipes correct");
            OnInteractEnd();
            OnPuzzleSolved.Invoke();
        }
        else
        {
            Debug.Log("Pipes incorrect");
        }
    }

    public override void OnHoverBegin()
    {
        if (isEnabled)
        {
            base.OnHoverBegin();
        }
    }
    public override void OnHoverEnd()
    {
        if (isEnabled)
        {
            base.OnHoverEnd();
        }
    }

    public override void OnInteractBegin()
    {
        if (isEnabled)
        {
            base.OnInteractBegin();
            bc.enabled = false;
        }
    }

    public override void OnInteractEnd()
    {
        base.OnInteractEnd();
        bc.enabled = true;
    }
}
