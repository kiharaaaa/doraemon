using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mic : MonoBehaviour
{
    AudioSource audioSource;
    bool flag;
    public static bool isSound;

    void Start()
    {
        flag = false;
        if (Microphone.devices.Length == 0) return;

        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;

        audioSource.clip = Microphone.Start(Microphone.devices[0], true, 1, 12000);
        audioSource.Play();
    }

    void Update()
    {
        //isSound = CheckIsAudioDetected();
        flag = CheckIsAudioDetected();
        if (flag)
        {
            isSound = true;
            CancelInvoke();
            Invoke("sound", 1.0f);
        }
    }

    private bool CheckIsAudioDetected()
    {
        var buffer = new float[1024];
        audioSource.GetOutputData(buffer, 0);
        var total = 0f;
        foreach (var f in buffer)
        {
            total += f * f;
        }

        var average = Mathf.Sqrt(total / buffer.Length);

        if (average <= 0.01f)
        {
            return false;
        }
        return true;
    }
    
    void sound()
    {
        isSound = false;
    }

}
