using System;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class KeywordTest : MonoBehaviour
{

    private KeywordController keyCon;
    private string[][] keywords;

    // Use this for initialization
    void Start()
    {
        keywords = new string[2][];
        keywords[0] = new string[] { "���", "�A�b�v��" };//�Ђ炪�Ȃł��J�^�J�i�ł�����
        keywords[1] = new string[] { "�݂���", "�I�����W" };

        keyCon = new KeywordController(keywords, true);//keywordController�̃C���X�^���X���쐬
        keyCon.SetKeywords();//KeywordRecognizer��keywords��ݒ肷��
        keyCon.StartRecognizing(0);//�V�[�����ŉ����F�����n�߂����Ƃ��ɌĂяo��
        keyCon.StartRecognizing(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (keyCon.hasRecognized[0])//�ݒ肵��Keywords[0]�̒P��炪�F�����ꂽ��true�ɂȂ�
        {
            Debug.Log("keyword[0] was recognized");
            keyCon.hasRecognized[0] = false;
        }
        if (keyCon.hasRecognized[1])
        {
            Debug.Log("keyword[1] was recognized");
            keyCon.hasRecognized[1] = false;
        }
    }
}

