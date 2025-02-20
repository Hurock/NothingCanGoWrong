using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    public string password = "1234";
    private string userInput = "";

    private void Start()
    {
        userInput = "";
    }

    public void ButtonClicked(string number)
    {
        userInput += number;
        Debug.Log(userInput + "pass word");
        if (userInput.Length >= 4)
        {
            if(userInput == password)
            {
                Debug.Log("Password correct");
            }
            else
            {
                Debug.Log("Incorrect");
                userInput = "";
            }
        }
    }
}
