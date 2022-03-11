using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserImput : MonoBehaviour
{
    TowerOfHanoi ToH;
    // Start is called before the first frame update
    void Start()
    {
        ToH = FindObjectOfType<TowerOfHanoi>();
    }

    public void TouchLeft()
    {
        //Debug.Log("TouchLeft");
        Move(0);
    }

    public void TouchCenter()
    {
        //Debug.Log("TouchCenter");
        Move(1);
    }

    public void TouchRight()
    {
        //Debug.Log("TouchRight");
        Move(2);
        if (ToH.GetChildCountByWheelParent(2) == TowerOfHanoi.GetGameLevel()) ToH.GameSet();
    }

    void Move(int index)
    {
        if (ToH.HasPickUp())
        {
            //Debug.Log("HasPickUp");
            if (ToH.IsValidForValue(index))
            {
                ToH.PushWheel(index);
                ToH.SetCountText();
            }
        }
        else if(!ToH.IsEmpty(index))
        {
            ToH.GetTopWheel(index);
            ToH.PopWheel(ToH.GetPickUpChild(),index);
        }
    }

    public void TouchHomeButton()
    {
        //Debug.Log("TouchHomeButton");
        if (!TowerOfHanoi.GetGameEnd()) UIManager.HomePanelToEnabled();
        else
        {
            UIManager.SetDisabledClearUI();
            ToH.ResetMethod();
            UnityEngine.SceneManagement.SceneManager.LoadScene("HomeScene");
        }
    }

    public void TouchResetButton()
    {
        //Debug.Log("TouchResetButton");
        if (!TowerOfHanoi.GetGameEnd()) UIManager.ResetPanelToEnabled();
        else
        {
            UIManager.SetDisabledClearUI();
            ToH.ResetMethod();
        }
    }
}
