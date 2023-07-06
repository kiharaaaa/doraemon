using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip explosion;
    public AudioClip attack;
    public AudioClip barrier;
    public AudioClip shot;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Bullet.explosionSound)
        {
            audioSource.PlayOneShot(explosion);
            Bullet.explosionSound = false;
        }

        if (Enemy.attackSound)
        {
            audioSource.PlayOneShot(attack);
            Enemy.attackSound = false;
        }

        if (Enemy.barrierSound)
        {
            audioSource.PlayOneShot(barrier);
            Enemy.barrierSound = false;
        }

        if (Shot.shotSound)
        {
            audioSource.PlayOneShot(shot);
            Shot.shotSound = false;
        }
    }
}
