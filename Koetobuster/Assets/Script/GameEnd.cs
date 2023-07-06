using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public static bool end;
    static bool flag;
    public GameObject backGround;
    public GameObject scoreText;
    public GameObject scoreText2;
    public GameObject Clock;

    void Start()
    {
        end = false;
        flag = false;
        backGround.SetActive(false);
        scoreText.SetActive(true);
        scoreText2.SetActive(false);
        Clock.SetActive(true);
    }

    void Update()
    {
        if (end)
        {
            Invoke("title", 10);
            flag = true;
            end = false;
        }
        if (flag)
        {

        }
    }

    void title()
    {
        SceneManager.LoadScene(0);
    }
}
