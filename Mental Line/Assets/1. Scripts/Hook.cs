using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private Grappling grappling;
    public Action Grapple;
    // Start is called before the first frame update
    void Start()
    {
        grappling = GameObject.FindWithTag("Hook").GetComponent<Grappling>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.position = grappling.GetHookPoint();
        }
        else
        {
            transform.position = grappling.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer==3)
        {
            Grapple();
        }
    }
}
