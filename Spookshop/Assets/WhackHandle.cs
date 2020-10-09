using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhackHandle : MonoBehaviour
{
    public float swingSpeed = 1;
    private bool swinging = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !swinging)
        {
            StartCoroutine(Whack());
        }
        Debug.Log(transform.localRotation.eulerAngles.x);
    }

    IEnumerator Whack()
    {
        swinging = true;
        Debug.Log("WE WACKING BOI");
        while (transform.localRotation.eulerAngles.x > 330)
        {
            float turnTranslation = swingSpeed * Time.deltaTime;
            //if (turnTranslation < 330)
            //{
            //    turnTranslation = 330;
            //}
            Vector3 newAngles = new Vector3(-turnTranslation, 0, 0);
            transform.Rotate(newAngles);
            yield return null;
        }
        while (transform.localRotation.eulerAngles.x < 359 || (transform.localRotation.eulerAngles.x < 35 && transform.localRotation.eulerAngles.x > 0))
        {
            float turnTranslation = swingSpeed * 3 * Time.deltaTime;
            Vector3 newAngles = new Vector3(turnTranslation, 0, 0);
            transform.Rotate(newAngles);
            yield return null;
        }

        transform.localRotation = Quaternion.Euler(new Vector3(-1, 0, 0));
        swinging = false;
    }
}
