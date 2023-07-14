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
    public GameObject clearTextLeft;
    public GameObject clearTextRight;
    public GameObject Panel;
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
        clearTextLeft.SetActive(false);
        clearTextRight.SetActive(false);
        Panel.SetActive(true);
        Clock.SetActive(true);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (end)
        {
            Invoke("title", 7);
            end = false;
            clearTextLeft.GetComponent<Text>().text = "SCORE:";
            clearTextRight.GetComponent<Text>().text = (Score.score * 100).ToString();

            backGround1.SetActive(true);
            backGround2.SetActive(true);
            backGround3.SetActive(true);
            backGround4.SetActive(true);
            scoreText.SetActive(false);
            clearTextLeft.SetActive(true);
            clearTextRight.SetActive(true);
            Panel.SetActive(false);
            Clock.SetActive(false);
            audioSource.Play();
        }
    }

    void title()
    {
        SceneManager.LoadScene("01_Title");
    }
}
