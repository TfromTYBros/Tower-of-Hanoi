using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerOfHanoi : MonoBehaviour
{
    WheelStack wheelStack;
    public GameObject[] Bases;
    public GameObject[] WheelPrefabs;
    public GameObject PickUpBox;
    public GameObject[] WheelParents;

    public int GameLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        wheelStack = FindObjectOfType<WheelStack>();
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        StartCoroutine(MakeTowerBySelectLevel(GameLevel));
    }

    IEnumerator MakeTowerBySelectLevel(int level)
    {
        for(int i = level-1; i >= 0; i--)
        {
            yield return new WaitForSeconds(0.1f);
            GameObject newWheel = Instantiate(WheelPrefabs[i], SetDistance(0), Quaternion.Euler(0, 0, 90f),WheelParents[0].transform);
            newWheel.name = "Wheel Value" + (i+1).ToString();
        }
        
    }

    public Vector3 SetDistance(int index)
    {
        GameObject onebase = Bases[index];
        return new Vector3(onebase.transform.position.x, onebase.transform.position.y + 0.5f + (wheelStack.GetChildCount(index) * 0.5f), onebase.transform.position.z);
    }

    public bool HasPickUp()
    {
        return 0 < PickUpBox.transform.childCount;
    }

    public GameObject GetPickUp()
    {
        return PickUpBox.transform.GetChild(0).gameObject;
    }

    public bool IsValidForValue(int index)
    {
        int pickWheelRank = IsRank(PickUpBox.transform.GetChild(0).gameObject);
        int topWheelRank = 0;
        if (wheelStack.peekWheel(index) == null) return true;
        else topWheelRank = IsRank(wheelStack.peekWheel(index));

        //Debug.Log("picknum" + pickWheelRank);
        //Debug.Log("topnum" + topWheelRank);

        return pickWheelRank < topWheelRank;
    }

    int IsRank(GameObject obj)
    {
        //Debug.Log("IsRank():");
        if (obj.name == "Wheel Value1") return 1;
        else if (obj.name == "Wheel Value2") return 2;
        else if (obj.name == "Wheel Value3") return 3;
        else if (obj.name == "Wheel Value4") return 4;
        else if (obj.name == "Wheel Value5") return 5;
        else if (obj.name == "Wheel Value6") return 6;
        else if (obj.name == "Wheel Value7") return 7;
        else return 8;
    }

    public void GameSet()
    {

    }
}
