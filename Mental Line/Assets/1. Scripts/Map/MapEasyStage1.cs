using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEasyStage1 : MonoBehaviour
{
    // √÷¿˚»≠ ∏ 
    public GameObject[] Item;

    int FlagCheck;
    bool PoolCheck0, PoolCheck1, PoolCheck2, PoolCheck3, PoolCheck4, PoolCheck5;

    GameObject Map1;
    GameObject Map2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FlagCheck == 0 && PoolCheck0 == false)
        {
            Map1 = ObjectPool.instance.objectPoolList[0].Dequeue();
            Pull(Map1, new Vector3(0, 0));
            PoolCheck0 = true;
        }
        else if (FlagCheck == 1 && PoolCheck1 == false)
        {
            Item[1].SetActive(true);
            Map2 = ObjectPool.instance.objectPoolList[0].Dequeue();
            Pull(Map2, new Vector3(60, 0));
            PoolCheck1 = true;
        }
        else if (FlagCheck == 2 && PoolCheck2 == false)
        {
            Put(0, Map1);
            Map1 = ObjectPool.instance.objectPoolList[0].Dequeue();
            Pull(Map1, new Vector3(120, 0));
            PoolCheck2 = true;
            Item[0].SetActive(false);
            Item[2].SetActive(true);
        }
        else if (FlagCheck == 3 && PoolCheck3 == false)
        {
            Put(0, Map2);
            Map2 = ObjectPool.instance.objectPoolList[0].Dequeue();
            Pull(Map2, new Vector3(180, 0));
            PoolCheck3 = true;
            Item[1].SetActive(false);
            Item[3].SetActive(true);
        }
        else if (FlagCheck == 4 && PoolCheck4 == false)
        {
            Put(0, Map1);
            Map1 = ObjectPool.instance.objectPoolList[0].Dequeue();
            Pull(Map1, new Vector3(240, 0));
            PoolCheck4 = true;
            Item[2].SetActive(false);
            Item[4].SetActive(true);
        }
        else if (FlagCheck == 5 && PoolCheck5 == false)
        {
            Put(0, Map2);
            PoolCheck5 = true;
            Item[3].SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flag"))
        {
            FlagCheck += 1;
        }
    }

    void Pull(GameObject map,Vector3 position)
    {
        map.transform.position = position;
        map.SetActive(true);
    }

    void Put(int index,GameObject map)
    {
        ObjectPool.instance.objectPoolList[index].Enqueue(map);
        map.SetActive(false);
    }

}
