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
