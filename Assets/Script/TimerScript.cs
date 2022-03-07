using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    private static int minute = 0;
    private static float second = 0f;
    public static Text TimerText;
    private static bool Stop = false;

    private void Start()
    {
        TimerText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TowerOfHanoi.GameStarted && !Stop) SetTimerText();
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

    static void TextChange()
    {
        TimerText.text = minute.ToString("00") + ":" + ((int)second).ToString("00");
    }

    bool IsTimerCountFull()
    {
        if (second == 59f && minute == 99) return true;
        else return false;
    }

    public static void TimerReset()
    {
        Stop = true;
        minute = 0;
        second = 0;
        TextChange();
    }

    public static void TimerStart()
    {
        Stop = false;
    }

    public static IEnumerator DelayTimerStart(float delay)
    {
        yield return new WaitForSeconds(delay);
        Stop = false;
    }
}
