using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static bool explosionSound;
    public GameObject explosionPrefab;
    float z;
    static int tmpscore;

    void Start()
    {
        explosionSound = false;
        z = gameObject.transform.position.z;
    }

    void Update()
    {
        if (gameObject.transform.position.z > z + 50)
        {
            Destroy(gameObject);
        }
        if (gameObject.transform.position.z > z + 16 && gameObject.tag == Shot.lastMojiTag)
        {
            Voice.voiceFlag = 0;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            if (gameObject.tag == Shot.lastMojiTag)
            {
                if (Enemy.attack)
                {
                    Destroy(collider.gameObject);
                    Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                    Enemy.attack = false;
                    explosionSound = true;
                    Score.score += tmpscore;
                    tmpscore = 0;
                }
                else
                {
                    Barrier.barrierFlag = true;
                }
                Voice.voiceFlag = 0;
            }
            else if(gameObject.tag != "Untagged")
            {
                tmpscore = int.Parse(gameObject.tag);
            }
            
            Destroy(gameObject);
        }
    }
}
