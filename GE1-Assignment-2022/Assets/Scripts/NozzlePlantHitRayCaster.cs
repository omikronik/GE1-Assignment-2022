using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NozzlePlantHitRayCaster : MonoBehaviour
{
    public float waterRange = 5.0f;
    public ParticleSystem waterStatus;
    public int plantsLayer = 6;

    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void detectPlantHit()
    {

        //Vector3 nozzleDirection = new Vector3(Mathf.Cos(transform.rotation.x) * Mathf.Sin(transform.rotation.y),  -Mathf.Sin(transform.rotation.x), Mathf.Cos(transform.rotation.x) * Mathf.Cos(transform.rotation.y));

        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;
        bool hitDetect = Physics.Raycast(ray, out hit, waterRange, plantsLayer);

        if (hitDetect)
        {
            // Set target which is being tracked by the hose arm
            Debug.Log("hit plant");
            Destroy(hit.collider.gameObject);

            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + transform.forward *  100);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{transform.rotation.x} {transform.rotation.y} {transform.rotation.z}");
        detectPlantHit();       
    }
}
