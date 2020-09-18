using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoWasdPlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        Vector3 newPosition = transform.position + (new Vector3(horizontalMovement, 0, verticalMovement).normalized) * speed * Time.deltaTime;
        rb.MovePosition(newPosition);
    }
}
