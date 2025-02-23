using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MemoryPuzzleManager : BaseItems
{
    [SerializeField] private AudioClip puzzleSolved;
    private BoxCollider bc;
    private bool isEnabled = true;

    private bool octopus1 = false, starfish1 = false, otter1 = false, elephant1 = false, crab1 = false, chicken1 = false;
    private bool octopus2 = false, starfish2 = false, otter2 = false, elephant2 = false, crab2 = false, chicken2 = false;
    private int allCardsMatched = 0;
    private int currentCards = 0;
    private string cardPicked = "";

    public override void Start()
    {
        base.Start();
        bc = GetComponent<BoxCollider>();
    }

    public void ButtonClicked(string card)
    {
        //Debug.Log(cardPicked + "was picked");

        if (card == "Octopus1" && !octopus1) { cardPicked += card; octopus1 = true; currentCards++; Debug.Log(cardPicked + "was picked"); }
        if (card == "Octopus2" && !octopus2) { cardPicked += card; octopus2 = true; currentCards++; }
        if (card == "StarFish1" && !starfish1) { cardPicked += card; starfish1 = true; currentCards++; Debug.Log(cardPicked + "was picked"); }
        if (card == "StarFish2" && !starfish2) { cardPicked += card; starfish2 = true; currentCards++; Debug.Log(cardPicked + "was picked"); }
        if (card == "Otter1" && !otter1) { cardPicked += card; otter1 = true; currentCards++; Debug.Log(cardPicked + "was picked"); }
        if (card == "Otter2" && !otter2) { cardPicked += card; otter2 = true; currentCards++; Debug.Log(cardPicked + "was picked"); }
        if (card == "Elephant1" && !elephant1) { cardPicked += card; elephant1 = true; currentCards++; Debug.Log(cardPicked + "was picked"); }
        if (card == "Elephant2" && !elephant2) { cardPicked += card; elephant2 = true; currentCards++; Debug.Log(cardPicked + "was picked"); }
        if (card == "Crab1" && !crab1) { cardPicked += card; crab1 = true; currentCards++; Debug.Log(cardPicked + "was picked"); }
        if (card == "Crab2" && !crab2) { cardPicked += card; crab2 = true; currentCards++; Debug.Log(cardPicked + "was picked"); }
        if (card == "Chicken1" && !chicken1) { cardPicked += card; chicken1 = true; currentCards++; Debug.Log(cardPicked + "was picked"); }
        if (card == "Chicken2" && !chicken2) { cardPicked += card; chicken2 = true; currentCards++; Debug.Log(cardPicked + "was picked"); }

        //Debug.Log(card + " set to true");

        if (currentCards >= 2)
        {
            CheckForMatches();
            ResetCards();
        }
    }

    public void CheckForMatches()
    {
        if (octopus1 == true && octopus2 == true)
        {
            DisbaleButtonsWithTag("Octopus");
            allCardsMatched++;
            SoundFXManager.instance.PlaySoundFXClip(puzzleSolved, transform, 1f);
        }
        else if (starfish1 == true && starfish2 == true)
        {
            DisbaleButtonsWithTag("StarFish");
            allCardsMatched++;
            SoundFXManager.instance.PlaySoundFXClip(puzzleSolved, transform, 1f);
        }
        else if (otter1 == true && otter2 == true)
        {
            DisbaleButtonsWithTag("Otter");
            allCardsMatched++;
            SoundFXManager.instance.PlaySoundFXClip(puzzleSolved, transform, 1f);
        }
        else if (elephant1 == true && elephant2 == true)
        {
            DisbaleButtonsWithTag("Elephant");
            allCardsMatched++;
            SoundFXManager.instance.PlaySoundFXClip(puzzleSolved, transform, 1f);
        }
        else if (crab1 == true && crab2 == true)
        {
            DisbaleButtonsWithTag("Crab");
            allCardsMatched++;
            SoundFXManager.instance.PlaySoundFXClip(puzzleSolved, transform, 1f);
        }
        else if (chicken1 == true && chicken2 == true)
        {
            DisbaleButtonsWithTag("Chicken");
            allCardsMatched++;
            SoundFXManager.instance.PlaySoundFXClip(puzzleSolved, transform, 1f);
        }
        else
        {
            ResetCards();
        }
        cardPicked = "";
        currentCards = 0;
        if (allCardsMatched == 6)
        {
            Debug.Log("You got a match");
            OnInteractEnd();
            OnPuzzleSolved.Invoke();
            SoundFXManager.instance.PlaySoundFXClip(puzzleSolved, transform, 1f);
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
        octopus1 = false;
        octopus2 = false;
        starfish1 = false;
        starfish2 = false;
        otter1 = false;
        otter2 = false;
        elephant1 = false;
        elephant2 = false;
        crab1 = false;
        crab2 = false;
        chicken1 = false;
        chicken2 = false;
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
