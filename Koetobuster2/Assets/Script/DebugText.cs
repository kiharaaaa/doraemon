using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour
{
    Vector3 pos;
    Text text;

    void Start()
    {
        pos = gameObject.GetComponent<RectTransform>().position;
        text = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        //     if(Input.GetKeyDown(KeyCode.DownArrow)){
        //         var tmp = pos;
        //         tmp.y -= 10f;
        //         pos = tmp;
        //     }
        //     if(Input.GetKeyDown(KeyCode.UpArrow)){
        //         var tmp = pos;
        //         tmp.y += 10f;
        //         pos = tmp;
        //     }
        //     if(Input.GetKeyDown(KeyCode.LeftArrow)){
        //         var tmp = pos;
        //         tmp.x -= 10f;
        //         pos = tmp;
        //     }
        //     if(Input.GetKeyDown(KeyCode.RightArrow)){
        //         var tmp = pos;
        //         tmp.x += 10f;
        //         pos = tmp;
        //     }
        //     text.text = pos.x.ToString() + ", " + pos.y.ToString();
    }
}
