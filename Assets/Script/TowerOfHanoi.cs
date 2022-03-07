using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerOfHanoi : MonoBehaviour
{
    WheelStack wheelStack;

    public GameObject[] Bases;
    public GameObject[] WheelPrefabs;
    public GameObject PickUpBox;
    public GameObject[] WheelParents;
    public GameObject HomeButton;
    public GameObject ResetButton;
    public Text CountText;

    public static int GameLevel = 1;
    private int MoveCount = 0;

    public bool GameStarted = true;

    // Start is called before the first frame update
    void Start()
    {
        wheelStack = FindObjectOfType<WheelStack>();
        StartGame();
    }

    public static void SetGameLevel(int level)
    {
        GameLevel = level;
    }

    public static int GetGameLevel()
    {
        return GameLevel;
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
        return 0 < GetPickUpBoxChildCount();
    }

    public void SetPickUpChild(int index)
    {
        Debug.Log("SetPickUpChild(): ");
        WheelParents[index].transform.gameObject.transform.GetChild(wheelStack.GetChildCount(index) - 1).gameObject.transform.parent = GetPickUpChild().transform;
        
    }

    public GameObject GetPickUpBox()
    {
        return PickUpBox;
    }

    public GameObject GetPickUpChild()
    {
        return PickUpBox.transform.GetChild(0).gameObject;
    }

    public int GetPickUpBoxChildCount()
    {
        int count = PickUpBox.transform.childCount == 1 ? 1 : 0;
        Debug.Log("count(): " + count);
        return count;
    }

    public bool IsValidForValue(int index)
    {
        int pickWheelRank = IsRank(GetPickUpChild());
        int topWheelRank;
        if (wheelStack.PeekWheel(index) == null) return true;
        else topWheelRank = IsRank(wheelStack.PeekWheel(index));

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

    public void SetTextForCount()
    {
        if (MoveCount <= 1000) MoveCount++;
        CountText.text = "Count " + MoveCount.ToString();
    }

    public void ResetMethod()
    {
        GameObject.Destroy(GetPickUpChild());
    }

    public void GameSet()
    {
        Debug.Log("GameSet");
        GameStarted = false;
    }
}
