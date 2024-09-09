/*
 * John Nguyen
 * Assignment 2 - Challenge 1
 * Description of Code: Checks to see if the player has gone out of bounds, then causes the game to be over in ScoreManager.cs.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseOnOutOfBounds : MonoBehaviour
{ 
    // Checks to see if the player has gone out of bounds, upwards or downwards, then causes the game to be over
    void Update()
    {
        if (transform.position.y > 80 || transform.position.y < -51)
        {
            ScoreManager.gameOver = true;
        }
    }
}
