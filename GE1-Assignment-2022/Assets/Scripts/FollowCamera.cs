using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        GameObject cameraGO = GameObject.FindWithTag("MainCamera");

        camera = cameraGO.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - camera.transform.position);
    }
}
