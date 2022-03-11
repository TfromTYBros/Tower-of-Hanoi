using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    TowerOfHanoi ToH;
    [SerializeField] private GameObject HomePanelTemp;
    public static GameObject HomePanel;
    [SerializeField] private GameObject ResetPanelTemp;
    public static GameObject ResetPanel;
    [SerializeField] private GameObject ClearUITemp;
    public static GameObject ClearUI;

    void Start()
    {
        SetClearUI();
        ToH = FindObjectOfType<TowerOfHanoi>();
    }

    void SetClearUI()
    {
        ClearUI = ClearUITemp;
        HomePanel = HomePanelTemp;
        ResetPanel = ResetPanelTemp;
    }

    public void HomePanelYesButton()
    {
        HomePanelToDisabled();
        ToH.ResetMethod();
        SceneManager.LoadScene("HomeScene");
    }

    public void ResetPanelYesButton()
    {
        ResetPanelToDisabled();
        ToH.ResetMethod();
    }

    public static void ResetPanelToDisabled()
    {
        ResetPanel.SetActive(false);
    }

    public static void ResetPanelToEnabled()
    {
        ResetPanel.SetActive(true);
    }

    public static void HomePanelToDisabled()
    {
        HomePanel.SetActive(false);
    }

    public static void HomePanelToEnabled()
    {
        HomePanel.SetActive(true);
    }
    
    public static void SetEnabledClearUI()
    {
        ClearUI.SetActive(true);
    }

    public static void SetDisabledClearUI()
    {
        ClearUI.SetActive(false);
    }
}
