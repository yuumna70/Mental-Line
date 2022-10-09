using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    [HideInInspector]
    public Player player;
    float Speed = 5f;
    const float distance = 1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        

        transform.LookAt(player.transform.position);

        // 플레이어와 tail의 거리가 distance보다 크다면 
        if((transform.position - player.transform.position).magnitude > distance)
        {
            transform.Translate(0.0f, 0.0f, Speed * Time.deltaTime);
        }
        
        
    }
}
