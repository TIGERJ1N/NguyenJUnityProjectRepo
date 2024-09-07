/*
 * John Nguyen
 * Assignment 2 - Prototype 1
 * Adds trigger zones for the player to drive into to increment their score, specifically only once
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Attach this script to a Trigger Zone so that each Trigger Zone only triggers once
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
