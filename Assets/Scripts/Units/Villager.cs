using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Villager : MovableObject
{
    Camera myCam;
    NavMeshAgent myAgent;
    public Material stM;
    Material _m;

    void Start()
    {
        myCam = Camera.main;
        myAgent = GetComponent<NavMeshAgent>();
        gameObject.tag = "Villager";
        UnitSelections.Instance.unitList.Add(this.gameObject);
  
        _m = Instantiate(stM);
        GetComponent<Renderer>().material = _m;
    }

    void Update()
    {
        if (IsSelected(this.gameObject)) {
            Move(myCam, myAgent);
        }
        if(UnitSelections.Instance.unitSelectedList.Contains(this.gameObject)) _m.SetColor("_Color", Color.green);
        else _m.SetColor("_Color", Color.white);   
    }
}
