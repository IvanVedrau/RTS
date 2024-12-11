using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Villager : MovableObject
{
    public LayerMask resource; 
    public LayerMask cc; 
    public GameObject baseBuild; 
    public List<GameResources> resources;
    public GameObject floatingTextPrefab;
    public ResourceUIManager resourceUIManager;

    private bool isGathering = false; 
    private bool isReturning = false; 
    private bool isBackpackEmpty = true; 
    private Vector3 resPoint; 
    private GameResources currentResource; 

    private float gatherTime = 5f;
    private float currentTime = 0f;

    protected override void Start()
    {
        base.Start();
        gameObject.tag = "Villager";
    }

    protected override void Update()
    {
        base.Update();

 
        if (this.IsSelected() && Input.GetMouseButtonDown(1))
            MoveToTarget();

   
        if (Vector3.Distance(transform.position, resPoint) < 3.1f && isGathering)
        {
            Gathering();
        }

  
        if (!isBackpackEmpty &&
            Vector3.Distance(transform.position, baseBuild.GetComponent<Collider>().ClosestPoint(transform.position)) < 3.1f)
        {
            Drop();
            if (isGathering)
            {
                myAgent.SetDestination(resPoint);
                myAgent.stoppingDistance = 3f;
            }
        }
    }

    public override void Move(Camera cam, NavMeshAgent agent)
    {
        base.Move(cam, agent);
        isGathering = false;
        currentResource = null;
    }

    protected void MoveToTarget()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            // Проверка на ресурс
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, resource))
            {
                Deselect();
                if (isBackpackEmpty)
                {
                    resPoint = hit.point;
                    myAgent.SetDestination(hit.point);
                    myAgent.stoppingDistance = 3f;
                    isGathering = true;


                    currentResource = hit.collider.GetComponent<GameResources>();
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
        currentTime += Time.deltaTime;
        if (currentTime >= gatherTime)
        {
            currentTime = 0f;
            if (currentResource != null && currentResource.TakeResource(10)) // Забираем 10 единиц ресурса
            {
                isBackpackEmpty = false;

                // Устанавливаем маршрут на базу
                myAgent.SetDestination(baseBuild.GetComponent<Collider>().ClosestPoint(transform.position));
                myAgent.stoppingDistance = 3f;
            }
        }
    }

    public void Drop()
    {
        if (!isBackpackEmpty)
        {
            Player player = FindObjectOfType<Player>();
            if (currentResource != null)
            {
                switch (currentResource.typeOfResource)
                {
                    case "Gold":
                        player.SetGoldNumber(10);
                        resourceUIManager.UpdateGold();
                        break;
                    case "Tree":
                        player.SetTreeNumber(10);
                        resourceUIManager.UpdateTree();
                        break;
                }
            }
            if (floatingTextPrefab != null)
            {
                GameObject text = Instantiate(floatingTextPrefab, baseBuild.transform.position, Quaternion.identity);
                //if(currentResource.typeOfResource == "Tree") text.GetComponent<FloatingText>().SetText($"+10", Color.white);
                //if (currentResource.typeOfResource == "Gold") text.GetComponent<FloatingText>().SetText($"+10", Color.yellow);
                text.GetComponent<FloatingText>().SetText($"+10", Color.white);
            }



            isBackpackEmpty = true;
            Debug.Log("Ресурс успешно доставлен на базу");
        }
    }
}
