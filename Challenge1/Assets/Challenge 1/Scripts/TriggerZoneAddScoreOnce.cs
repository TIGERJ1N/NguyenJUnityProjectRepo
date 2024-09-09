/*
 * John Nguyen
 * TriggerZoneAddScoreOnce.cs
 * Assignment 2 - Challenge 1
 * Description of Code: The replacement script for PlayerEnterTrigger.cs. If the object that a trigger zone collides with is a player,
 *                      consider that trigger zone as triggered and increment the score by 1.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneAddScoreOnce : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            ScoreManager.score++;
        }
    }
}
