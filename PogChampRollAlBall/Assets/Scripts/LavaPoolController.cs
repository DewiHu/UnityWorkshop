using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPoolController : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        
        if(other.collider.gameObject.name == "Player")
        {
            Vector3 spawnPoint = new Vector3(1.83f, 3f, 0.75f);
            other.transform.position = spawnPoint;
            other.rigidbody.velocity = new Vector3(0, 0, 0);
        }
    }

}
