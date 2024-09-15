/*
    * John Nguyen
    * DestroyOutOfBoundsX.cs
    * Assignment 3 - Challenge2
    * This is the DestroyOutOfBoundsX script, with slight adjustments made to the if and else-if statements as part of Part 1 for Challenge2
    * The script also has the ability to access the HealthSystem script to call upon the TakeDamage() script when a dog does not catch a ball as it falls past the bottom of the screen
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = -30;
    private float bottomLimit = -5;

    // Added: Give this script the ability to access what's in HealthSystem.cs
    private HealthSystem healthSystemScript;

    // Added: Access the HealthSystem script from start
    private void Start()
    {
        healthSystemScript = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        } 
        // Destroy balls if y position is less than bottomLimit
        else if (transform.position.y < bottomLimit)
        {
            // Added: Grab the health system script and call TakeDamage()
            healthSystemScript.TakeDamage();

            Destroy(gameObject);
        }

    }
}
