/*
* John Nguyen
* ExitBehaviour.cs
* Assignment 5A
* This script controls when the exit door is enabled so the player can restart the game after collecting all of the gems
* So long as the player has collected all 40 gems and steps into the door, the player can restart the game
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBehaviour : MonoBehaviour
{

    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            scoreManager.DisplayRestartMessage();
        }
    }
}
