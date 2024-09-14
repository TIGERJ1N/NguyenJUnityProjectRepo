/*
    * John Nguyen
    * DetectCollisions.cs
    * Assignment 3 - Prototype2
    * This is the detect collisions script, which does two things:
    *   When the food projectile collides into an animal, the script first calls DisplayScore(), which is in DisplayScore.cs, to update the "Score: " text by incrementing the score by 1
    *   Then, whatever the food projectile collided into destroys/deletes the animal, then the food projectile itself
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach to food projectile prefab
public class DetectCollisions : MonoBehaviour
{
    private DisplayScore displayScoreScript;

    private void Start()
    {
        displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>();
    }

    private void OnTriggerEnter(Collider other) // other will be the animal that we hit with our food object
    {
        displayScoreScript.score++;
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
