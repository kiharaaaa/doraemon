using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using NMeCab.Specialized;

public class Voice: MonoBehaviour
{
    public static int voiceFlag;
    public static string voiceText;

    DictationRecognizer dictationRecognizer;
    string tmp;

    void Start()
    {
        dictationRecognizer = new DictationRecognizer();

        dictationRecognizer.Start();
        Debug.Log("�����F���J�n");

        voiceFlag = 0;
    }

    string tt = "";
    void Update()
    {        
        if (tt != dictationRecognizer.Status.ToString())
        {
            Debug.Log(dictationRecognizer.Status);
            tt = dictationRecognizer.Status.ToString();
        }
            if (voiceFlag == 0)
        {
            dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;         //�����F������������o��
        }
    }

    string KanjiToKatakana(string sentence)  // �������J�^�J�i�ɕϊ�
    {
        // �udic/ipadic�t�H���_�v�̃p�X���w�肷��
        var dicDir = @"Assets/dic/ipadic";

        string ans = "";

        using (var tagger = MeCabIpaDicTagger.Create(dicDir))
        {
            var nodes = tagger.Parse(sentence);

            foreach (var item in nodes)
                ans += item.Reading;
        }

        return ans;

    }

    private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        if (tmp != text)
        {
            tmp = text;
            text = KanjiToKatakana(text);
            Debug.Log("�F�����������F" + text);
            voiceFlag = 1;
            voiceText = text;
        }
    }
}