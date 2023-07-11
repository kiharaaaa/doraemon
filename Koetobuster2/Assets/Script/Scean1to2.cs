using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scean1to2 : MonoBehaviour
{
    void Update()
    {    
        if (Input.GetKeyDown(KeyCode.Return))   
        {
            SceneManager.LoadScene(1);  // NowLoading
        }   
    }
}
