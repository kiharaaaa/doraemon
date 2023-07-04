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

    public int start_x = -20,  start_y = -20;   // �ړ��O��x,y���W
    public int end_x = 0,    end_y = 0;         // �ړ����x,y���W
    public int start_sec = 0, display_sec = 10; // �X�^�[�g���牽�b��ɉ�ʂɓ��邩�A���b�ԉ�ʂɕ\�����邩
    int delta_x, delta_y;                       // �ړ��J�n�n�_�ƏI�����Ă��x,y���W�̍�

    void Start()
    {
        delta_x = end_x - start_x; delta_y = end_y - start_y;
        var delta = Player.transform.position - new Vector3(end_x, end_y, Player.transform.position.z + 15);
        var rotation = Quaternion.LookRotation(delta, Vector3.up);
        this.transform.rotation = rotation;
        HPText.GetComponent<TextMesh>().text = HP.ToString();
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
                transform.position = new Vector3(end_x, end_y + sin_y, Player.transform.position.z + 15);
            }
            else
            {
                transform.position = new Vector3(start_x + delta_x * rate, start_y + delta_y * rate, Player.transform.position.z + 15);
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
                transform.position = new Vector3(end_x - delta_x * rate, end_y - delta_y * rate, Player.transform.position.z + 15);
            }
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
            Instantiate(barrierPrefab, transform.position, Quaternion.identity);
            barrierCnt++;
        }
    }
}