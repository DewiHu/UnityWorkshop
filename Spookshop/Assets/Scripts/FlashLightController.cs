using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLightController : MonoBehaviour
{
    public Text percentagetext;
    public Light flashlight;
    public float percentage = 15f;
    public float timeBetweenChanges = 10;
    private float lastChange;

    // Start is called before the first frame update
    void Start()
    {
        if(percentagetext == null)
        {
            Debug.Log("REEEEEE");
        }

        lastChange = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastChange >= timeBetweenChanges && percentage > 0)
        {
            percentage--;
            lastChange = Time.time;
        }


        percentagetext.text = percentage + "%";

        if(percentage <= 0)
        {
            flashlight.intensity = 0;
        }
    }
}
