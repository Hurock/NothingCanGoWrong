using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MemoryPuzzleManager : BaseItems
{
    private BoxCollider bc;
    private bool isEnabled = true;

    private Button button;
    private int pipe = 0, wrench = 0, wheel = 0, wire = 0;
    private int allCardsMatched = 0;
    private int currentCards = 0;
    private string cardPicked = "";

    public override void Start()
    {
        bc = GetComponent<BoxCollider>();
    }

    public void ButtonClicked(string card)
    {
        cardPicked += card;
        currentCards++;
        Debug.Log(cardPicked + "was picked");

        if (card == "Pipe")
        {
            pipe++;
            Debug.Log("Pipes = " + pipe);
        }
        if (card == "Wrench")
        {
            wrench++;
            Debug.Log("Wrenches = " + wrench);
        }
        if (card == "Wheel")
        {
            wheel++;
            Debug.Log("Wheels = " + wheel);
        }
        if (card == "Wire")
        {
            wire++;
            Debug.Log("Wires = " + wire);
        }

        if (currentCards >= 2)
        {
            if(pipe == 2)
            {
                DisbaleButtonsWithTag("Pipe");
                cardPicked = "";
                allCardsMatched++;
                currentCards = 0;
            }
            else if (wrench == 2)
            {
                DisbaleButtonsWithTag("Wrench");
                cardPicked = "";
                allCardsMatched++;
                currentCards = 0;
            }
            else if (wheel == 2)
            {
                DisbaleButtonsWithTag("Wheel");
                cardPicked = "";
                allCardsMatched++;
                currentCards = 0;
            }
            else if (wire == 2)
            {
                DisbaleButtonsWithTag("Wire");
                cardPicked = "";
                allCardsMatched++;
                currentCards = 0;
            }
            else
            {
                ResetCards();
            }
        }
        if (allCardsMatched == 4)
        {
            Debug.Log("You got a match");
            OnInteractEnd();
            OnPuzzleSolved.Invoke();
        }

    }

    public void DisbaleButtonsWithTag(string tag)
    {
        GameObject[] cards = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject matches in cards)
        {
            //Button button = obj.GetComponent<Button>();
            matches.SetActive(false);
        }
    }

    private void ResetCards()
    {
        Debug.Log("You picked wrong");
        cardPicked = "";
        currentCards = 0;
        pipe = 0;
        wrench = 0;
        wheel = 0;
        wire = 0;
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
        if (isEnabled)
        {
            base.OnInteractEnd();
            bc.enabled = true;
        }
    }

}
