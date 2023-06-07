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
        Debug.Log("音声認識開始");

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
            dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;         //音声認識完了したら出力
        }
    }

    string KanjiToKatakana(string sentence)  // 漢字をカタカナに変換
    {
        // 「dic/ipadicフォルダ」のパスを指定する
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
            Debug.Log("認識した音声：" + text);
            voiceFlag = 1;
            voiceText = text;
        }
    }
}