using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<string> inventoryKeyItems = new();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<string> GetKeyItems()
    {
        return inventoryKeyItems;
    }

    public void AddKeyItem(string itemToAdd)
    {
        inventoryKeyItems.Add(itemToAdd);
    }

    public void RemoveKeyItem(int itemToRemove)
    {
        inventoryKeyItems.RemoveAt(itemToRemove);
    }
}
