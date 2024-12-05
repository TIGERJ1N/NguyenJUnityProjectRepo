/*
* John Nguyen
* MoveTo.cs
* Assignment 9 - Pathfinding and AI with NavMeshAgent
* This is the basic move to script that was made during the follow-along.
* This was for the original target object that was made for Finished01, where the player's character
* was to move to the target as an example of how the NavMesh system works.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public Transform goal;

    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
