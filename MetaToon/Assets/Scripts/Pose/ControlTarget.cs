using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTarget : MonoBehaviour
{
    private Transform X;
    private Transform Y;
    private Transform Z;

    private bool isDragged;
    private RaycastHit _downHit;
    private Vector3 _downMousePoint;
    private Vector3 deltaPos;

    public cameraScript camscript;

    // Start is called before the first frame update
    void Start()
    {
        X = this.transform.Find("x");
        Y = this.transform.Find("y");
        Z = this.transform.Find("z");

        isDragged = false;

        camscript = Camera.main.GetComponent<cameraScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            Vector3 rayPoint = ray.GetPoint(distance);

            if (Physics.Raycast(ray, out _downHit))
            {
                isDragged = true;
                _downMousePoint = ray.GetPoint(distance);
                deltaPos =   _downMousePoint - transform.position;
                if(_downHit.transform.tag.Equals("control"))
                    camscript.controlObjectMove = true;
            }
        }

        if (Input.GetMouseButton(0) && isDragged)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            Vector3 rayPoint = ray.GetPoint(distance);
            

            if (_downHit.transform.Equals(X))
                transform.position = new Vector3(rayPoint.x-deltaPos.x, transform.position.y, transform.position.z);
            else if (_downHit.transform.Equals(Y))
                transform.position = new Vector3(transform.position.x, rayPoint.y - deltaPos.y, transform.position.z);
            else if (_downHit.transform.Equals(Z))
                transform.position = new Vector3(transform.position.x, transform.position.y, rayPoint.z - deltaPos.z);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragged = false;
            camscript.controlObjectMove = false;
        }
    }
}

