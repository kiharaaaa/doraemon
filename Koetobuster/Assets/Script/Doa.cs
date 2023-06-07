using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doa : MonoBehaviour
{
    [SerializeField]
    [Tooltip("x���̉�]�p�x")]
    private float rotateX = 0;

    [SerializeField]
    [Tooltip("y���̉�]�p�x")]
    private float rotateY = 0;

    [SerializeField]
    [Tooltip("z���̉�]�p�x")]
    private float rotateZ = 0;

    void Update()
    {
        // X,Y,Z���ɑ΂��Ă��ꂼ��A�w�肵���p�x����]�����Ă���B
        gameObject.transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * Time.deltaTime);
    }
}
