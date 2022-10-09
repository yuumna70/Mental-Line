using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapStage1 : MonoBehaviour
{
    // 1�������� ���� :           �⺻ ����         ? ���� �� OR ���� �Ʒ�        ?               �⺻ ����             ?     ���� �� OR ���� �Ʒ�    ?           �⺻ ����
    public GameObject A, B, C, D, E;

    // �⺻ ����
    [SerializeField]
    GameObject map1zone, Destination, DeadZone;

    // ���� �� �Ʒ� [0] : �Ʒ�  / [1] : ��
    [SerializeField]
    GameObject[] map2zone;
    GameObject a, b, cc, d, e,f,g;

    int r1, r2, r3;

    // y�� ����
    [HideInInspector]
    public float a1, a2, b1, b2, c;

    public GameObject[] player;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();/*//
        a.SetActive(true);
        b.SetActive(true);
        cc.SetActive(true);
        d.SetActive(true);
        e.SetActive(true);*/
        a.SetActive(false);
        b.SetActive(false);
        cc.SetActive(false);
        d.SetActive(false);
        e.SetActive(false);
        f.SetActive(false);
        g.SetActive(false);
    }

    private void Update()
    {
        for (int i = 0; i < player.Length; i++)
        {
            if ((PlayerPrefs.GetInt($"Fit{i}") == 1) && player[i].transform.position.x < 45 && player[i].transform.position.x >= -10)
            {
                a.SetActive(true);
                b.SetActive(false);
                cc.SetActive(false);
                d.SetActive(false);
                e.SetActive(false);
                f.SetActive(false);
            }
            else if ((PlayerPrefs.GetInt($"Fit{i}") == 1) && player[i].transform.position.x >= 45 && player[i].transform.position.x < 80)
            {
                a.SetActive(true);
                b.SetActive(true);
                cc.SetActive(false);
                d.SetActive(false);
                e.SetActive(false);
                f.SetActive(false);
            }
            else if ((PlayerPrefs.GetInt($"Fit{i}") == 1) && player[i].transform.position.x >= 80 && player[i].transform.position.x < 100)
            {
                a.SetActive(false);
                b.SetActive(true);
                cc.SetActive(false);
                d.SetActive(false);
                e.SetActive(false);
                f.SetActive(false);
            }
            else if ((PlayerPrefs.GetInt($"Fit{i}") == 1) && player[i].transform.position.x >= 100 && player[i].transform.position.x < 130)
            {
                a.SetActive(false);
                b.SetActive(true);
                cc.SetActive(true);
                d.SetActive(false);
                e.SetActive(false);
                f.SetActive(false);
            }
            else if ((PlayerPrefs.GetInt($"Fit{i}") == 1) && player[i].transform.position.x >= 130 && player[i].transform.position.x < 160)
            {
                a.SetActive(false);
                b.SetActive(false);
                cc.SetActive(true);
                d.SetActive(false);
                e.SetActive(false);
                f.SetActive(false);
            }
            else if ((PlayerPrefs.GetInt($"Fit{i}") == 1) && player[i].transform.position.x >= 160 && player[i].transform.position.x < 190)
            {
                a.SetActive(false);
                b.SetActive(false);
                cc.SetActive(true);
                d.SetActive(true);
                e.SetActive(false);
                f.SetActive(false);
            }
            else if ((PlayerPrefs.GetInt($"Fit{i}") == 1) && player[i].transform.position.x >= 190 && player[i].transform.position.x < 220)
            {
                a.SetActive(false);
                b.SetActive(false);
                cc.SetActive(false);
                d.SetActive(true);
                e.SetActive(false);
                f.SetActive(false);
            }
            else if ((PlayerPrefs.GetInt($"Fit{i}") == 1) && player[i].transform.position.x >= 220 && player[i].transform.position.x < 250)
            {
                a.SetActive(false);
                b.SetActive(false);
                cc.SetActive(false);
                d.SetActive(true);
                e.SetActive(true);
                f.SetActive(false);
            }
            else if ((PlayerPrefs.GetInt($"Fit{i}") == 1) && player[i].transform.position.x >= 250 && player[i].transform.position.x < 320)
            {
                a.SetActive(false);
                b.SetActive(false);
                cc.SetActive(false);
                d.SetActive(false);
                e.SetActive(true);
                f.SetActive(true);
            }
        }
    }

    void Spawn()
    {
        // 1����
        a = Instantiate(map1zone, new Vector3(0, 0, 0), Quaternion.identity);

        // 2���� : ���� �� / �Ʒ�
        r1 = Random.Range(0, 2);
        switch (r1)
        {
            // 0 : �ٿ�  1 : ��
            case 0:
                b=Instantiate(map2zone[0], new Vector3(100, -35, 0), Quaternion.identity);
                a1 = -19f; //b1 = -55f;
                break;
            case 1:
                b=Instantiate(map2zone[1], new Vector3(100, -17, 0), Quaternion.identity);
                a2 = 19f; //b2 = -16f;
                break;
        }

        // 3���� : �⺻ ����
        if (r1 == 0)
        {
            switch (r2)
            {
                case 0:
                    cc=Instantiate(map1zone, new Vector3(120, a1, 0), Quaternion.identity);
                    break;
                
            }
        }
        else if (r1 == 1)
        {
            b2 = -16f;
            switch (r2)
            {
                case 0:
                    cc=Instantiate(map1zone, new Vector3(120, a2, 0), Quaternion.identity);
                    break;
                
            }
        }

        // 4���� : ���� �� / �Ʒ�
        r3 = Random.Range(0, 2);
        if (r1 == 0)
        {
            // b1 = -33f;
            switch (r3)
            {
                case 0:
                    d=Instantiate(map2zone[0], new Vector3(220, -55, 0), Quaternion.identity);
                    break;
                case 1:
                    d=Instantiate(map2zone[1], new Vector3(220, -35, 0), Quaternion.identity);
                    break;
            }
        }
        else if(r1 == 1)
        {
            b2 = -16f;
            switch(r3)
            {
                case 0:
                    d=Instantiate(map2zone[0], new Vector3(220, b2, 0), Quaternion.identity);
                    break;
                case 1:
                    d=Instantiate(map2zone[1], new Vector3(220, 2, 0), Quaternion.identity);
                    break;
            }
            
        }

        // 5���� : �⺻ ����
        if (r1 == 0 && r3 == 0)
        {
            e=Instantiate(map1zone, new Vector3(240, -39, 0), Quaternion.identity);
            f=Instantiate(Destination, new Vector3(302, -49, 0), Quaternion.identity);
            g=Instantiate(DeadZone, new Vector3(348, -55, 3.529f), Quaternion.identity);
        }
        else if (r1 == 0 && r3 == 1)
        {
            e=Instantiate(map1zone, new Vector3(240, 0, 0), Quaternion.identity);
            f=Instantiate(Destination, new Vector3(302, -9, 0), Quaternion.identity);
            g=Instantiate(DeadZone, new Vector3(348, -17, 3.529f), Quaternion.identity);
        }
        else if (r1 == 1 && r3 == 0)
        {
            e=Instantiate(map1zone, new Vector3(240, 0, 0), Quaternion.identity);
            f=Instantiate(Destination, new Vector3(302, -9, 0), Quaternion.identity);
            g=Instantiate(DeadZone, new Vector3(348, -17, 3.529f), Quaternion.identity);
        }
        else if (r1 == 1 && r3 == 1)
        {
            e=Instantiate(map1zone, new Vector3(240, 37.5f, 0), Quaternion.identity);
            f=Instantiate(Destination, new Vector3(302, 27, 0), Quaternion.identity);
            g=Instantiate(DeadZone, new Vector3(348, 21, 3.529f), Quaternion.identity);
        }


    }
}
