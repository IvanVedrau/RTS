using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameResources : RTSObject
{
    public int numberOfResource = 10000;
    public string typeOfResource;
    public bool TakeResource(int amount)
    {
        if (numberOfResource >= amount)
        {
            numberOfResource -= amount;
            return true;
        }
        return false;
    }

}
