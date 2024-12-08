using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Villager : MovableObject
{
    public LayerMask resource;
    public LayerMask cc;
    private bool isGathering = false;
    private bool isReturning = false;
    private bool isBackpackEmpty = true;
    public GameObject baseBuild;
    private Vector3 resPoint;
    //public Animation gatheringAnimation;
    private float gatherTime = 2f;
    private float currentTime = 0f;
    protected override void Start()
    {
        base.Start();
        gameObject.tag = "Villager";


    }

    protected override void Update()
    {
        base.Update();
        if (this.IsSelected() && Input.GetMouseButtonDown(1)) MoveToTarget();
        if (Vector3.Distance(transform.position, resPoint) < 3.1f && isGathering)
        {
            Gathering();
            Debug.Log("Собрал");
        }
        if (Vector3.Distance(transform.position, baseBuild.GetComponent<Collider>().ClosestPoint(transform.position)) < 3.1f && isGathering)
        {
            Drop();
            myAgent.SetDestination(resPoint);
            myAgent.stoppingDistance = 3f;
        }

        if (Vector3.Distance(transform.position, baseBuild.GetComponent<Collider>().ClosestPoint(transform.position)) < 3.1f && !isBackpackEmpty && !isGathering) Drop();
    }
    public override void Move(Camera cam, NavMeshAgent agent)
    {
        base.Move(cam, agent);
        isGathering = false;
    }

    protected void MoveToTarget()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, resource))
            {
                Deselect();
                if (isBackpackEmpty)
                {
                    resPoint = hit.point;
                    myAgent.SetDestination(hit.point);
                    myAgent.stoppingDistance = 3f;
                    isGathering = true;
                }
                else
                {
                    myAgent.SetDestination(baseBuild.GetComponent<Collider>().ClosestPoint(transform.position));
                    myAgent.stoppingDistance = 3f;
                }
            }

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, cc))
            {
                myAgent.SetDestination(hit.point);
                myAgent.stoppingDistance = 3f;

            }
        }

    }

    public void Gathering()
    {
        //gatheringAnimation.Play();
        isBackpackEmpty = false;

        myAgent.SetDestination(baseBuild.GetComponent<Collider>().ClosestPoint(transform.position));
        myAgent.stoppingDistance = 3f;
    }

    public void Drop()
    {
        isBackpackEmpty = true;
        Debug.Log("Скинул");

    }

    public void Take()
    {
        //TODO
    }
}