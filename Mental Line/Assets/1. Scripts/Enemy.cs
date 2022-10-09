using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rig;

    float distance;

    [HideInInspector]
    public Player player;
    

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(rig.position,player.transform.position);
        
        

        if(gameObject.CompareTag("Move"))
        {
            if (distance < 10)
            {
                rig.velocity = new Vector3(-4, rig.velocity.y, 0);
            }
            
        }
        else if(gameObject.CompareTag("MoveUp"))
        {
            if (distance < 10)
            {
                rig.velocity = new Vector3(-4, -1f, 0);
            }
            
        }
        else if(gameObject.CompareTag("MoveDown"))
        {
            if (distance < 10)
            {
                rig.velocity = new Vector3(-4, 1.75f, 0);
            }
           
        }
        else if(gameObject.CompareTag("MoveDownStage3"))
        {
            if(distance < 10)
            {
                rig.velocity = new Vector3(-4, 2, 0);
            }
           
        }
        else if(gameObject.CompareTag("MoveUpStage3"))
        {
            if(distance < 10)
            {
                rig.velocity = new Vector3(-4, -1f, 0);
            }
            
        }
        else if(gameObject.CompareTag("MoveStage5"))
        {
            
            if (distance < 10)
            {
                rig.velocity = new Vector3(-6f, 0, 0);
            }
        }
    }

}
