using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    TowerOfHanoi ToH;

    private int minute = 0;
    private float second = 0f;
    public Text TimerText;

    // Start is called before the first frame update
    void Start()
    {
        ToH = FindObjectOfType<TowerOfHanoi>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ToH.GameStarted) SetTimerText();
    }

    void SetTimerText()
    {
        second += Time.deltaTime;
        if(second >= 60)
        {
            minute++;
            second -= 60f;
        }
        if(!IsTimerCountFull()) TextChange();
    }

    void TextChange()
    {
        TimerText.text = minute.ToString("00") + ":" + ((int)second).ToString("00");
    }

    bool IsTimerCountFull()
    {
        if (second == 59f && minute == 99) return true;
        else return false;
    }

    public void TimerReset()
    {
        //Reset‚·‚é
    }
}
