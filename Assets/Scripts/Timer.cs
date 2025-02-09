using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Unity.Mathematics;

public class Timer : MonoBehaviour
{
    bool timerActive = true;
    float currentTime;
    float startTime;
    public int startMinutes;
    public TextMeshProUGUI CurrentTimeLeft;
    public Image ProgressCircle;
    public Image TimerArm;

    void Start()
    {
        currentTime = startMinutes * 60;
        startTime = startMinutes * 60;
    }

    void Update()
    {
        if (timerActive)
        {
            currentTime = currentTime - Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        CurrentTimeLeft.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();

        float timePercent = currentTime / startTime;
        ProgressCircle.fillAmount = timePercent;
        float rotateAmount = 360.0f * timePercent;
        TimerArm.transform.rotation = Quaternion.Euler(0, 0, -rotateAmount);
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }
}
