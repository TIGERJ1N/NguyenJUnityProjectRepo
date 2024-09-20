/*
* John Nguyen
* TriggerZoneAddScore.cs
* Assignment 4 - Prototype 3
* This is the trigger zone script added to obstacles. 
* When players run into the invisible trigger above an obstacle, it increments the score by one.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneAddScore : MonoBehaviour
{
    private UIManager uIManager;

    private bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            uIManager.score++;
        }
    }
}
