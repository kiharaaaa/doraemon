using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargeSound : MonoBehaviour
{
    AudioSource audioSource;
    bool flag;

    void Start()
    {
        flag = true;
        audioSource = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Voice.chargeSound && flag)
        {
            audioSource.Play();
            flag = false;
        }
        else if(!(Voice.chargeSound))
        {
            audioSource.Stop();
            flag = true;
        }
    }
}
