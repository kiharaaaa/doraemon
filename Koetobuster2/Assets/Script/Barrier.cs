using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public static bool barrierFlag = false;
    public static GameObject enemy;

    void FixedUpdate()
    {
        transform.position = enemy.transform.position;

        if (barrierFlag)
        {
            barrierFlag = false;
            Enemy.barrierCnt = 0;
            Destroy(gameObject, 0.1f);
        }
    }
}
