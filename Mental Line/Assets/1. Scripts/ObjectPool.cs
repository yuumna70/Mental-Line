using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectInfo
{
    public string objectName;
    public GameObject prefab;
    public int count;
}

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [SerializeField]
    ObjectInfo[] objectInfos = null;

    [Header("오브젝트 풀의 위치")]
    [SerializeField]
    Transform tfPoolParent;

    public List<Queue<GameObject>> objectPoolList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        objectPoolList = new List<Queue<GameObject>>();
        ObjectPoolState();
    }

    void ObjectPoolState()
    {
        if (objectInfos != null)
        {
            for(int i=0; i<objectInfos.Length; i++)
            {
                objectPoolList.Add(InsertQueue(objectInfos[i]));
            }
        }
    }

    Queue<GameObject> InsertQueue(ObjectInfo prefab_objectionInfo)
    {
        Queue<GameObject> test_queue = new Queue<GameObject>();

        for(int i=0; i<prefab_objectionInfo.count; i++)
        {
            GameObject objectClone = Instantiate(prefab_objectionInfo.prefab) as GameObject;
            objectClone.SetActive(false);
            objectClone.transform.SetParent(tfPoolParent);
            test_queue.Enqueue(objectClone);
        }

        return test_queue;
    }

}