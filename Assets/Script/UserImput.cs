using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserImput : MonoBehaviour
{
    TowerOfHanoi ToH;
    WheelStack wheelStack;
    // Start is called before the first frame update
    void Start()
    {
        ToH = FindObjectOfType<TowerOfHanoi>();
        wheelStack = FindObjectOfType<WheelStack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TouchLeft()
    {
        //Debug.Log("TouchLeft(): ");
        Move(0);
    }

    public void TouchCenter()
    {
        //Debug.Log("TouchCenter(): ");
        Move(1);
    }

    public void TouchRight()
    {
        //Debug.Log("TouchRight(): ");
        Move(2);
        if (wheelStack.GetChildCount(2) == ToH.GameLevel) ToH.GameSet();
    }

    void Move(int index)
    {
        if (ToH.HasPickUp())
        {
            //Debug.Log("HasPickUp");
            if (ToH.IsValidForValue(index))
            {
                wheelStack.PushWheel(index);
                ToH.SetTextForCount();
            }
        }
        else if(!wheelStack.IsEmpty(index))
        {
            wheelStack.GetWheel(index);
            wheelStack.PopWheel(ToH.GetPickUp(),index);
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
