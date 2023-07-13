using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NoScene : MonoBehaviour
{
    [SerializeField] Button StartButton;
    [SerializeField] Text Title;
    [SerializeField] GameObject Opening;
    [SerializeField] GameObject Loading;

    int spaceCount = 0;


    void Start()
    {
        StartButton.gameObject.SetActive(false);
        Title.gameObject.SetActive(false);
        Loading.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (spaceCount == 0)
            {
                Opening.SetActive(false);
                StartButton.gameObject.SetActive(true);
                Title.gameObject.SetActive(true);
                spaceCount++;
            }
            else
            {
                StartButton.gameObject.SetActive(false);
                Title.gameObject.SetActive(false);
                Loading.gameObject.SetActive(true);
                StartCoroutine("LoadScene");

            }
        }
    }

    private IEnumerator LoadScene()
    {
        var asyncT = SceneManager.LoadSceneAsync("03_Play");

        asyncT.allowSceneActivation = false;
        yield return new WaitForSeconds(6);
        asyncT.allowSceneActivation = true;
        yield return asyncT;

    }
}
