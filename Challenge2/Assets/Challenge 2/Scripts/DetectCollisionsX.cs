/*
    * John Nguyen
    * DetectCollisionsX.cs
    * Assignment 3 - Challenge2
    * This is the DetectCollisions script, attached to ball prefabs, to detect when balls have collided with a dog. Updates score by 1 for every collision, then destroys the ball
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{

    private DisplayScore displayScoreScript; // Added: Creates a reference to the DisplayScore class

    private void Start()
    {
        displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>(); // Added: Finds the score component
    }

    private void OnTriggerEnter(Collider other)
    {
        displayScoreScript.score++; // Added: this will increment the score every time a dog catches a ball
        Destroy(gameObject);
    }
}
