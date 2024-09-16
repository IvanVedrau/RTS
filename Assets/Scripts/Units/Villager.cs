using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Villager : MovableObject
{

    protected override void Start()
    {
        base.Start();
        gameObject.tag = "Villager";
 
    }

    protected override void Update()
    {
        base.Update();
    }

}
