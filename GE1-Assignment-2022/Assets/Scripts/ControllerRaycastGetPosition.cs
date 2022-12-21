using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class ControllerRaycastGetPosition : MonoBehaviour
{
    public Transform Target;
    public ParticleSystem WaterJet;
    public ParticleSystem WaterSpray;
    public InputDevice RightController;

    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        InitController();

    }

    private void InitController()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, devices);

        if (devices.Count > 0)
        {
            RightController = devices[0];
        }
    }

    private void WaterStreamInput()
    {
        bool trigger;
        if (RightController.TryGetFeatureValue(CommonUsages.triggerButton, out trigger))
        {

            if (trigger)
            {
                WaterJet.Play();
                WaterSpray.Play();
            }
            else
            {
                WaterJet.Stop();
                WaterSpray.Stop();
            }
        }
    }

    private void TargetMoveToRayHit()
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

        // Debug
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + (controllerDirection * 100));
    }

    // Update is called once per frame
    void Update()
    {
        TargetMoveToRayHit();
        WaterStreamInput();
    }
}
