using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController fpsContoller;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomInFOV = 30f;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = 2f;
    bool zoomedInToggle = false;

    private void OnDisable()
    {
        ZoomOut();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomIn()
    {
        zoomedInToggle = true;
        fpsCamera.fieldOfView = zoomInFOV;
        fpsContoller.mouseLook.XSensitivity = zoomInSensitivity;
        fpsContoller.mouseLook.YSensitivity = zoomInSensitivity;
    }

    private void ZoomOut()
    {
        zoomedInToggle = false;
        fpsCamera.fieldOfView = zoomedOutFOV;
        fpsContoller.mouseLook.XSensitivity = zoomOutSensitivity;
        fpsContoller.mouseLook.YSensitivity = zoomOutSensitivity;
    }

}