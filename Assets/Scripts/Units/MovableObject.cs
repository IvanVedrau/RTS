using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

public abstract class MovableObject : MonoBehaviour
{

    public LayerMask ground;
    public bool IsSelected(GameObject unit)
    {
        return UnitSelections.Instance.unitSelectedList.Contains(unit);
    }

    public void Move(Camera cam, NavMeshAgent agent)
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                agent.SetDestination(hit.point);
            }
        }

    }

}
