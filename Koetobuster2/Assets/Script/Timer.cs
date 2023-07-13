using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float timerLimit = 60f;
    float seconds = 0f;
    float startTime;
    bool endOnce = false;
    public Text timerText;

    [SerializeField] Clock clock;

    void Start()
    {
        timerText.text = "60";
        startTime = Time.time;
    }

void Update()
    {
        clock.UpdateClock(_updateTimer());
    }

    float _updateTimer()
    {
        seconds += Time.deltaTime;
        float timer = seconds / timerLimit;
        if(seconds >= timerLimit && !endOnce)
        {
            GameEnd.end = true;
            endOnce = true;
            return timer;
        }
        else
        {
            float x = Mathf.Floor(61.0f - (Time.time - startTime));
            timerText.text = x.ToString();
        }
        return timer;
    }
}