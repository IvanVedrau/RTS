using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClick : MonoBehaviour
{
    private Camera myCam;

    public LayerMask clickable;
    public LayerMask ground;

    void Start()
    {
        myCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    UnitSelections.Instance.ShiftClickSelect(hit.collider.gameObject);
                }
                else
                {
                    UnitSelections.Instance.ClickSelect(hit.collider.gameObject);
                }
            }
            else
            {
                if (!Input.GetKeyDown(KeyCode.LeftShift))
                {
                    UnitSelections.Instance.DeselectAll();
                }

            }
        }   
    }
}
