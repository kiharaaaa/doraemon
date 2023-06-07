using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotText : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Text>().text = "Voice: Loading";
    }

    void Update()
    {
        if (Voice.voiceFlag == 0)      gameObject.GetComponent<Text>().text = "Voice: Loading";
        else if (Voice.voiceFlag == 2) gameObject.GetComponent<Text>().text = "Voice: Fire";
    }
}
