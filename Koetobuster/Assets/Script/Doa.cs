using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doa : MonoBehaviour
{
    [SerializeField]
    [Tooltip("x²‚Ì‰ñ“]Šp“x")]
    private float rotateX = 0;

    [SerializeField]
    [Tooltip("y²‚Ì‰ñ“]Šp“x")]
    private float rotateY = 0;

    [SerializeField]
    [Tooltip("z²‚Ì‰ñ“]Šp“x")]
    private float rotateZ = 0;

    void Update()
    {
        // X,Y,Z²‚É‘Î‚µ‚Ä‚»‚ê‚¼‚êAw’è‚µ‚½Šp“x‚¸‚Â‰ñ“]‚³‚¹‚Ä‚¢‚éB
        gameObject.transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * Time.deltaTime);
    }
}
