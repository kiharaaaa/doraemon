using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;

    void Start()
    {
        score = 0;
        gameObject.GetComponent<Text>().text = "SCORE:0";
    }
    
    void Update()
    {
        gameObject.GetComponent<Text>().text = "SCORE:" + score.ToString();
    }
}
