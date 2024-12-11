using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeResource : GameResources
{
    protected override void Start()
    {
        base.Start();
        gameObject.tag = "Tree";
        typeOfResource = "Tree";
    }

}
