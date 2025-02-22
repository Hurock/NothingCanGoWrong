using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MazePuzzleManager : BaseItems
{

    private bool isInteractable = true;

    private bool isSelected = false;
    
    private MovingCube cube;

    public override void Start()
    {
        base.Start();
        cube = FindObjectOfType<MovingCube>();
    }

    private void Update()
    {
        
    }

    public override void OnHoverBegin()
    {
        if (isInteractable)
        {
            base.OnHoverBegin();
        }
    }
    public override void OnHoverEnd()
    {
        if (isInteractable)
        {
            base.OnHoverEnd();
        }
    }
    public override void OnInteractBegin()
    {
        if (isInteractable)
        {
            base.OnInteractBegin();
            cube.isActive = true;
            Camera.main.orthographic = true;
        }
    }
    public override void OnInteractEnd()
    {
        if (isInteractable)
        {
            base.OnInteractEnd();
            OnPuzzleSolved.Invoke();
            cube.isActive = false;
            Camera.main.orthographic = false;
        }
    }
}
