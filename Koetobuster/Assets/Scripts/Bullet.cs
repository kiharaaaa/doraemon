using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /*
    void OnCollisionExit(Collision collision)
    {
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }
    */
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(collider.gameObject);
        }
    }
}
