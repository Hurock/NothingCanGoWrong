using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnginePuzzleManager : BaseItems
{

    bool isInteractable = false;

    [SerializeField] List<Valve> valves = new();

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnInteractBegin()
    {
        if (isInteractable)
        {
            base.OnInteractBegin();
        }
    }

    public override void OnInteractEnd()
    {
        if (isInteractable)
        {
            base.OnInteractEnd();
        }
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

    public void CheckValves()
    {
        foreach (var valve in valves)
        {
            if(valve.currentPosition == 0)
            {
                int temp = 0;
                temp++;
                if (temp == valves.Count)
                {
                    DisableValves();
                    Debug.Log("Engine fixed!");
                    OnPuzzleSolved.Invoke();
                }
            }
            else
            {
                break;
            }
        }
    }

    private void DisableValves()
    {
       foreach (var valve in valves)
        {
            valve.isInteractable = false;
        }
    }
}
