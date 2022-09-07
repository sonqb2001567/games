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

    private void Start()
    {
        uiElements.Add("EndGamePanel", GameObject.Find("EndGamePanel"));
        uiElements.Add("SettingPanel", GameObject.Find("SettingPanel"));
        uiElements["EndGamePanel"].SetActive(false);
        uiElements["SettingPanel"].SetActive(false);
    }

    public void OpenUI(string ui)
    {
        uiElements[ui].SetActive(true);
    }

    public void CloseUI(string ui)
    {
        uiElements[ui].SetActive(false);
    }

}
