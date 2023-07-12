using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    public int HP = 3;
    bool flag = false;
    public static bool attack = false;

    public Material afterMaterial;
    public GameObject barrierPrefab;
    public static int barrierCnt = 0;
    public GameObject HPText;
    public int idx = 0;  // ���と�E�と�������E���̏��� 0�`8

    int[] start_x = { -60, -20,  20,  60, -60, -20,  20,  60 };
    int[] start_y = {  60,  40,  40,  60, -60, -40, -40, -60 };
    float[] end_x   = { -25f, -8f, 8f, 25f, -25f, -8f, 8f, 25f };
    float[] end_y   = { 10f, 9.8f, 9.8f, 10f, -10f, -9.8f, -9.8f, -10f };
    public int start_sec = 0, display_sec = 10; // �X�^�[�g���牽�b��ɉ�ʂɓ��邩�A���b�ԉ�ʂɕ\�����邩
    float delta_x, delta_y;                       // �ړ��J�n�n�_�ƏI�����Ă��x,y���W�̍�

    public static bool attackSound;
    public static bool barrierSound;
    GameObject b;

    void Start()
    {
        delta_x = end_x[idx] - start_x[idx]; delta_y = end_y[idx] - start_y[idx];
        var delta = Player.transform.position - new Vector3(end_x[idx], end_y[idx], Player.transform.position.z + 15);
        var rotation = Quaternion.LookRotation(delta, Vector3.up);
        this.transform.rotation = rotation;
        HPText.GetComponent<TextMesh>().text = HP.ToString();
        barrierSound = false;
    }

    void Update()
    {
        float t = Time.time;
        if (t > start_sec)
        {
            var diff = t - start_sec;
            var rate = diff / 3f;
            if(rate > 1f)
            {
                float sin_y = Mathf.Sin(t) * 0.5f;
                transform.position = new Vector3(end_x[idx], end_y[idx] + sin_y, Player.transform.position.z + 15);
            }
            else
            {
                transform.position = new Vector3(start_x[idx] + delta_x * rate, start_y[idx] + delta_y * rate, Player.transform.position.z + 15);
            }
            
        }
        if(t > start_sec + display_sec)
        {
            var diff = t - (start_sec + display_sec);
            var rate = diff / 3f;
            if (rate > 1f)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position = new Vector3(end_x[idx] - delta_x * rate, end_y[idx] - delta_y * rate, Player.transform.position.z + 15);
            }
        }

        if (b)
        {
            b.transform.position = transform.position;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == HP.ToString())
        {
            flag = true;
            attack = true;
            GetComponent<MeshRenderer>().material = afterMaterial;
        }
        else if (!(flag) && barrierCnt == 0)
        {
            b = Instantiate(barrierPrefab, transform.position, Quaternion.identity) as GameObject;
            barrierCnt++;
        }

        if (attack)
        {
            attackSound = true;
        }
        else
        {
            barrierSound = true;
        }

    }
}