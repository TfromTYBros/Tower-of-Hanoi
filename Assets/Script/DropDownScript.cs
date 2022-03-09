using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownScript : MonoBehaviour
{
    public Dropdown gameLevelDropDown;

    private void Start()
    {
        gameLevelDropDown.value = TowerOfHanoi.GameLevel-1;
        TowerOfHanoi.SetGameLevel(TowerOfHanoi.GameLevel);
    }

    public void SetGameLevelByDDS()
    {
        int level = gameLevelDropDown.value + 1;
        TowerOfHanoi.SetGameLevel(level);
    }
}
