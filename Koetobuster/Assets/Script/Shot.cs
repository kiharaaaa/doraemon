using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shot : MonoBehaviour
{
    public float thrust;
    public GameObject Player;
    public float shotInterval;
    public static string lastMojiTag = "LastMoji";

    public GameObject A;  // あ
    public GameObject I;  // い
    public GameObject U;  // う
    public GameObject E;  // え
    public GameObject O;  // お

    public GameObject KA; // か
    public GameObject KI; // き
    public GameObject KU; // く
    public GameObject KE; // け
    public GameObject KO; // こ

    public GameObject SA; // さ
    public GameObject SI; // し
    public GameObject SU; // す
    public GameObject SE; // せ
    public GameObject SO; // そ

    public GameObject TA; // た
    public GameObject TI; // ち
    public GameObject TU; // つ
    public GameObject TE; // て
    public GameObject TO; // と

    public GameObject NA; // な
    public GameObject NI; // に
    public GameObject NU; // ぬ
    public GameObject NE; // ね
    public GameObject NO; // の

    public GameObject HA; // は
    public GameObject HI; // ひ
    public GameObject HU; // ふ
    public GameObject HE; // へ
    public GameObject HO; // ほ

    public GameObject MA; // ま
    public GameObject MI; // み
    public GameObject MU; // む
    public GameObject ME; // め
    public GameObject MO; // も

    public GameObject YA; // や
    public GameObject YU; // ゆ
    public GameObject YO; // よ

    public GameObject RA; // ら
    public GameObject RI; // り
    public GameObject RU; // る
    public GameObject RE; // れ
    public GameObject RO; // ろ

    public GameObject WA; // わ
    public GameObject WO; // を
    public GameObject NN; // ん

    public GameObject GA; // が
    public GameObject GI; // ぎ
    public GameObject GU; // ぐ
    public GameObject GE; // げ
    public GameObject GO; // ご

    public GameObject ZA; // ざ
    public GameObject ZI; // じ
    public GameObject ZU; // ず
    public GameObject ZE; // ぜ
    public GameObject ZO; // ぞ

    public GameObject DA; // だ
    public GameObject DI; // ぢ
    public GameObject DU; // づ
    public GameObject DE; // で
    public GameObject DO; // ど

    public GameObject BA; // ば
    public GameObject BI; // び
    public GameObject BU; // ぶ
    public GameObject BE; // べ
    public GameObject BO; // ぼ

    public GameObject PA; // ぱ
    public GameObject PI; // ぴ
    public GameObject PU; // ぷ
    public GameObject PE; // ぺ
    public GameObject PO; // ぽ

    public GameObject LA; // ぁ
    public GameObject LI; // ぃ
    public GameObject LU; // ぅ
    public GameObject LE; // ぇ
    public GameObject LO; // ぉ

    public GameObject LYA; // ゃ
    public GameObject LYU; // ゅ
    public GameObject LYO; // ょ
    public GameObject LTU; // っ

    public GameObject VU; // ゔ
    public GameObject haihun; // ー

    Rigidbody rb;

    Dictionary<char, GameObject> myTable = new Dictionary<char, GameObject>();

    void Start()
    {
        myTable.Add('ア', A);
        myTable.Add('イ', I);
        myTable.Add('ウ', U);
        myTable.Add('エ', E);
        myTable.Add('オ', O);

        myTable.Add('カ', KA);
        myTable.Add('キ', KI);
        myTable.Add('ク', KU);
        myTable.Add('ケ', KE);
        myTable.Add('コ', KO);

        myTable.Add('サ', SA);
        myTable.Add('シ', SI);
        myTable.Add('ス', SU);
        myTable.Add('セ', SE);
        myTable.Add('ソ', SO);

        myTable.Add('タ', TA);
        myTable.Add('チ', TI);
        myTable.Add('ツ', TU);
        myTable.Add('テ', TE);
        myTable.Add('ト', TO);

        myTable.Add('ナ', NA);
        myTable.Add('ニ', NI);
        myTable.Add('ヌ', NU);
        myTable.Add('ネ', NE);
        myTable.Add('ノ', NO);

        myTable.Add('ハ', HA);
        myTable.Add('ヒ', HI);
        myTable.Add('フ', HU);
        myTable.Add('ヘ', HE);
        myTable.Add('ホ', HO);

        myTable.Add('マ', MA);
        myTable.Add('ミ', MI);
        myTable.Add('ム', MU);
        myTable.Add('メ', ME);
        myTable.Add('モ', MO);

        myTable.Add('ヤ', YA);
        myTable.Add('ユ', YU);
        myTable.Add('ヨ', YO);

        myTable.Add('ラ', RA);
        myTable.Add('リ', RI);
        myTable.Add('ル', RU);
        myTable.Add('レ', RE);
        myTable.Add('ロ', RO);

        myTable.Add('ワ', WA);
        myTable.Add('ヲ', WO);
        myTable.Add('ン', NN);

        myTable.Add('ガ', GA);
        myTable.Add('ギ', GI);
        myTable.Add('グ', GU);
        myTable.Add('ゲ', GE);
        myTable.Add('ゴ', GO);

        myTable.Add('ザ', ZA);
        myTable.Add('ジ', ZI);
        myTable.Add('ズ', ZU);
        myTable.Add('ゼ', ZE);
        myTable.Add('ゾ', ZO);

        myTable.Add('ダ', DA);
        myTable.Add('ヂ', DI);
        myTable.Add('ヅ', DU);
        myTable.Add('デ', DE);
        myTable.Add('ド', DO);

        myTable.Add('バ', BA);
        myTable.Add('ビ', BI);
        myTable.Add('ブ', BU);
        myTable.Add('ベ', BE);
        myTable.Add('ボ', BO);

        myTable.Add('パ', PA);
        myTable.Add('ピ', PI);
        myTable.Add('プ', PU);
        myTable.Add('ペ', PE);
        myTable.Add('ポ', PO);

        myTable.Add('ァ', LA);
        myTable.Add('ィ', LI);
        myTable.Add('ゥ', LU);
        myTable.Add('ェ', LE);
        myTable.Add('ォ', LO);

        myTable.Add('ャ', LYA);
        myTable.Add('ュ', LYU);
        myTable.Add('ョ', LYO);
        myTable.Add('ッ', LTU);

        myTable.Add('ヴ', VU);
        myTable.Add('ー', haihun);
}

    float time;
    int cnt;
    int n;
    int flag = 0;
    void Update()
    {
        if(Voice.voiceFlag == 1)
        //if (Input.GetMouseButtonDown(0))
        {
            Voice.voiceFlag = 2;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Vector3 playerPosition = Player.transform.position;
            Vector3 enemyPosition;

            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Enemy"))
            {
                enemyPosition = hit.collider.gameObject.transform.position;
            }
            else
            {
                enemyPosition = Input.mousePosition;
                enemyPosition.z = 15f;
                enemyPosition = Camera.main.ScreenToWorldPoint(enemyPosition);
            }
            float px = playerPosition.x;
            float py = playerPosition.y;
            float pz = playerPosition.z;

            float ex = enemyPosition.x;
            float ey = enemyPosition.y;
            float ez = enemyPosition.z;

            Vector3 angle_y_from = Vector3.forward;
            Vector3 angle_y_to = new Vector3(ex - px, 0f, ez - pz);
            float angle_y = Vector3.SignedAngle(angle_y_from, angle_y_to, Vector3.up);

            Vector3 angle_x_from = new Vector3(ex - px, 0f, ez - pz);
            Vector3 angle_x_to = new Vector3(ex - px, ey - py, ez - pz);
            Vector3 angle_x_vertical = new Vector3((float)Math.Cos(-angle_y * (Math.PI / 180)), 0f, (float)Math.Sin(-angle_y * (Math.PI / 180)));
            float angle_x = Vector3.SignedAngle(angle_x_from, angle_x_to, angle_x_vertical);

            transform.rotation = Quaternion.Euler(angle_x, angle_y, 0f);

            flag = 1;
            time = 0;
            cnt = 0;
            n = Voice.voiceText.Length;
        }

        if (flag == 1)
        {
            time += Time.deltaTime;

            if (time > shotInterval)
            {
                Vector3 playerPosition = Player.transform.position;
                GameObject c = Instantiate(myTable[Voice.voiceText[cnt]], playerPosition, Quaternion.identity);
                rb = c.AddComponent<Rigidbody>();
                rb.useGravity = false;
                rb.AddForce(transform.forward * thrust);

                time = 0;
                cnt++;
                if (cnt == n)
                {
                    flag = 0;
                    c.tag = lastMojiTag;
                    Voice.voiceFlag = 0;
                    Voice.voiceText = "";
                }
            }
        }
    }
}