using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerSet : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] TextMeshProUGUI timeLimitText;
    [SerializeField] GameObject timeLimit;
    [SerializeField] float upperTimerLimit = 20.0f;
    [SerializeField] float lowerTimerLimit = 1.0f;

    private void Start()
    {
        timeLimitText.text = timer.timeLimitInSeconds.ToString();       
    }

    public void ToggleTimeLimitSet()
    {
        timeLimit.SetActive(!timeLimit.activeSelf);
    }

    public void IncreaseTimeLimit()
    {
        if (timer.timeLimitInSeconds < upperTimerLimit)
        {
            timer.timeLimitInSeconds += 1;
            timeLimitText.text = timer.timeLimitInSeconds.ToString();
        }
    }

    public void DecreaseTimeLimit()
    {
        if (timer.timeLimitInSeconds > lowerTimerLimit)
        {
            timer.timeLimitInSeconds -= 1;
            timeLimitText.text = timer.timeLimitInSeconds.ToString();
        }
    }

}
