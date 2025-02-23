using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnginePuzzleManager : BaseItems
{
[SerializeField] private AudioClip steamLeak;
    bool isInteractable = false;

    [SerializeField] List<Valve> valves = new();

    int valvesChecks = 0;

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
                valvesChecks++;
                if (valvesChecks == valves.Count)
                {
                    DisableValves();
                    Debug.Log("Engine fixed!");
                    OnPuzzleSolved.Invoke();
                    SoundFXManager.instance.PlaySoundFXClip(steamLeak, transform, 1f);
                }
            }
            else
            {
                valvesChecks = 0;
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
