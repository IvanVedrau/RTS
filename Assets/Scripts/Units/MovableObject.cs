using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

public abstract class MovableObject : RTSObject
{
    public LayerMask ground;
    protected Camera myCam;
    protected NavMeshAgent myAgent;

    protected override void Start()
    {
        base.Start();
        myCam = Camera.main;
        myAgent = GetComponent<NavMeshAgent>();
    }

    public void Move(Camera cam, NavMeshAgent agent)
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                agent.SetDestination(hit.point);
            }
        }

    }

    protected override void Update()
    {
        base.Update();
        if (IsSelected())
        {
            Move(myCam, myAgent);

        }
    }

}
