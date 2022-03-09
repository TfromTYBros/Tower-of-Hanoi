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

    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CaptureScreenShot("ScreenShot.png");
        }
    }

    private void CaptureScreenShot(string filePath)
    {
        ScreenCapture.CaptureScreenshot(filePath);
    }*/

    public void TouchLeft()
    {
        Debug.Log("TouchLeft");
        Move(0);
    }

    public void TouchCenter()
    {
        Debug.Log("TouchCenter");
        Move(1);
    }

    public void TouchRight()
    {
        Debug.Log("TouchRight");
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
        Debug.Log("TouchHomeButton");
    }

    public void TouchResetButton()
    {
        Debug.Log("TouchResetButton");
    }
}
