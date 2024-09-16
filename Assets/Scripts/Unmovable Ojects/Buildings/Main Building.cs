using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBuilding : Building
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        gameObject.tag = "Main Building";
    }


}
