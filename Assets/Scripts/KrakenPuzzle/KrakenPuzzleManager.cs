using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenPuzzleManager : BaseItems
{
    [SerializeField] private List<Transform> tentacleSockets;
    [SerializeField] private GameObject tentaclePrefab;

    private List<GameObject> tentacles = new();

    private PlayerInventory playerInventory;

    public override void Start()
    {
        base.Start();
        playerInventory = FindObjectOfType<PlayerInventory>();
    }

    
    void Update()
    {
        
    }

    public override void OnInteractBegin()
    {
        base.OnInteractBegin();
        
        if (playerInventory != null)
        {
            List<string> temp = playerInventory.GetKeyItems();
            for (int i = 0; i < temp.Count; i++)
            {
                if(temp[i] == "Tentacle")
                {
                    playerInventory.RemoveKeyItem(i);
                    Instantiate(tentaclePrefab, tentacleSockets[0]);
                    tentacleSockets.RemoveAt(0);
                }
            }
        }
    }

    public override void OnInteractEnd()
    {
        base.OnInteractEnd();
    }

    public override void OnHoverBegin()
    {
        base.OnHoverBegin();
    }

    public override void OnHoverEnd()
    {
        base.OnHoverEnd();
    }
}
