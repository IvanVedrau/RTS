using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int goldNumber;
    private int treeNumber;
    private int electricityNumber;

    public void SetGoldNumber(int num)
    {
        this.goldNumber += num;
    }
    public void SetTreeNumber(int num)
    {
        this.treeNumber += num;
    }
    public void SetElectricityNumber(int num)
    {
        this.electricityNumber += num;
    }

    public int GetGoldNumber() => goldNumber;
    public int GetTreeNumber() => treeNumber;
    public int GetElectricityNumber() => electricityNumber;

}
