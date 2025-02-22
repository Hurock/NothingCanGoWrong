using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenPuzzleManager : BaseItems
{
    [SerializeField] private List<Transform> tentacleSockets;
    [SerializeField] private GameObject tentaclePrefab;

    private List<GameObject> tentacles = new();

    private PlayerInventory playerInventory;

    [SerializeField] string puzzlePassword = "1234";
    [SerializeField] int passwordLength = 8;


    private bool isResetting;
    float timer = .0f;

    [SerializeField] private string currentPassword = "";

    private bool isInteractable = true;

    public override void Start()
    {
        base.Start();
        playerInventory = FindObjectOfType<PlayerInventory>();
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
                foreach (GameObject tentacle in tentacles)
                {
                    tentacle.GetComponent<Tentacle>().UncurlTentacle();
                }
            }
        }
        
    }
    public override void OnInteractBegin()
    {
        if (isInteractable)
        {
            base.OnInteractBegin();

            if (playerInventory != null)
            {
                List<string> temp = playerInventory.GetKeyItems();
                for (int i = 0; i < temp.Count; i++)
                {
                    if (temp[i] == "Tentacle")
                    {
                        playerInventory.RemoveKeyItem(i);
                        tentacles.Add(Instantiate(tentaclePrefab, tentacleSockets[0]));
                        tentacleSockets.RemoveAt(0);
                    }
                    if (tentacles.Count == 8)
                    {
                        Debug.Log("maximum tentacle reached");
                        isInteractable = false;
                        base.DisableCanvas(); 
                        foreach (GameObject tentacle in tentacles)
                        {
                            Tentacle tentacleScript = tentacle.GetComponent<Tentacle>();
                            tentacleScript.isInteractable = true;
                        }
                    }
                }
            }
        }
    }

    public override void OnInteractEnd()
    {
        if(isInteractable)
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

    public void AddToPassword(string characterToAdd)
    {
        currentPassword += characterToAdd;
        if (currentPassword.Length == 8) 
        {
            ComparePassword();
        }
    }

    private void ComparePassword()
    {
        if (currentPassword == puzzlePassword)
        {
            Debug.Log("Kraken puzzle password matches: " + currentPassword);
            foreach (GameObject tentacle in tentacles)
            {
                Tentacle temp = tentacle.GetComponent<Tentacle>();
                temp.isInteractable = false;
                temp.UncurlTentacle();
                temp.CurlTentacle();                
            }
        }
        else
        {
            Debug.Log("Kraken password doesn't match: " + currentPassword);
            currentPassword = "";
            isResetting = true;
            

        }
    }
}
