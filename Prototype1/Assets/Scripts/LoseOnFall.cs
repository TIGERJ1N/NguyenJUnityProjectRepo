/*
 * John Nguyen
 * Assignment 2 - Prototype 1
 * Allows the program to detect if the player has fallen off the side of the road
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this script to the player
public class LoseOnFall : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -1)
        {
            ScoreManager.gameOver = true;
        }
    }
}
