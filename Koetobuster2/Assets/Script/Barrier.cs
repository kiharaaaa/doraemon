using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public static bool barrierFlag = false;

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Move.MoveSpeed * Time.fixedDeltaTime);

        if (barrierFlag)
        {
            barrierFlag = false;
            Enemy.barrierCnt = 0;
            Destroy(gameObject, 0.1f);
        }
    }
}
