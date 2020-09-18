using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField]
    private float travelSpeed = 1;

    private Vector3 startingPosition;
    private Vector3 openPosition;
    void Start()
    {
        startingPosition = transform.position;
        openPosition = startingPosition + new Vector3(0, transform.localScale.y, 0);
    }

    public void OpenDoor()
    {
        StartCoroutine(Opening());
    }

    private IEnumerator Opening()
    {
        while (transform.position.y < openPosition.y)
        {
            transform.Translate(Vector3.up * travelSpeed * Time.deltaTime);
            yield return null;
        }
        yield return null;
    }

    public void CloseDoor()
    {
        StartCoroutine(Closing());
    }

    private IEnumerator Closing()
    {
        while (transform.position.y > startingPosition.y)
        {
            transform.Translate(Vector3.down * travelSpeed * Time.deltaTime);
            yield return null;
        }
        yield return null;
    }
}
