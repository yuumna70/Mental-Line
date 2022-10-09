using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    private GameObject player;
    public Hook hook;
    private SpringJoint joint;
    public float speed;
    private LineRenderer lr;
    private Vector3 grapplePoint;
    private Vector3 currentGrapplePoint;
    private Vector3 dir;
    public LayerMask WhatIsGrappleable;
    private float maxDistance = 100f;

    [HideInInspector]
    public bool isPlay;


    // »ç¿îµå
    public AudioSource gr;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        hook.Grapple += Grapple;
        dir = transform.right + 2f * transform.up;
    }

    // Update is called once per frame
    private void Update()
    {
        if(isPlay == true)
        {
            transform.position = player.transform.position;
            if (Input.GetMouseButtonDown(0))
            {
                if (Time.timeScale == 1)
                {
                    gr.Play();

                }
                StartGrapple();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                StopGrapple();
            }
        }
        
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    void StartGrapple()
    {

        lr.enabled = true;
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, dir, out hit, maxDistance, WhatIsGrappleable))
        {
            hook.gameObject.SetActive(true);
            grapplePoint = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y - (hit.collider.transform.lossyScale.y / 2f));
            lr.positionCount = 2;
            currentGrapplePoint = transform.position;
        }
        else
        {
            hook.gameObject.SetActive(false);
        }
    }

    void DrawRope()
    {
        if (lr.positionCount == 0) return;

        currentGrapplePoint = Vector3.MoveTowards(currentGrapplePoint, grapplePoint, Time.deltaTime * speed);

        lr.SetPosition(0, transform.position+new Vector3(0,0.3f));
        lr.SetPosition(1, currentGrapplePoint);
    }

    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
    public Vector3 GetHookPoint()
    {
        return currentGrapplePoint;
    }

    void Grapple()
    {
        joint = player.gameObject.AddComponent<SpringJoint>();
        
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = grapplePoint;

        float distanceFromPoint = Vector3.Distance(player.transform.position, grapplePoint);
        
        joint.maxDistance = distanceFromPoint;
        joint.minDistance = 0f;
        joint.spring = 5f;
        joint.damper = 10f;
        joint.massScale = 100f;
    }
}