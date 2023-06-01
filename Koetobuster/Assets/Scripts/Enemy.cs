using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    public float speed;

    void Update()
    {
        Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.1f);
        Vector3 p = new Vector3(0f, 0f, speed);

        transform.Translate(p);
    }
}