using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CablePuzzleManager : BaseItems
{
    [SerializeField] private List<Cable> cables;
    List<Cable> cablesToCheck = new();

    private BoxCollider boxCollider;

    bool isPuzzleSolved = false;

    bool isInteractable = true;

    int cablesCut = 0;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
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
            boxCollider.enabled = false;
        }
        
    }
    public override void OnInteractEnd()
    {
        base.OnInteractEnd();
        boxCollider.enabled = true;
    }

    public void CuttingCable(Cable cableToCut)
    {
        cablesCut++;
        cablesToCheck.Add(cableToCut);
        if (cableToCut.isCorrectCable)
        {
            ResetCables();
            cablesToCheck.Clear();
            cablesCut = 0;
            
        }
        else
        {
            cableToCut.gameObject.SetActive(false);
            if (cablesCut >= 3)
            {
                foreach (Cable cable in cablesToCheck)
                {
                    if (!cable.isCorrectCable)
                    {
                        isPuzzleSolved = true;
                    }
                }
                if (isPuzzleSolved)
                {
                    OnPuzzleSolved.Invoke();
                    isInteractable = false;
                    OnInteractEnd();
                }
            }
        }
    }

    private void ResetCables()
    {
        foreach(var cable in cables)
        {
            cable.gameObject.SetActive(true);
        }
    }
}
