using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public void SceneChangeToGameScene()
    {
        TowerOfHanoi.SetFalseGameEnd();
        TimerScript.TimerStart();
        SceneManager.LoadScene("GameScene");
    }
}
