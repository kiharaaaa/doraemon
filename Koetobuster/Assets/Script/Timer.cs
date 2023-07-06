using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float timerLimit = 60f;
    float seconds = 0f;

    [SerializeField] Clock clock;

    void Update()
    {
        clock.UpdateClock(_updateTimer());
    }

    float _updateTimer()
    {
        seconds += Time.deltaTime;
        float timer = seconds / timerLimit;

        return timer;
    }
}