using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light[] PointLight;
    public GameObject lights;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            foreach(var light in lights.GetComponentsInChildren<Light>())
            {              
                light.enabled = !light.enabled;
            }
        }
    }
}
