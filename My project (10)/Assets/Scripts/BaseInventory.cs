using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "New Inventory")]
public class BaseInventory : ScriptableObject
{
    public List<GameObject> inventoryActive = new List<GameObject>();
    public List<GameObject> inventoryPassive = new List<GameObject>();

    public void AddWeapons(GameObject weapon)
    {
        bool hasItem = false;
        for (int i = 0; i < inventoryPassive.Count; i++)
        {
            if(inventoryPassive[i] == weapon)
            {
                hasItem = true;
                break;
            }    
        }    

        if (!hasItem)
        {
            inventoryPassive.Add(weapon);
        }    
    }    

    public void ClearInventory()
    {
        inventoryPassive.Clear();
        inventoryActive.Clear();
    }
}
