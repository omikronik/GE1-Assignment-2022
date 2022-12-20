using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GunPointer : MonoBehaviour
{
    public GameObject TargetPoint;
    public LayerMask LM;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{transform.rotation.x} : {transform.rotation.y} : {transform.rotation.z}");
    }
}
