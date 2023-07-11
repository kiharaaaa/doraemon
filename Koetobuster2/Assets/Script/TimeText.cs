using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Text>().text = "6   ";
    }

    void Update()
    {
        float x = Mathf.Floor(61.0f - Time.time);
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
