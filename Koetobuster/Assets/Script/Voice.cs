using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using NMeCab.Specialized;
using System.Text;

public class Voice: MonoBehaviour
{
    public static int voiceFlag = -1;
    public static string voiceText;

    Dictionary<char, char> c = new Dictionary<char, char>();

    DictationRecognizer dictationRecognizer;
    string tmp;

    void Start()
    {
        dictationRecognizer = new DictationRecognizer();

        dictationRecognizer.Start();
        Debug.Log("音声認識開始");

        voiceFlag = 0;

        c.Add('ア', 'あ');c.Add('イ', 'い');c.Add('ウ', 'う');c.Add('エ', 'え');c.Add('オ', 'お');
        c.Add('カ', 'か');c.Add('キ', 'き');c.Add('ク', 'く');c.Add('ケ', 'け');c.Add('コ', 'こ');
        c.Add('サ', 'さ');c.Add('シ', 'し');c.Add('ス', 'す');c.Add('セ', 'せ');c.Add('ソ', 'そ');
        c.Add('タ', 'た');c.Add('チ', 'ち');c.Add('ツ', 'つ');c.Add('テ', 'て');c.Add('ト', 'と');
        c.Add('ナ', 'な');c.Add('ニ', 'に');c.Add('ヌ', 'ぬ');c.Add('ネ', 'ね');c.Add('ノ', 'の');
        c.Add('ハ', 'は');c.Add('ヒ', 'ひ');c.Add('フ', 'ふ');c.Add('ヘ', 'へ');c.Add('ホ', 'ほ');
        c.Add('マ', 'ま');c.Add('ミ', 'み');c.Add('ム', 'む');c.Add('メ', 'め');c.Add('モ', 'も');
        c.Add('ヤ', 'や');c.Add('ユ', 'ゆ');c.Add('ヨ', 'よ');
        c.Add('ラ', 'ら');c.Add('リ', 'り');c.Add('ル', 'る');c.Add('レ', 'れ');c.Add('ロ', 'ろ');
        c.Add('ワ', 'わ');c.Add('ヲ', 'を');c.Add('ン', 'ん');
        c.Add('ガ', 'が');c.Add('ギ', 'ぎ');c.Add('グ', 'ぐ');c.Add('ゲ', 'げ');c.Add('ゴ', 'ご');
        c.Add('ザ', 'ざ');c.Add('ジ', 'じ');c.Add('ズ', 'ず');c.Add('ゼ', 'ぜ');c.Add('ゾ', 'ぞ');
        c.Add('ダ', 'だ');c.Add('ヂ', 'ぢ');c.Add('ヅ', 'づ');c.Add('デ', 'で');c.Add('ド', 'ど');
        c.Add('バ', 'ば');c.Add('ビ', 'び');c.Add('ブ', 'ぶ');c.Add('ベ', 'べ');c.Add('ボ', 'ぼ');
        c.Add('パ', 'ぱ');c.Add('ピ', 'ぴ');c.Add('プ', 'ぷ');c.Add('ペ', 'ぺ');c.Add('ポ', 'ぽ');
        c.Add('ァ', 'ぉ');c.Add('ィ', 'ぇ');c.Add('ゥ', 'ぅ');c.Add('ェ', 'ぇ');c.Add('ォ', 'ぉ');
        c.Add('ャ', 'ゃ');c.Add('ュ', 'ゅ');c.Add('ョ', 'ょ');
        c.Add('ッ', 'っ');c.Add('ヴ', 'ゔ');c.Add('ー', 'ー');
    }

    string status = "";
    void Update()
    {
        // status が前回と違ったら
        if (status != dictationRecognizer.Status.ToString())
        {
            Debug.Log(dictationRecognizer.Status);
            status = dictationRecognizer.Status.ToString();

            if(status == "Stopped")
            {
                dictationRecognizer.Start();
            }
        }

        // 喋ったとき
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

    string KatakanaToHiragana(string text) // カタカナをひらがなに変換
    {
        StringBuilder builder = new StringBuilder();
        char beginHiragana = 'ぁ';
        // char endHiragana = 'ゖ';
        char beginKatakana = 'ァ';
        char endKatakana = 'ヶ';
        int offset = beginKatakana - beginHiragana;

        foreach (var c in text)
        {
            builder.Append(
                beginKatakana <= c && c <= endKatakana ?
                    (char)(c - offset) :
                    c
            );
        }
        return builder.ToString();
    }

    void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        if (tmp != text)
        {
            tmp = text;
            text = KatakanaToHiragana(text);
            text = KanjiToKatakana(text);
            Debug.Log("認識した音声：" + text);
            if(text.Length != 1)
            {
                voiceFlag = 1;
                voiceText = text;
            }
        }
    }
}