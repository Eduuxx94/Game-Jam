using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLight : MonoBehaviour
{
    Light2D light;

    private float intensity;

    // Start is called before the first frame update
    void Start()
    {
        light = gameObject.GetComponent<Light2D>();
        intensity = light.intensity;
    }
    
    public void ReduceIntensity(float progress)
    {
        light.intensity = intensity * progress;
    }
}
