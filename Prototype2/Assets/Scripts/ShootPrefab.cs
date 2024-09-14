/*
    * John Nguyen
    * ShootPrefab.cs
    * Assignment 3 - Prototype2
    * This is the shoot prefab script, which allows the player to shoot a food prefab from their player model when the Spacebar is pressed down
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this script to player
public class ShootPrefab : MonoBehaviour
{
    public GameObject prefabToShoot;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Create a clone of the prefab to shoot (food object) at the player's position using the prefab's rotation
            Instantiate(prefabToShoot, transform.position, prefabToShoot.transform.rotation);
        }
    }
}
