using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class RightControllerActions : MonoBehaviour
{
    public Transform NozzleTarget;
    public Transform DogTarget;
    public ParticleSystem WaterJet;
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
            }
            else
            {
                WaterJet.Stop();
            }
        }
    }

    private void DogMoveTargetInput()
    {
        bool aButton;
        if (RightController.TryGetFeatureValue(CommonUsages.primaryButton, out aButton))
        {
            if (aButton)
            {
                DogTargetMoveToRayHit();
            }
        }
    }

    private void NozzleTargetMoveToRayHit()

    {
        Vector3 controllerDirection = transform.forward;

        Ray ray = new Ray(transform.position, controllerDirection);

        RaycastHit hit;
        bool hitDetect = Physics.Raycast(ray, out hit);

        if (hitDetect)
        {
            // Set target which is being tracked by the hose arm
            NozzleTarget.position = hit.point;
        }
        else
        {
            NozzleTarget.position = transform.position + (controllerDirection * 100);
        }

        // Debug
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + (controllerDirection * 100));
    }

    private void DogTargetMoveToRayHit()
    {

        Vector3 controllerDirection = transform.forward;

        Ray ray = new Ray(transform.position, controllerDirection);

        RaycastHit hit;
        bool hitDetect = Physics.Raycast(ray, out hit);

        if (hitDetect)
        {
            DogTarget.position = hit.point;
        }
    }
    // Update is called once per frame
    void Update()
    {
        NozzleTargetMoveToRayHit();
        WaterStreamInput();
        DogMoveTargetInput();
    }
}
