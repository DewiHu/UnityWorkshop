using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyController : MonoBehaviour
{

    private List<GameObject> keys = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        foreach (GameObject key in keys)
        {
            key.transform.position = transform.position + (transform.up * (keys.IndexOf(key) + 1));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Key"))
        {
            keys.Add(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Keyhole"))
        {
            Transform keyhole = other.transform.parent;
            KeyTurninController keyholeController = keyhole.GetComponent<KeyTurninController>();
            GameObject neededKey = keyholeController.belongsToKey;
            if (keys.Contains(neededKey))
            {
                keyholeController.OnKeyTurnin.Invoke();
                keys.Remove(neededKey);
                neededKey.transform.position = keyhole.position;
                neededKey.GetComponent<Collider>().enabled = false;
            }
        }
    }
}
