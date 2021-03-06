﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBehaviour : MonoBehaviour
{
    public enum state
    { 
        Patrol,
        Chase
    }

    public state currentState;

    public GameObject player;

    public float chaseRadius = 500;
    public float patrolAreaHeight = 50;
    public float patrolAreaWidth = 50;

    private Vector3 originPosition;

    public Vector3 destinationPos;
    private NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        currentState = state.Patrol;
        agent = gameObject.GetComponent<NavMeshAgent>();
        destinationPos = new Vector3(Random.Range(transform.position.x - patrolAreaHeight, transform.position.x + patrolAreaHeight), 0, Random.Range(transform.position.z - patrolAreaWidth, transform.position.z + patrolAreaWidth));
        originPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case state.Patrol: PatrolUpdate(); break;
            case state.Chase: ChaseUpdate(); break;
        }
    }


    void PatrolUpdate()
    {
        if(Vector3.Distance(transform.position, destinationPos) <= 10f)
        {
            destinationPos = new Vector3(Random.Range(originPosition.x - patrolAreaHeight, originPosition.x + patrolAreaHeight), 0, Random.Range(originPosition.z - patrolAreaWidth, originPosition.z + patrolAreaWidth));
        }
        if(Vector3.Distance(transform.position, player.transform.position) <= chaseRadius)
        {
            currentState = state.Chase;
        }

        agent.SetDestination(destinationPos);
    }

    void ChaseUpdate()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > chaseRadius)
        {
            currentState = state.Patrol;
        }

        agent.SetDestination(player.transform.position);
    }
}
