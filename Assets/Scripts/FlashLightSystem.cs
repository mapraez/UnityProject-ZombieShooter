using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = .5f;
    [SerializeField] float angleDecay = 2f;
    [SerializeField] float minimumAngle = 30f;

    Light myLight;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        myLight.spotAngle = restoreAngle;
    }

    public void RestoreLightIntensity(float intensityAmount)
    {
        myLight.intensity += intensityAmount;
        if (myLight.intensity >= 10f)
        {
            myLight.intensity = 10f;
        }

    }

    private void DecreaseLightAngle()
    {
        if (myLight.spotAngle <= minimumAngle)
        {
            return;
        }
        else
        {
            myLight.spotAngle -= Time.deltaTime * angleDecay;
        }

    }

    private void DecreaseLightIntensity()
    {
        myLight.intensity -= Time.deltaTime * lightDecay;
    }

}
