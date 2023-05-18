using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doa : MonoBehaviour
{
    [SerializeField]
    [Tooltip("x軸の回転角度")]
    private float rotateX = 0;

    [SerializeField]
    [Tooltip("y軸の回転角度")]
    private float rotateY = 0;

    [SerializeField]
    [Tooltip("z軸の回転角度")]
    private float rotateZ = 0;

    void Update()
    {
        // X,Y,Z軸に対してそれぞれ、指定した角度ずつ回転させている。
        gameObject.transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * Time.deltaTime);
    }
}
