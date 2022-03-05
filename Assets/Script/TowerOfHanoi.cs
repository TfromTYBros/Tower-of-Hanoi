using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerOfHanoi : MonoBehaviour
{
    public GameObject[] Bases;
    public GameObject[] WheelPrefabs;
    public GameObject PickUpWheel;
    public GameObject WheelsParent;

    public int GameLevel = 8;
    /*
    public int WheelsCount_Left = 0;
    public int WheelsCount_Center = 0;
    public int WheelsCount_Right = 0;*/
    public Stack<GameObject> Stack_Left;
    public Stack<GameObject> Stack_Center;
    public Stack<GameObject> Stack_Right;

    // Start is called before the first frame update
    void Start()
    {
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
        //WheelsCount_Left = level;

        float yOffset = 0.5f;
        for(int i = level-1; i >= 0; i--)
        {
            yield return new WaitForSeconds(0.1f);
            GameObject newWheel = Instantiate(WheelPrefabs[i], new Vector3(Bases[0].transform.position.x, Bases[0].transform.position.y + yOffset, Bases[0].transform.position.z), Quaternion.Euler(0, 0, 90f),WheelsParent.transform);
            newWheel.name = "Wheel Value" + (i+1).ToString();
            yOffset += 0.5f;
        }
        
    }

    void PickUp()
    {
        //if(WheelsCount_Left != 0)一番上のオブジェクトを空中のY座標に移動させる

    }

    void GameSet()
    {

    }
}
