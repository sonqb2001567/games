using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickTreasure : MonoBehaviour
{
    [SerializeField] List<Weapon> weapons = new List<Weapon>();
    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0;
        GameObject go;
        for (int i = 1; i <= weapons.Count; i++)
        {
            go = GameObject.Find("Button (" + i + ")");
            go.transform.GetChild(0).GetComponent<Text>().text = weapons[i-1].description;
            go.transform.GetChild(1).GetComponent<Image>().sprite = weapons[i-1].sprite;
        }
    }

    public void UnPause()
    {
        Time.timeScale = 1;
    }    
}
