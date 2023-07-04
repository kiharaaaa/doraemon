using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{
    public int second;

    void Start()
    {
        gameObject.GetComponent<Text>().text = "Time: 60s";
    }

    void Update()
    {
        gameObject.GetComponent<Text>().text = "Time: " + Mathf.Floor(60.0f - Time.time).ToString() + "s";
    }
}
