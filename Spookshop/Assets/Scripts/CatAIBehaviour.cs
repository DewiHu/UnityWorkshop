﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatAIBehaviour : MonoBehaviour
{
    public enum State
    {
        Patrol,
        Flee
    }

    private State currentState;

    public GameObject player;
    public float fleeRadius;

    private Vector3 destinationPos;
    private NavMeshAgent agent;
    private GameObject[] wanderPointList;

    // Start is called before the first frame update
    void Start()
    {
        currentState = State.Patrol;
        agent = gameObject.GetComponent<NavMeshAgent>();
        wanderPointList = GameObject.FindGameObjectsWithTag("WanderPoint");
        FindNextPatrolPoint();
    }

    // Update is called once per frame
    void Update()
    {

        switch (currentState)
        {
            case State.Patrol:
                PatrolUpdate();
                break;
            case State.Flee:
                FleeUpdate();
                break;
        }
    }


    void PatrolUpdate()
    {
        if (Vector3.Distance(transform.position, destinationPos) <= 5.0f)
        {
            FindNextPatrolPoint();
        }
        else if (Vector3.Distance(transform.position, player.transform.position) <= fleeRadius)
        {
            currentState = State.Flee;
        }
    }

    void FleeUpdate()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > fleeRadius)
        {
            currentState = State.Patrol;
        }

        var fleeVector = transform.position - player.transform.position;
        destinationPos = transform.position + fleeVector.normalized * fleeRadius;
        agent.SetDestination(destinationPos);
    }

    void FindNextPatrolPoint()
    {
        var randomIndex = Random.Range(0, wanderPointList.Length);
        var randomRadius = 10.0f;

        destinationPos = wanderPointList[randomIndex].transform.position;

        if (IsInCurrentRange(destinationPos))
        {
            var randomPosition = new Vector3(Random.Range(-randomRadius, randomRadius), 0.0f, Random.Range(-randomRadius, randomRadius));
            destinationPos = wanderPointList[randomIndex].transform.position + randomPosition;
        }

        agent.SetDestination(destinationPos);
    }

    bool IsInCurrentRange(Vector3 position)
    {
        var currentPointRange = 10.0f;
        var xPosition = Mathf.Abs(position.x - transform.position.x);
        var zPosition = Mathf.Abs(position.z - transform.position.z);

        if (xPosition <= currentPointRange && zPosition <= currentPointRange)
        {
            return true;
        }

        return false;
    }
}
