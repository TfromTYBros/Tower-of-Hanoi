using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerOfHanoi : MonoBehaviour
{
    public GameObject[] Bases;
    public GameObject[] Wheels;
    // Start is called before the first frame update
    void Start()
    {
        FFF();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FFF()
    {
        float yOffset = 0.5f;
        GameObject wheel8 = Instantiate(Wheels[7], new Vector3(Bases[0].transform.position.x, Bases[0].transform.position.y+yOffset, Bases[0].transform.position.z), Quaternion.Euler(0,0,90f));
        wheel8.name = "wheel8";
    }
}
