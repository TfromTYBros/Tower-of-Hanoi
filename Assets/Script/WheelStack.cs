using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelStack : MonoBehaviour
{
    TowerOfHanoi ToH;
    // Start is called before the first frame update
    void Start()
    {
        ToH = FindObjectOfType<TowerOfHanoi>();
    }

    public int GetChildCount(int index)
    {
        //Debug.Log(ToH.WheelParents[index].gameObject.transform.childCount);
        return ToH.WheelParents[index].gameObject.transform.childCount;
    }

    public void GetWheel(int index)
    {
        Debug.Log("GetChildCount(0): " + GetChildCount(0));
        ToH.WheelParents[index].transform.gameObject.transform.GetChild(GetChildCount(index) - 1).gameObject.transform.parent = ToH.GetPickUpBox().transform;
    }

    public GameObject PeekWheel(int index)
    {
        if (GetChildCount(index) <= 0) return null;
        return ToH.WheelParents[index].transform.GetChild(GetChildCount(index) - 1).gameObject;
    }

    public void PopWheel(GameObject wheel,int index)
    {
        Vector3 Flying = GetFlyDistance(index);
        wheel.transform.position = Flying;
    }

    public Vector3 GetFlyDistance(int index)
    {
        GameObject onebase = ToH.Bases[index];
        return new Vector3(onebase.transform.position.x, onebase.transform.position.y+6, onebase.transform.position.z);
    }

    public void PushWheel(int index)
    {
        //Debug.Log("PushWheel()");
        GameObject wheel = ToH.GetPickUpChild();

        wheel.transform.position = ToH.SetDistance(index);

        wheel.transform.parent = ToH.WheelParents[index].transform;
    }

    public bool IsEmpty(int index)
    {
        //Debug.Log("IsEmpty():");
        return GetChildCount(index) <= 0;
    }
}
