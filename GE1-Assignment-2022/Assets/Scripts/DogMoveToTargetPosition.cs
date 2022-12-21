using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class DogMoveToTargetPosition : MonoBehaviour
{
    public float speed = 2.0f;
    public float maxRotationSpeed = 5.0f;
    public Transform targetWaypoint;
    public float stopDistance = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        // calculate direction to target
        if ( distance > stopDistance)
        {
            Vector3 toTarget = new Vector3(targetWaypoint.position.x, 0.0f, targetWaypoint.position.z) - new Vector3(transform.position.x, 0.0f, transform.position.z);
            
            Quaternion targetRotation = Quaternion.LookRotation(toTarget) * Quaternion.Euler(0, 90, 0);

            // slerp :P the rotation for smoothness
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, maxRotationSpeed * Time.deltaTime);

            // move
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetWaypoint.position.x, transform.position.y, targetWaypoint.position.z), speed * Time.deltaTime);
        }

    }
}
