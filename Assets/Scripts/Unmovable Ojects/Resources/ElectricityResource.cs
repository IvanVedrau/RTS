using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityResource : GameResources
{
    protected override void Start()
    {
        base.Start();
        gameObject.tag = "Electricity";
        typeOfResource = "Electricity";
    }

}
