using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : BaseItems
{
    static int tentacleID = 0;

    public bool isInteractable = false;

    private KrakenPuzzleManager krakenPuzzleManager;

    private Animator anim;

    public override void Start()
    {
        base.Start();
        tentacleID++;

        Debug.Log(tentacleID);

        anim = GetComponent<Animator>();
        krakenPuzzleManager = FindObjectOfType<KrakenPuzzleManager>();
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
            CurlTentacle();
            krakenPuzzleManager.AddToPassword(tentacleID.ToString());
        }
    }
    public override void OnInteractEnd()
    {
        if (isInteractable)
        {
            base.OnInteractEnd();
        }
    }

    public void CurlTentacle()
    {
        anim.SetBool("IsSelected", true);
    }

    public void UncurlTentacle()
    {
        anim.SetBool("IsSelected", false);
    }
    
    
}
