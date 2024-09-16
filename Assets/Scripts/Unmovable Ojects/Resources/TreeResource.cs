using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeResource : Resources
{
    protected override void Start()
    {
        base.Start();
        gameObject.tag = "Tree";
    }

}
