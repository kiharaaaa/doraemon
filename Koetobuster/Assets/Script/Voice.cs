using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using NMeCab.Specialized;

public class Voice: MonoBehaviour
{
    public static int voiceFlag;
    public static string voiceText;

    Dictionary<char, char> c = new Dictionary<char, char>();

    DictationRecognizer dictationRecognizer;
    string tmp;

    void Start()
    {
        dictationRecognizer = new DictationRecognizer();

        dictationRecognizer.Start();
        Debug.Log("�����F���J�n");

        voiceFlag = 0;

        c.Add('�A', '��');c.Add('�C', '��');c.Add('�E', '��');c.Add('�G', '��');c.Add('�I', '��');
        c.Add('�J', '��');c.Add('�L', '��');c.Add('�N', '��');c.Add('�P', '��');c.Add('�R', '��');
        c.Add('�T', '��');c.Add('�V', '��');c.Add('�X', '��');c.Add('�Z', '��');c.Add('�\', '��');
        c.Add('�^', '��');c.Add('�`', '��');c.Add('�c', '��');c.Add('�e', '��');c.Add('�g', '��');
        c.Add('�i', '��');c.Add('�j', '��');c.Add('�k', '��');c.Add('�l', '��');c.Add('�m', '��');
        c.Add('�n', '��');c.Add('�q', '��');c.Add('�t', '��');c.Add('�w', '��');c.Add('�z', '��');
        c.Add('�}', '��');c.Add('�~', '��');c.Add('��', '��');c.Add('��', '��');c.Add('��', '��');
        c.Add('��', '��');c.Add('��', '��');c.Add('��', '��');
        c.Add('��', '��');c.Add('��', '��');c.Add('��', '��');c.Add('��', '��');c.Add('��', '��');
        c.Add('��', '��');c.Add('��', '��');c.Add('��', '��');
        c.Add('�K', '��');c.Add('�M', '��');c.Add('�O', '��');c.Add('�Q', '��');c.Add('�S', '��');
        c.Add('�U', '��');c.Add('�W', '��');c.Add('�Y', '��');c.Add('�[', '��');c.Add('�]', '��');
        c.Add('�_', '��');c.Add('�a', '��');c.Add('�d', '��');c.Add('�f', '��');c.Add('�h', '��');
        c.Add('�o', '��');c.Add('�r', '��');c.Add('�u', '��');c.Add('�x', '��');c.Add('�{', '��');
        c.Add('�p', '��');c.Add('�s', '��');c.Add('�v', '��');c.Add('�y', '��');c.Add('�|', '��');
        c.Add('�@', '��');c.Add('�B', '��');c.Add('�D', '��');c.Add('�F', '��');c.Add('�H', '��');
        c.Add('��', '��');c.Add('��', '��');c.Add('��', '��');
        c.Add('�b', '��');c.Add('��', '?');
        // c.Add('�[', '�[');
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
            Debug.Log("�F�����������F" + text);
            string str = "";
            for(int i=0; i<text.Length; i++)
            {
                if(text[i] >= '�@' && text[i] <= '��'){
                    str += c[text[i]];
                }else{
                    str += text[i];
                }
            }
            Debug.Log("�F�����������F" + str);
            text = KanjiToKatakana(str);
            Debug.Log("�F�����������F" + text);
            voiceFlag = 1;
            voiceText = text;
        }
    }
}