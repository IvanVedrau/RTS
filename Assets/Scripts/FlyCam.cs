using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyCam : MonoBehaviour
{

    Camera cam;
    public float speed = 2.0f, scrollSpeed = 2.0f, rotSpeed = 2.0f, maxGroundDis = 20;
    public int maxOutRot = 40, minInRot = 15;

    Vector3 iPos;
    bool outR, inR;

    Rect top, down, left, right;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        float hi = (Screen.height / 10) * 2;
        float wi = Screen.width / 20;
        float w = Screen.width;
        float h = Screen.height;

        down = new Rect(0,0, w, hi);
        top = new Rect(0, h - hi, w, hi);
        left = new Rect(0, 0, wi, h);
        right = new Rect(w - wi, 0, wi, h);

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        var p = transform.position;
        var r = transform.rotation;
        var time = Time.deltaTime;

        float w = Input.GetAxis("Mouse ScrollWheel");

        if (outR)
        {
            if (w < 0)
            {
                p.z += w * (scrollSpeed * 2) * time;
                p.y -= w * (scrollSpeed * 2) * time;
                transform.position = new Vector3(p.x, p.y, p.z);
                outR = false;

            }

        }

        else if (inR)
        {

            if (w > 0)
            {
                p.z += w * (scrollSpeed * 2) * time;
                p.y -= w * (scrollSpeed * 2) * time;
                transform.position = new Vector3(p.x, p.y, p.z);
                inR = false;

            }

        }

        else
        {
            
                p.z += w * (scrollSpeed * 2) * time;
                p.y -= w * (scrollSpeed * 2) * time;
                transform.position = new Vector3(p.x, p.y, p.z);
                inR = false;

            

        }


        if (Physics.Raycast(p, -Vector3.up, out hit, 1000))

        {
            inR = false;
            float ds = Vector3.Distance(p, hit.point);

            if (ds < maxGroundDis)
            {
                transform.rotation = Quaternion.Slerp(r, Quaternion.Euler(new Vector3(minInRot, r.y, r.z)), time * rotSpeed);
                outR = true;
            }

            else outR = false;

            if (ds > maxGroundDis * 2) transform.rotation = Quaternion.Slerp(r, Quaternion.Euler(new Vector3(maxOutRot, r.y, r.z)), time * rotSpeed);

            else if (ds < maxGroundDis - 1) transform.position = new Vector3(p.x, p.y + 0.1f, p.z);


        }

        else inR = true;

        if(Input.GetButtonDown("Fire3"))
        {
            iPos = Input.mousePosition;
            return;

        }

        if (Input.GetButton("Fire3"))
        {
            Vector3 dir = cam.ScreenToViewportPoint(Input.mousePosition - iPos);
            transform.Translate(new Vector3(-dir.x * speed, 0, -dir.y * speed), Space.World);

        }

        Vector3 dirr = Vector3.zero;
        Vector2 m = Input.mousePosition;

        if (top.Contains(m)) dirr.z = speed * time;
        else if (down.Contains(m)) dirr.z = -speed * time;

        if (left.Contains(m)) dirr.x = -speed * time;
        else if (right.Contains(m)) dirr.x = speed * time;

        transform.position = transform.position + dirr;

    }
}
