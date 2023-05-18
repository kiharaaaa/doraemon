using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using NMeCab.Specialized;


public class Voice: MonoBehaviour
{

    DictationRecognizer dictationRecognizer;
    string voiceText;

    void Start()
    {
        dictationRecognizer = new DictationRecognizer();

        dictationRecognizer.Start();
        Debug.Log("�����F���J�n");
    }

    void Update()
    {
        dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;         //�����F������������o��

        dictationRecognizer.DictationError += DictationRecognizer_DictationError;           //�����F���G���[
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
        if (voiceText != text)
        {
            voiceText = text;
            text = KanjiToKatakana(text);
            Debug.Log("�F�����������F" + text);
        }
    }

    private void DictationRecognizer_DictationError(string error, int hresult)
    {
        Debug.Log("�����F���G���[");
    }
    
}