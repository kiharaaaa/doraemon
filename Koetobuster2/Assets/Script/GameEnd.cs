using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    public static bool end;
    public GameObject backGround1;
    public GameObject backGround2;
    public GameObject backGround3;
    public GameObject backGround4;
    public GameObject scoreText;
    public GameObject scoreText2;
    public GameObject Clock;
    AudioSource audioSource;

    void Start()
    {
        end = false;
        backGround1.SetActive(false);
        backGround2.SetActive(false);
        backGround3.SetActive(false);
        backGround4.SetActive(false);
        scoreText.SetActive(true);
        scoreText2.SetActive(false);
        Clock.SetActive(true);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (end)
        {
            Invoke("title", 7);
            end = false;
            scoreText2.GetComponent<Text>().text = "SCORE:" + Score.score.ToString();

            backGround1.SetActive(true);
            backGround2.SetActive(true);
            backGround3.SetActive(true);
            backGround4.SetActive(true);
            scoreText.SetActive(false);
            scoreText2.SetActive(true);
            Clock.SetActive(false);
            audioSource.Play();
        }
    }

    void title()
    {
        SceneManager.LoadScene("01_Title");
    }
}
