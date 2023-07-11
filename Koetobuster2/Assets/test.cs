using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    void Update()
    {
        gameObject.GetComponent<Text>().text = Input.mousePosition.ToString();
    }
}
