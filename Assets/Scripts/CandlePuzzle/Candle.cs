using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Candle : BaseItems
{
    [SerializeField] private AudioClip fireLight;
    static int candleID = 1;

    private int passwordValue;

    public bool isInteractable = false;

    public bool isSelected = false;

    private CandlePuzzleManager candlePuzzleManager;

    public UnityEvent OnInteractSendPass;

    [SerializeField] private GameObject psGameobject;

    public override void Start()
    {
        base.Start();
        passwordValue = candleID++;
        candlePuzzleManager = FindObjectOfType<CandlePuzzleManager>();
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
        if (!isSelected && isInteractable)
        {
            base.OnInteractBegin();
            TurnOnCandle();
            OnInteractSendPass.Invoke();
        }
    }
    public override void OnInteractEnd()
    {
        if (isInteractable)
        {
            base.OnInteractEnd();
        }
    }

    public void TurnOnCandle()
    {
        isSelected = true;
        psGameobject.SetActive(true);
        SoundFXManager.instance.PlaySoundFXClip(fireLight, transform, 1f);
    }

    public void TurnOff()
    {
        Debug.Log("Turning off candles");
        psGameobject.SetActive(false);
        isSelected = false;
    }
}
