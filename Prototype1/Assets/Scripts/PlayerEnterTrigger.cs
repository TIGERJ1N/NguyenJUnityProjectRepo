/*
 * John Nguyen
 * Assignment 2 - Prototype 1
 * Allows the program to detect if the player has interacted with a trigger zone, incrementing score if it does detect it
 * Currently going unused, as TriggerZoneAddScoreOnce is what is performing the addition of score
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this to the player
public class PlayerEnterTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerZone"))
        {
            ScoreManager.score++;
        }
    }

}
