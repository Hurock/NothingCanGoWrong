using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : BaseItems
{
[SerializeField] private AudioClip ocotopusSound;
    static int tentacleID = 0;

    private int passwordValue;

    public bool isInteractable = false;

    public bool isSelected = false;

    private KrakenPuzzleManager krakenPuzzleManager;

    private Animator anim;

    public override void Start()
    {
        base.Start();
        passwordValue = tentacleID++;

        //Debug.Log(tentacleID);

        anim = GetComponent<Animator>();
        krakenPuzzleManager = FindObjectOfType<KrakenPuzzleManager>();
    }

    public override void OnHoverBegin()
    {
        if (isInteractable)
        {
            base.OnHoverBegin();
            Debug.Log("Hovering");
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
        if (!isSelected && isInteractable)
        {
            base.OnInteractBegin();
            CurlTentacle();
            krakenPuzzleManager.AddToPassword(passwordValue.ToString());
            SoundFXManager.instance.PlaySoundFXClip(ocotopusSound, transform, 1f);
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
        isSelected = true;
        anim.SetBool("IsSelected", true);
        
    }

    public void UncurlTentacle()
    {
        
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            isSelected = false;
        }
        anim.SetBool("IsSelected", false);
    }
    
    
}
