﻿/*
    * John Nguyen
    * DestroyOutOfBounds.cs
    * Assignment 3 - Prototype2
    * This is the destroy out of bounds script, which manages how the food projectiles and animals are deleted. When either exit their respective boundaries, the script deletes those objects
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 20;
    public float bottomBound = -10;

    private HealthSystem healthSystemScript;

    private void Start()
    {
        healthSystemScript = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // if food goes out of bounds, topBound
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }

        // if animal goes out of bounds, bottomBound
        if (transform.position.z < bottomBound)
        {
            //Debug.Log("Game Over!");

            // Grab the health system script and call TakeDamage()
            healthSystemScript.TakeDamage();

            Destroy(gameObject);
        }
    }
}
