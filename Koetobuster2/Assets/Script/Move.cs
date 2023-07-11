using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    public static float MoveSpeed = 0.8f;

    private int direction = 1;

    void FixedUpdate()
    {
        if (transform.position.z <= startPoint.position.z) direction = 1;
        if (transform.position.z >= endPoint.position.z)   direction = 0;

        transform.position = new Vector3(startPoint.transform.position.x, startPoint.transform.position.y, transform.position.z + MoveSpeed * Time.fixedDeltaTime * direction);
    }
}
