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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PopFromLeft()
    {
        Debug.Log("PopFromLeft():");
        //if(PickUp.empty())一番上をPickUpに移す関数()
        //else PickUpからLeftに移す関数()
    }

    public void PopFromCenter()
    {
        Debug.Log("PopFromCenter():");
    }

    public void PopFromRight()
    {
        Debug.Log("PopFromRight():");
    }
}
