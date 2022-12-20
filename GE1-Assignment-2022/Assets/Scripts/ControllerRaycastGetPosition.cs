using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerRaycastGetPosition : MonoBehaviour
{
    public Transform Target;

    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 controllerDirection = transform.forward;

        Ray ray = new Ray(transform.position, controllerDirection);

        RaycastHit hit;
        bool hitDetect = Physics.Raycast(ray, out hit);

        if (hitDetect)
        { 
            // Set target which is being tracked by the hose arm
            Target.position = hit.point;
        }
        else
        {
            Target.position = transform.position + (controllerDirection * 100);
        }

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + (controllerDirection * 100));
    }
}
