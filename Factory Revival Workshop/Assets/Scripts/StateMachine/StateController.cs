using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;
using Debug = UnityEngine.Debug;

public class StateController : MonoBehaviour
{
    private Context context;
    private enum CurrentState { setup, wander, attack, flee};
    private CurrentState myState;
    private GameObject player;

    private float DistanceToPlayer;
    public float wanderSpeed = 2.0f;
    public float attackSpeed = 3.0f;
    private float timeToEndFlee;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player == null)
        {
            Debug.Log("Havent found an object with Player tag");
        }
        myState = CurrentState.setup;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        DistanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        switch(myState)
        {
            case CurrentState.setup:
                Setup();
                break;
            case CurrentState.wander:
                Wander();
                break;
            case CurrentState.attack:
                Attack();
                break;
            case CurrentState.flee:
                Flee();
                break;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collided with: {collision.gameObject.name}");
        
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(transform.rotation.y*360);
            Quaternion target = Quaternion.identity;
            
            float newRotation = Random.value * 360;
                Debug.Log(newRotation);
            target.eulerAngles = new Vector3(0, newRotation, 0);

            transform.rotation = target;

            timeToEndFlee = Time.time + 5;

            myState = CurrentState.flee;
            Debug.Log("Switching to flee state");
        }

        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log(transform.rotation.y*360);
            Quaternion target = Quaternion.identity;

            float newRotation = (transform.rotation.y + 180) % 360;
            Debug.Log(newRotation);
            target.eulerAngles = new Vector3(0, newRotation, 0);

            transform.rotation = target;
        }
    }





    /**
     *  STATE FUNCTIONS
     */ 
     

    void Setup()
    {
        //Set direction
        Quaternion target = Quaternion.Euler(0, Random.value*360, 0);

        transform.rotation = target;
        myState = CurrentState.wander;
        Debug.Log("Switching to wander state");
    }

    void Wander()
    {
        float translation = 1 * wanderSpeed * Time.deltaTime;
        transform.Translate(translation, 0, 0);
        if(DistanceToPlayer <= 10)
        {
            Debug.Log("Switching to attack state");
            myState = CurrentState.attack;
        }
    }

    void Attack()
    {
        float step = attackSpeed * Time.deltaTime; // calculate distance to move
        Vector3 targetPosition = player.transform.position;
        targetPosition.y = 0;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }

    void Flee()
    {
        if(Time.time < timeToEndFlee)
        {
            float translation = 1 * wanderSpeed * Time.deltaTime;
            transform.Translate(translation, 0, 0);
        }
        else
        {
            myState = CurrentState.wander;
            Debug.Log("Switching to wander state");
        }
    }


}
