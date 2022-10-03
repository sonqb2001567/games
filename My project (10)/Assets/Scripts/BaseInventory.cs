using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "New Inventory")]
public class BaseInventory : ScriptableObject
{
    public List<GameObject> inventory = new List<GameObject>();

    public void AddWeapons(GameObject weapon)
    {
        bool hasItem = false;
        for (int i = 0; i < inventory.Count; i++)
        {
            if(inventory[i] == weapon)
            {
                hasItem = true;
                break;
            }    
        }    

        if (!hasItem)
        {
            inventory.Add(weapon);
        }    
    }    

    public void ClearInventory()
    {
        inventory.Clear();
    }    
}
