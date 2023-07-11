using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : MonoBehaviour
{
    public float speed = 1.0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) transform.position += transform.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow)) transform.position -= transform.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow)) transform.position += transform.right * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow)) transform.position -= transform.right * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftShift)) transform.position += transform.up * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space)) transform.position -= transform.up * speed * Time.deltaTime;

    }
}