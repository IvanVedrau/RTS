using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RTSObject : MonoBehaviour
{

    public bool IsSelected()
    {
        return UnitSelections.Instance.unitSelectedList.Contains(gameObject);
    }

    public void ShowSelectionCircle()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);

    }

    public void HideSelectionCircle()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void Deselect()
    {
        UnitSelections.Instance.unitSelectedList.Remove(gameObject);
        HideSelectionCircle();
    }


    protected virtual void Start()
    {
        UnitSelections.Instance.unitList.Add(gameObject);
    }

    protected virtual void Update()
    {
        if (IsSelected())
        {
            ShowSelectionCircle();
        }
        else
        {
            HideSelectionCircle();
        }
    }
}