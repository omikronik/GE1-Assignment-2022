using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class NozzlePlantHitRayCaster : MonoBehaviour
{
    public float waterRange = 5.0f;
    public ParticleSystem waterStatus;
    public int plantsLayer;
    public float fireRate = 5.0f;
    private LineRenderer lineRenderer;


    // Coroutine because having it in update sends way too many updates
    IEnumerator WaterVectorInput()
    {
        while (true)
        {
            DetectPlantHit();

            yield return new WaitForSeconds(1.0f);
        }
    }

    void DetectPlantHit()
    {

        //Vector3 nozzleDirection = new Vector3(Mathf.Cos(transform.rotation.x) * Mathf.Sin(transform.rotation.y),  -Mathf.Sin(transform.rotation.x), Mathf.Cos(transform.rotation.x) * Mathf.Cos(transform.rotation.y));

        int layerMask = (1 << plantsLayer);
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;
        bool hitDetect = Physics.Raycast(ray, out hit, waterStatus.shape.length, layerMask);

        if (hitDetect && waterStatus.isEmitting)
        {
            // Set target which is being tracked by the hose arm
            Debug.Log($"hit plant {hit.collider.gameObject.name}");
            hit.collider.gameObject.SendMessage("AddWaterLevel");
            //Destroy(hit.collider.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //lineRenderer = GetComponent<LineRenderer>();
        plantsLayer = LayerMask.NameToLayer("Plants");
        StartCoroutine(WaterVectorInput());
    }
    

    // Update is called once per frame
    void Update()
    {
    }
}
