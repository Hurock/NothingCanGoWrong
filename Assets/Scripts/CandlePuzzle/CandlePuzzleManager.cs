using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CandlePuzzleManager : BaseItems
{
    [SerializeField] string puzzlePassword = "123";


    private bool isResetting;
    float timer = .0f;

    [SerializeField] private string currentPassword = "";

    private bool isInteractable = false;

    public UnityEvent TurnOffCandles;

    public override void Start()
    {
        base.Start();
        //playerInventory = FindObjectOfType<PlayerInventory>();
    }

    private void Update()
    {
        if (isResetting)
        {
            timer += Time.deltaTime;

            if (timer >= 1)
            {
                isResetting = false;
                timer = 0;
                TurnOffCandles?.Invoke();
            }
        }

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

    private void ComparePassword()
    {
        if (currentPassword == puzzlePassword)
        {
            //Debug.Log("Kraken puzzle password matches: " + currentPassword);
            OnPuzzleSolved.Invoke();
        }
        else
        {
            //Debug.Log("Kraken password doesn't match: " + currentPassword);
            currentPassword = "";
            isResetting = true;
        }
    }

    public void AddToPassword(string characterToAdd)
    {
        currentPassword += characterToAdd;
        if (currentPassword.Length == 3)
        {
            ComparePassword();
        }
    }

    public void TurnOff()
    {
        TurnOffCandles.Invoke();
    }
}
