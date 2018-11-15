using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerSet : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] TextMeshProUGUI timeLimitText;
    [SerializeField] GameObject timeLimit;

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
        if (timer.timeLimitInSeconds < 30)
        {
            timer.timeLimitInSeconds += 1;
            timeLimitText.text = timer.timeLimitInSeconds.ToString();
        }
    }

    public void DecreaseTimeLimit()
    {
        if (timer.timeLimitInSeconds > 1)
        {
            timer.timeLimitInSeconds -= 1;
            timeLimitText.text = timer.timeLimitInSeconds.ToString();
        }
    }

}
