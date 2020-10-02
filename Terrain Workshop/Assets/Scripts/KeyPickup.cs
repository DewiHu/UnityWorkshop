using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{

    public GameObject key = null;
    public GameObject gate = null;
    [HideInInspector]
    public bool hasKey = false;
    private Vector3 keyStartingPos;
    private Quaternion keyStartingRotation;
    private Transform camera;

    void Start()
    {
        keyStartingPos = key.transform.position;
        keyStartingRotation = key.transform.rotation;
        camera = transform.GetChild(0);
    }

    void Update()
    {
        if (hasKey)
        {
            key.transform.position = camera.position + camera.forward * 2 + camera.right - camera.up;
            key.transform.rotation = new Quaternion(0.0f, camera.rotation.y, 0.0f, camera.transform.rotation.w);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(key))
        {
            Debug.Log("Collided with key");
            hasKey = true;
            gate.SetActive(!hasKey);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Zombie"))
        {
            hasKey = false;
            key.transform.position = keyStartingPos;
            key.transform.rotation = keyStartingRotation;
            gate.SetActive(!hasKey);
        }
    }
}
