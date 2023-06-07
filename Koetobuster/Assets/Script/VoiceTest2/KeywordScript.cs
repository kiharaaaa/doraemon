using System;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class KeywordScript : MonoBehaviour
{
    [SerializeField]
    private string[] m_Keywords;
    [SerializeField]
    private KeywordRecognizer m_Recognizer;

    void Start()
    {
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;//�F�����ꂽ�������n���������\�b�h��ǉ�����B
        m_Recognizer.Start();
    }

    //�F�����ꂽ�P����R���\�[���ɕ\�����郁�\�b�h
    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log(args.text);
    }
}
