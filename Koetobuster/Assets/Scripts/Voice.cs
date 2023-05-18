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
        Debug.Log("音声認識開始");
    }

    void Update()
    {
        dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;         //音声認識完了したら出力

        dictationRecognizer.DictationError += DictationRecognizer_DictationError;           //音声認識エラー
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
        if (voiceText != text)
        {
            voiceText = text;
            text = KanjiToKatakana(text);
            Debug.Log("認識した音声：" + text);
        }
    }

    private void DictationRecognizer_DictationError(string error, int hresult)
    {
        Debug.Log("音声認識エラー");
    }
    
}