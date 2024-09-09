/*
 * John Nguyen
 * Assignment 2 - Challenge 1
 * Description of Code: Was used to test the ScoreManager.cs code to increment the score by 1 for every time the player touched a trigger zone.
 * Note: Not actually attached to anything! I was re-watching the Follow-Along video, so it made sense to make this along the way.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnterTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TriggerZone"))
        {
            ScoreManager.score++;
        }
    }
}
