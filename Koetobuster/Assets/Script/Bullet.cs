using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosionPrefab;
    float z;

    void Start()
    {
        z = gameObject.transform.position.z;
    }
    void Update()
    {
        if(gameObject.transform.position.z > z + 50)
        {
            Destroy(gameObject);
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
                }
                else
                {
                    Barrier.barrierFlag = true;
                }
            }
            //Enemy.HP2--;
            Destroy(gameObject);
        }
    }
}
