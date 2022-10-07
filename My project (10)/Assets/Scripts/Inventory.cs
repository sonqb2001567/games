using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] BaseInventory inventory;
    [SerializeField] GameObject inventoryUI;
    void Update()
    {
        for (int i = 0; i < inventory.inventoryPassive.Count; i++)
        {
            inventoryUI.transform.GetChild(1).GetChild(i).GetChild(0).GetComponent<Image>().sprite = inventory.inventoryPassive[i].GetComponent<SpriteRenderer>().sprite;
        }    
    }
}
