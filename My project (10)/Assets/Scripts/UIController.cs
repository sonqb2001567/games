using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public Dictionary<string, GameObject> uiElements = new Dictionary<string, GameObject>();

    #region Singleton
    public static UIController instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public void OpenUI(string ui)
    {
        uiElements[ui].SetActive(true);
    }

    public void CloseUI(string ui)
    {
        uiElements[ui].SetActive(false);
    }

}
