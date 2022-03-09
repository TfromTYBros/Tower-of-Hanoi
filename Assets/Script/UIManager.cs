using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    TowerOfHanoi ToH;
    public GameObject HomePanel;
    public GameObject ResetPanel;

    void Start()
    {
        ToH = FindObjectOfType<TowerOfHanoi>();
    }

    public void TouchHomeButton()
    {
        //Debug.Log("TouchHomeButton");
        HomePanelToEnabled();
    }

    public void TouchResetButton()
    {
        //Debug.Log("TouchResetButton");
        ResetPanelToEnabled();
    }

    public void YesButtonFromHomePanel()
    {
        HomePanelToDisabled();
        ToH.ResetMethod();
        SceneManager.LoadScene("HomeScene");
    }

    public void YesButtonFromResetPanel()
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
}
