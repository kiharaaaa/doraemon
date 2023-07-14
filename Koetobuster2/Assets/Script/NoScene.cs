using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NoScene : MonoBehaviour
{
    [SerializeField] Button StartButton;
    [SerializeField] Button TutorialButton;
    [SerializeField] Text TitleLeft;
    [SerializeField] Text TitleRight;
    [SerializeField] GameObject Opening;
    [SerializeField] GameObject Loading;

    public AudioClip buttonMove;
    public AudioClip buttonDecision;
    public AudioClip buttonMiss;
    AudioSource audioSource;

    int idx = 0;  // 0.Title  1.Tutorial

    void Start()
    {
        StartButton.gameObject.SetActive(true);
        TutorialButton.gameObject.SetActive(true);
        TitleLeft.gameObject.SetActive(true);
        TitleRight.gameObject.SetActive(true);
        Loading.gameObject.SetActive(false);
        Opening.gameObject.SetActive(false);

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (idx == 1)
            {
                idx--;
                audioSource.PlayOneShot(buttonMove);
            }
            else
            {
                audioSource.PlayOneShot(buttonMiss);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (idx == 0)
            {
                idx++;
                audioSource.PlayOneShot(buttonMove);
            }
            else
            {
                audioSource.PlayOneShot(buttonMiss);
            }
        }

        if (idx == 0)
        {
            StartButton.GetComponent<Image>().color = new Color(100f / 255f, 200f / 255f, 200f / 255, 1f);
            TutorialButton.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
        else if (idx == 1)
        {
            StartButton.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            TutorialButton.GetComponent<Image>().color = new Color(100f / 255f, 200f / 255f, 200f / 255f, 1f);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            audioSource.PlayOneShot(buttonDecision);
            if (idx == 0)
            {
                StartButton.gameObject.SetActive(false);
                TutorialButton.gameObject.SetActive(false);
                TitleLeft.gameObject.SetActive(false);
                TitleRight.gameObject.SetActive(false);

                Loading.gameObject.SetActive(true);
                //StartCoroutine("LoadScene_03");
                Invoke("LoadScene_03", 6f);
            }
            else if (idx == 1)
            {
                StartButton.gameObject.SetActive(false);
                TutorialButton.gameObject.SetActive(false);
                TitleLeft.gameObject.SetActive(false);
                TitleRight.gameObject.SetActive(false);

                Loading.gameObject.SetActive(true);
                //StartCoroutine("LoadScene_02");
                Invoke("LoadScene_02", 6f);
            }
        }

        if (Input.GetKey(KeyCode.O) && Input.GetKey(KeyCode.P))
        {
            StartButton.gameObject.SetActive(false);
            TutorialButton.gameObject.SetActive(false);
            TitleLeft.gameObject.SetActive(false);
            TitleRight.gameObject.SetActive(false);

            Opening.gameObject.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            CancelInvoke();
            StartButton.gameObject.SetActive(true);
            TutorialButton.gameObject.SetActive(true);
            TitleLeft.gameObject.SetActive(true);
            TitleRight.gameObject.SetActive(true);
            Loading.gameObject.SetActive(false);
            Opening.gameObject.SetActive(false);
        }
    }

    void LoadScene_02()
    {
        SceneManager.LoadScene("02_Tutorial");
    }
    void LoadScene_03()
    {
        SceneManager.LoadScene("03_Play");
    }

    /*
    private IEnumerator LoadScene_02()
    {
        var asyncT = SceneManager.LoadSceneAsync("02_Tutorial");

        asyncT.allowSceneActivation = false;
        yield return new WaitForSeconds(6);
        asyncT.allowSceneActivation = true;
        yield return asyncT;

    }
    private IEnumerator LoadScene_03()
    {
        var asyncT = SceneManager.LoadSceneAsync("03_Play");

        asyncT.allowSceneActivation = false;
        yield return new WaitForSeconds(6);
        asyncT.allowSceneActivation = true;
        yield return asyncT;

    }
    */
}
