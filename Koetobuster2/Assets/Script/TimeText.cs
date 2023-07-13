using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{
    float startTime;
    void Start()
    {
        gameObject.GetComponent<Text>().text = "60";
        startTime = Time.time;
    }

    void Update()
    {
        float x = Mathf.Floor(61.0f - (Time.time - startTime));
        if(x >= 0)
        {
            gameObject.GetComponent<Text>().text = x.ToString();
        }
        else
        {
            GameEnd.end = true;
        }
    }
}
