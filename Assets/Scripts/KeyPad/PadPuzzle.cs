using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadPuzzle : BaseItems
{
    private SphereCollider sc;

    public string password = "1234";
    private string userInput = "";

    bool isEnabled = true;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        userInput = "";
        sc = GetComponent<SphereCollider>();
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
            sc.enabled = false;
        }
    }

    public override void OnInteractEnd()
    {
        base.OnInteractEnd();
        sc.enabled = true;
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
            }
            else
            {
                Debug.Log("Incorrect");
                userInput = "";
            }
        }
    }
}
