/*
* John Nguyen
* YouWinTriggerZone.cs
* Assignment 5B - 3D Prototype with ProBuilder
* This is the YouWinTriggerZone script. It is attached to the YouWinTrigger object. When the player has destroyed all 30 targets and has gotten to the final platform,
* the game will officially be won, and the player can restart the game over to play again.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YouWinTriggerZone : MonoBehaviour
{
    public Text textbox;
    private bool playerInTriggerZone = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && ScoreManager.gameOver)
        {
            playerInTriggerZone = true; // Player has entered the trigger zone
            ScoreManager.displayWinMessage = true; // Stops ScoreManager from updating textbox
            textbox.text = "You win!\nPress R to do the obstacle course again!";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTriggerZone = false; // Player has left the trigger zone
        }
    }

    private void Update()
    {
        // Restart game only if player is in trigger zone and game is over
        if (ScoreManager.gameOver && playerInTriggerZone && Input.GetKeyDown(KeyCode.R))
        {
            ScoreManager.displayWinMessage = false; // Reset flag on restart
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
