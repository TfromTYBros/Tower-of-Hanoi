using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    TowerOfHanoi ToH;
    public GameObject HomePanel;
    public GameObject ResetPanel;
    [SerializeField] private GameObject ClearUITemp;
    public static GameObject ClearUI;

    void Start()
    {
        SetClearUI();
        ToH = FindObjectOfType<TowerOfHanoi>();
    }

    public void TouchHomeButton()
    {
        //Debug.Log("TouchHomeButton");
        if(!TowerOfHanoi.GetGameEnd())HomePanelToEnabled();
        else
        {
            SetDisabledClearUI();
            ToH.ResetMethod();
            SceneManager.LoadScene("HomeScene");
        }
    }

    public void TouchResetButton()
    {
        //Debug.Log("TouchResetButton");
        if(!TowerOfHanoi.GetGameEnd())ResetPanelToEnabled();
        else
        {
            SetDisabledClearUI();
            ToH.ResetMethod();
        }
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

    public void ResetPanelToDisabled()
    {
        ResetPanel.SetActive(false);
    }

    public void ResetPanelToEnabled()
    {
        ResetPanel.SetActive(true);
    }

    public void HomePanelToDisabled()
    {
        HomePanel.SetActive(false);
    }

    public void HomePanelToEnabled()
    {
        HomePanel.SetActive(true);
    }

    void SetClearUI()
    {
        ClearUI = ClearUITemp;
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
