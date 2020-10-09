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

    // Start is called before the first frame update
    void Start()
    {
        if(percentagetext == null)
        {
            Debug.Log("REEEEEE");
        }

        StartCoroutine(LowerPercentage());
    }

    // Update is called once per frame
    void Update()
    { 
    }


    IEnumerator LowerPercentage()
    {
        while(percentage > 0)
        {
            percentage--;
            percentagetext.text = percentage + "%";
            yield return new WaitForSeconds(timeBetweenChanges);
        }
        flashlight.intensity = 0;

        
    }
}
