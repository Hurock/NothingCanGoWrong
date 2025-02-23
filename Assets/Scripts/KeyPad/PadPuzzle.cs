using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadPuzzle : BaseItems
{
    [SerializeField] private AudioClip puzzleSolved;
    private BoxCollider col;

    public string password = "1234";
    private string userInput = "";

    bool isEnabled = true;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        userInput = "";
        col = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            col.enabled = false;
        }
    }

    public override void OnInteractEnd()
    {
        base.OnInteractEnd();
        col.enabled = true;
    }
    public void ButtonClicked(string number)
    {
        userInput += number;
        Debug.Log(userInput + "pass word");
        if (userInput.Length >= 4)
        {
            if (userInput == password)
            {
                Debug.Log("Password correct");
                OnInteractEnd();
                OnPuzzleSolved.Invoke();
                SoundFXManager.instance.PlaySoundFXClip(puzzleSolved, transform, 1f);
            }
            else
            {
                Debug.Log("Incorrect");
                userInput = "";
            }
        }
    }
}
