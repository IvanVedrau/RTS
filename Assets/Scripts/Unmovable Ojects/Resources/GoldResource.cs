using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldResource : GameResources
{
    protected override void Start()
    {
        base.Start();
        gameObject.tag = "Gold";
        typeOfResource = "Gold";
    }

}
