using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{

    public GameObject key = null;
    public GameObject gate = null;
    [HideInInspector]
    public bool hasKey = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.Equals(key))
        {
            hasKey = true;
            gate.SetActive(!hasKey);
            key.SetActive(!hasKey);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Zombie"))
        {
            hasKey = false;
            gate.SetActive(!hasKey);
            key.SetActive(!hasKey);
        }
    }
}
