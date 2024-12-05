/*
* John Nguyen
* MoveToClickPoint.cs
* Assignment 9 - Pathfinding and AI with NavMeshAgent
* This is the updated move to script that was made during the follow-along.
* This script allows the player to use their cursor to move the character
* to a location pointed to on-screen in the game.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToClickPoint : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.destination = hit.point;
            }
        }
    }
}
