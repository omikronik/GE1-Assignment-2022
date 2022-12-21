using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class DogLegMove : MonoBehaviour
{
    public float updateSeconds = 3.0f;
    public GameObject frontLeftRayCast;
    public GameObject frontRightRayCast;
    public GameObject backLeftRayCast;
    public GameObject backRightRayCast;

    public List<GameObject> legRayCasters;

    public int counter = 0;
    IEnumerator NewLegStepTargets()
    {
        while(true)
        {
            int currentIteration = counter % legRayCasters.Count;
            Ray ray = new Ray(legRayCasters[currentIteration].transform.position, Vector3.down);

            RaycastHit hit;
            bool hitDetect = Physics.Raycast(ray, out hit);

            if (hitDetect)
            {
                legRayCasters[currentIteration].SendMessage("UpdateTarget", new Vector3(hit.point.x, 0.0f, hit.point.z));
            }

            yield return new WaitForSeconds(updateSeconds);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        legRayCasters = new List<GameObject> { frontLeftRayCast, backLeftRayCast, frontRightRayCast, backRightRayCast };
        StartCoroutine(NewLegStepTargets());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
