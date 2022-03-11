using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownScript : MonoBehaviour
{
    public Dropdown gameLevelDropDown;

    private void Start()
    {
        gameLevelDropDown.value = TowerOfHanoi.GetGameLevel()-1;
        TowerOfHanoi.SetGameLevel(TowerOfHanoi.GetGameLevel());
    }

    public void SetGameLevelByDDS()
    {
        int level = gameLevelDropDown.value + 1;
        TowerOfHanoi.SetGameLevel(level);
    }

    public void SetGameLevelAnimationButton(int level)
    {
        gameLevelDropDown.value = level-1;
        TowerOfHanoi.SetGameLevel(level);
    }
}
