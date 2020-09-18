using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public GameObject lights;

    public void Start()
    {
        foreach (var light in lights.GetComponentsInChildren<Light>())
        {
            light.enabled = !light.enabled;
        }
    }

    // Update is called once per frame
    public void EnableLights()
    {
        foreach (var light in lights.GetComponentsInChildren<Light>())
        {
            light.enabled = !light.enabled;
        }
    }
}
