using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("01_Title");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            string now = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(now);
        }
    }
}
