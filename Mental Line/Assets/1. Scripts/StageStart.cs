using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageStart : MonoBehaviour
{
    private Transform playerTransform;

    public bool savePoint1=false;
    public bool savePoint2=false;
    public Grappling gp;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        transform.position = new Vector3(playerTransform.position.x,playerTransform.position.y-1f);
    }

    // Update is called once per frame
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gp.isPlay == true)
        {
            if(Time.timeScale >= 1)
            {
                gameObject.SetActive(false);
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "SavePoint1")
        {
            savePoint1 = true;
        }
        else if (other.name == "SavePoint2")
        {
            savePoint2 = true;
        }
    }
}
