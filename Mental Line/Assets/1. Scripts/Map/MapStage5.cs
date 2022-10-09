using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapStage5 : MonoBehaviour
{
    //5스테이지 형식 : 어려운 평평 OR 물결 ? 어려운 위 OR 어려운 아래 ? 어려운 위 OR 어려운 아래 ? 어려운 위 OR 어려운 아래 ? 어려운 평평 OR 물결

    
    [SerializeField]
    GameObject Destination, DeadZone;

    // map1zone : 어려움 1 평평[0], 물결 평평[1]     map2zone : 쉬운 위[1] / 아래 [0]     map3zone : 어려운 위[1] / 아래[0]
    [SerializeField]
    GameObject[] map1zone, map2zone, map3zone;

    int r1, r2, r5;

    // y값 변수
    [HideInInspector]
    public float a1, a2, b1, b2, c;

    GameObject a, b, cc, d, e,f,g;
    public GameObject[] player;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
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
        // 1구간   어려운 평펑[0] / 물결[1]
        r1 = Random.Range(0, 2);
        switch (r1)
        {
            // 0 : 어려움  1 : 물결
            case 0:
                a=Instantiate(map1zone[0], new Vector3(0, 0, 0), Quaternion.identity);
                //a1 = -19f; //b1 = -55f;
                break;
            case 1:
                a=Instantiate(map1zone[1], new Vector3(0, 0, 0), Quaternion.identity);
                //a2 = 19f; //b2 = -16f;
                break;
        }

        // 2구간 
        r2 = Random.Range(0, 2);
        switch (r2)
        {
            // 0 : 다운  1 : 업
            case 0:
                b=Instantiate(map3zone[0], new Vector3(100, -35, 0), Quaternion.identity);
                a1 = -19f; //b1 = -55f;

                // 3구간
                cc=Instantiate(map3zone[1], new Vector3(160, -35, 0), Quaternion.identity);

                // 4구간
                d=Instantiate(map3zone[0], new Vector3(220, -35, 0), Quaternion.identity);
                r5 = Random.Range(0, 2);
                switch (r5) // 5구간 랜덤
                {
                    case 0:
                        e=Instantiate(map1zone[0], new Vector3(240, -19, 0), Quaternion.identity);
                        f=Instantiate(Destination, new Vector3(302, -30, 0), Quaternion.identity);
                        g=Instantiate(DeadZone, new Vector3(348, -36, 3.529f), Quaternion.identity);
                        break;
                    case 1:
                        e=Instantiate(map1zone[1], new Vector3(240, -19, 0), Quaternion.identity);
                        f = Instantiate(Destination, new Vector3(302, -28, 0), Quaternion.identity);
                        g = Instantiate(DeadZone, new Vector3(348, -36, 3.529f), Quaternion.identity);
                        break;
                }
                break;

            case 1:
                b=Instantiate(map3zone[1], new Vector3(100, -17, 0), Quaternion.identity);
                a2 = 19f; //b2 = -16f;

                // 3구간 
                cc=Instantiate(map3zone[0], new Vector3(160, -17, 0), Quaternion.identity);

                // 4구간 
                d=Instantiate(map3zone[1], new Vector3(220, -17, 0), Quaternion.identity);
                r5 = Random.Range(0, 2);
                switch (r5) // 5구간 랜덤
                {
                    case 0:
                        e=Instantiate(map1zone[0], new Vector3(240, 19, 0), Quaternion.identity);
                        f = Instantiate(Destination, new Vector3(302, 8, 0), Quaternion.identity);
                        g = Instantiate(DeadZone, new Vector3(348, 2, 3.529f), Quaternion.identity);
                        break;
                    case 1:
                       e= Instantiate(map1zone[1], new Vector3(240, 19, 0), Quaternion.identity);
                        f = Instantiate(Destination, new Vector3(302, 10, 0), Quaternion.identity);
                        g = Instantiate(DeadZone, new Vector3(348, 2, 3.529f), Quaternion.identity);
                        break;
                }
                

                break;
        }
    }
}
