using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;
    
    void Update()
    {
        gameObject.GetComponent<Text>().text = "SCORE:" + (score*100).ToString();
    }
}
