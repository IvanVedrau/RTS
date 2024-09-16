using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelections : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitSelectedList = new List<GameObject>();

    private static UnitSelections _instance;
    public static UnitSelections Instance { get { return _instance; } }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void ClickSelect(GameObject unit)
    {

        if (unitSelectedList.Contains(unit))
        {
            DeselectAll();
            foreach(var element in unitList){
                if (element.gameObject.tag.Equals(unit.gameObject.tag)) unitSelectedList.Add(element);
            }
        }
        else
        {
            DeselectAll();
            unitSelectedList.Add(unit);
        }

    }
    public void ShiftClickSelect(GameObject unit)
    {
        if (!unitSelectedList.Contains(unit)){
            unitSelectedList.Add(unit);
        }
        else
        {
            unitSelectedList.Remove(unit);
        }
    }
    public void DragSelect(GameObject unit)
    {
        if (!unitSelectedList.Contains(unit))
        {
            unitSelectedList.Add(unit);
        }
    }

    public void DeselectAll()
    {
        unitSelectedList.Clear();
    }

}
