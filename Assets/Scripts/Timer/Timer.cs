using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Image timerImage;
    public float timeLimitInSeconds = 5.0f;
    [SerializeField] private bool isRunning = false;
    private float remainingTime;

	void Update()
    {
        if (isRunning && remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            timerImage.fillAmount = remainingTime / timeLimitInSeconds;
            if (remainingTime <= 0)
            {
                isRunning = false;
            }
        }
	}

    public void StartTimer()
    {
        remainingTime = timeLimitInSeconds;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
        timerImage.fillAmount = 0;
    }
}
