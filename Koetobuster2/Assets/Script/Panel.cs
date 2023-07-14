using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class Panel : MonoBehaviour
{
    string s = "アイウエオ" +
        "カキクケコ" +
        "サシスセソ" +
        "タチツテト" +
        "ナニヌネノ" +
        "ハヒフヘホ" +
        "マミムメモ" +
        "ヤユヨ" +
        "ラリルレロ" +
        "ワ";

    char[] tmp = new char[44];
    char[] list = new char[44];

    public Text panelText;
    public static bool panelFlag;
    public static char panelCh;
    int cnt;


    void Start()
    {
        cnt = 0;
        panelFlag = false;

        for (int i = 0; i < 44; i++)
        {
            tmp[i] = s[i];
        }
        list = tmp.Shuffle().ToArray();

        panelText.text = "" + list[cnt];
        panelCh = list[cnt];
    }

    void Update()
    {
        if (panelFlag)
        {
            panelFlag = false;
            cnt++;
            Invoke("changePanel", 0.7f);
        }
    }

    void changePanel()
    {
        panelText.text = "" + list[cnt];
        panelCh = list[cnt];
    }
}

public static class IEnumerableExtension
{
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> collection)
    {
        return collection.OrderBy(i => Guid.NewGuid());
    }
}
