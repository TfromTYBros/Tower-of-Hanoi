using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerOfHanoi : MonoBehaviour
{
    public GameObject[] Bases;
    public GameObject[] WheelPrefabs;
    public GameObject PickUpBox;
    public GameObject[] WheelParents;

    public GameObject HomeButton;
    public GameObject ResetButton;
    public Text CountText;

    private static int GameLevel = 3;
    private int MoveCount = 0;

    public BoxCollider2D[] cols;

    public static bool GameEnd = false;

    // Start is called before the first frame update
    void Start()
    {
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
        return new Vector3(onebase.transform.position.x, onebase.transform.position.y + 0.5f + (GetChildCountByWheelParent(index) * 0.5f), onebase.transform.position.z);
    }

    public bool IsValidForValue(int index)
    {
        int pickWheelRank = IsRank(GetPickUpChild());
        int topWheelRank;
        if (PeekWheel(index) == null) return true;
        else topWheelRank = IsRank(PeekWheel(index));

        //Debug.Log("picknum" + pickWheelRank);
        //Debug.Log("topnum" + topWheelRank);

        return pickWheelRank < topWheelRank;
    }


    public void SetPickUpChild(int index)
    {
        //Debug.Log("SetPickUpChild(): ");
        WheelParents[index].transform.gameObject.transform.GetChild(GetChildCountByWheelParent(index) - 1).gameObject.transform.parent = GetPickUpChild().transform;

    }

    public GameObject GetPickUpBox()
    {
        return PickUpBox;
    }

    public GameObject GetPickUpChild()
    {
        return PickUpBox.transform.GetChild(0).gameObject;
    }

    public int GetChildCountByPickUpBox()
    {
        return PickUpBox.transform.childCount;
    }

    public int GetChildCountByWheelParent(int index)
    {
        //Debug.Log(WheelParents[index].gameObject.transform.childCount);
        return WheelParents[index].gameObject.transform.childCount;
    }

    public bool HasPickUp()
    {
        //Debug.Log("HasPickUp" + (0 < PickUpBox.transform.childCount));
        return 0 < PickUpBox.transform.childCount;
    }

    public void GetTopWheel(int index)
    {
        //Debug.Log("GetChildCount(0): " + GetChildCount(0));
        WheelParents[index].transform.gameObject.transform.GetChild(GetChildCountByWheelParent(index) - 1).gameObject.transform.parent = GetPickUpBox().transform;
    }

    public GameObject PeekWheel(int index)
    {
        if (GetChildCountByWheelParent(index) <= 0) return null;
        return WheelParents[index].transform.GetChild(GetChildCountByWheelParent(index) - 1).gameObject;
    }

    public void PopWheel(GameObject wheel, int index)
    {
        Vector3 Flying = GetFlyDistance(index);
        wheel.transform.position = Flying;
    }

    public Vector3 GetFlyDistance(int index)
    {
        GameObject onebase = Bases[index];
        return new Vector3(onebase.transform.position.x, onebase.transform.position.y + 6, onebase.transform.position.z);
    }

    public void PushWheel(int index)
    {
        //Debug.Log("PushWheel()");
        GameObject wheel = GetPickUpChild();
        wheel.transform.position = SetDistance(index);
        wheel.transform.parent = WheelParents[index].transform;
    }

    public bool IsEmpty(int index)
    {
        //Debug.Log("IsEmpty():");
        return GetChildCountByWheelParent(index) <= 0;
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

    public void SetCountText()
    {
        if (MoveCount <= 1000) MoveCount++;
        MoveCountTextChanger();
    }

    void MoveCountTextChanger()
    {
        CountText.text = "Count " + MoveCount.ToString();
    }

    void MoveCountTextReset()
    {
        MoveCount = 0;
        MoveCountTextChanger();
    }

    public void ResetMethod()
    {
        if(GetChildCountByPickUpBox() == 1) GameObject.Destroy(GetPickUpChild());
        for(int i = 0; i < 3; i++)
        {
            if(0 < GetChildCountByWheelParent(i))
            {
                foreach (Transform child in WheelParents[i].transform) GameObject.Destroy(child.gameObject);
            }
        }
        SetFalseGameEnd();
        MoveCountTextReset();
        float delay = 0.1f + (0.1f * GameLevel);
        TimerScript.TimerReset();
        StartCoroutine(TimerScript.DelayTimerStart(delay));
        FalseAllCollider2d();
        StartCoroutine(TrueAllCollider2d(delay));
        StartGame();
    }

    void FalseAllCollider2d()
    {
        cols[0].enabled = false;
        cols[1].enabled = false;
        cols[2].enabled = false;
    }

    IEnumerator TrueAllCollider2d(float delay)
    {
        yield return new WaitForSeconds(delay);
        cols[0].enabled = true;
        cols[1].enabled = true;
        cols[2].enabled = true;
    }

    public void GameSet()
    {
        //Debug.Log("GameSet");
        SetTrueGameEnd();
        FalseAllCollider2d();
        UIManager.SetEnabledClearUI();
    }

    public static bool GetGameEnd()
    {
        return GameEnd;
    }

    public static void SetFalseGameEnd()
    {
        GameEnd = false;
    }

    public static void SetTrueGameEnd()
    {
        GameEnd = true;
    }
}
