using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegIKHelper : MonoBehaviour
{
    public Transform target;

    public void UpdateTarget(Vector3 newPos)
    {
        target.position = newPos;
        Debug.Log($"message received {newPos.x} {newPos.y} {newPos.z}");
    }

    private void OnDrawGizmos()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(target.position, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
