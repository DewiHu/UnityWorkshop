using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPoolController : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        
        if(other.collider.gameObject.name == "Player")
        {
            Vector3 spawnPoint = new Vector3(339.2f, 3.02f, 7.69f);
            other.transform.position = spawnPoint;
            other.rigidbody.velocity = new Vector3(0, 0, 0);
        }
    }

}
