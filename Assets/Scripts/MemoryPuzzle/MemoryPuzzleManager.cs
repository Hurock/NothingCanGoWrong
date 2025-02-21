using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MemoryPuzzleManager : BaseItems
{
    private BoxCollider bc;
    private bool isEnabled = true;

    private bool pipe1 = false, wrench1 = false, wheel1 = false, wire1 = false;
    private bool pipe2 = false, wrench2 = false, wheel2 = false, wire2 = false;
    private int allCardsMatched = 0;
    private int currentCards = 0;
    private string cardPicked = "";

    public override void Start()
    {
        bc = GetComponent<BoxCollider>();
    }

    public void ButtonClicked(string card)
    {
        //Debug.Log(cardPicked + "was picked");

        if (card == "Pipe1" && !pipe1) { cardPicked += card; pipe1 = true; currentCards++; Debug.Log(cardPicked + "was picked"); }
        if (card == "Pipe2" && !pipe2) { cardPicked += card; pipe2 = true; currentCards++; }
        if (card == "Wrench1" && !wrench1) { cardPicked += card; wrench1 = true; currentCards++; Debug.Log(cardPicked + "was picked"); }
        if (card == "Wrench2" && !wrench2) { cardPicked += card; wrench2 = true; currentCards++; Debug.Log(cardPicked + "was picked"); }
        if (card == "Wheel1" && !wheel1) { cardPicked += card; wheel1 = true; currentCards++; Debug.Log(cardPicked + "was picked"); }
        if (card == "Wheel2" && !wheel2) { cardPicked += card; wheel2 = true; currentCards++; Debug.Log(cardPicked + "was picked"); }
        if (card == "Wire1" && !wire1) { cardPicked += card; wire1 = true; currentCards++; Debug.Log(cardPicked + "was picked"); }
        if (card == "Wire2" && !wire2) { cardPicked += card; wire2 = true; currentCards++; Debug.Log(cardPicked + "was picked"); }

        //Debug.Log(card + " set to true");

        if (currentCards >= 2)
        {
            CheckForMatches();
            ResetCards();
        }
    }

    public void CheckForMatches()
    {
        if (pipe1 == true && pipe2 == true)
        {
            DisbaleButtonsWithTag("Pipe");
            allCardsMatched++;
        }
        else if (wrench1 == true && wrench2 == true)
        {
            DisbaleButtonsWithTag("Wrench");
            allCardsMatched++;
        }
        else if (wheel1 == true && wheel2 == true)
        {
            DisbaleButtonsWithTag("Wheel");
            allCardsMatched++;
        }
        else if (wire1 == true && wire2 == true)
        {
            DisbaleButtonsWithTag("Wire");
            allCardsMatched++;
        }
        else
        {
            ResetCards();
        }
        cardPicked = "";
        currentCards = 0;
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
        pipe1 = false;
        pipe2 = false;
        wrench1 = false;
        wrench2 = false;
        wheel1 = false;
        wheel2 = false;
        wire1 = false;
        wire2 = false;
        cardPicked = "";
        currentCards = 0;
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
