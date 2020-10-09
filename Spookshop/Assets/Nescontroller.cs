using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nescontroller : MonoBehaviour
{
    public GameObject controller;
    private CharacterJoint joint;
    private GameObject instantiatedController;

    private void Awake()
    {
        Vector3 pos = transform.position + transform.forward;
        Quaternion rotation = transform.rotation;
        instantiatedController = Instantiate(controller, pos, rotation);
        Vector3 scale = instantiatedController.transform.localScale;
        scale.x = 0.1f;
        scale.y = 0.1f;
        scale.z = 0.1f;
        instantiatedController.transform.localScale = scale;
    }

    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<CharacterJoint>();
        joint.connectedBody = instantiatedController.GetComponent<Rigidbody>();

        transform.parent.GetComponentInChildren<RopeController>().hangingFromRope = instantiatedController.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
