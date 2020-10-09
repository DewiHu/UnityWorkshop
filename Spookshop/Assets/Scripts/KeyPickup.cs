using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{

    public GameObject key = null;
    public GameObject gate = null;
    [HideInInspector]
    public bool hasKey = false;
    private new Transform camera;

    void Start()
    {
        camera = transform.GetChild(0);
    }

    void Update()
    {
        if (hasKey)
        {
            key.transform.position = camera.position + camera.right * -0.5f + camera.up * -0.4f + camera.forward * .75f;
            key.transform.rotation = new Quaternion(0.0f, camera.rotation.y, 0.0f, camera.transform.rotation.w);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cat") && !hasKey)
        {
            Debug.Log("Collided with key");
            hasKey = true;
            gate.SetActive(!hasKey);
            other.gameObject.transform.GetChild(0).SetParent(transform);
        } 
    }
}
