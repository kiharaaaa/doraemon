using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    public int HP = 3;
    bool flag = false;
    public static bool attack = true;

    Material beforeMaterial;
    public Material afterMaterial;

    void Start()
    {
        beforeMaterial = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z + 15);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == HP.ToString())
        {
            flag = true;
            attack = true;
        }

        if(flag) GetComponent<MeshRenderer>().material = afterMaterial;
    }
}