using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownScript : MonoBehaviour
{
    public Dropdown gameLevelDropDown;

    public void SetGameLevelByDDS()
    {
        int level = gameLevelDropDown.value + 1;
        TowerOfHanoi.SetGameLevel(level);
    }
}
