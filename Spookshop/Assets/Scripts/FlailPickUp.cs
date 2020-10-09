using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlailPickUp : MonoBehaviour
{
    public GameObject flail = null;
    public bool hasFlail = false;
    private new Transform camera;

    void Start()
    {
        camera = transform.GetChild(0);
    }

    void Update()
    {
        if (hasFlail)
        {
            flail.transform.position = camera.position + camera.right * 0.637f + camera.up * -1.057f + camera.forward * 1.592f;
            flail.transform.rotation = new Quaternion(camera.rotation.x, camera.rotation.y, camera.rotation.z, camera.rotation.w);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Flail") && !hasFlail)
        {
            Debug.Log("Collided with flail");
            hasFlail = true;
            other.gameObject.transform.SetParent(transform.GetChild(0));
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}