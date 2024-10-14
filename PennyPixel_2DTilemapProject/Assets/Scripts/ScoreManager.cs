/*
* John Nguyen
* ScoreManager.cs
* Assignment 5A
* This is the score manager script, which keeps track and updates of the following: 
*   current score (gems collected), game completion state, whether or not the player has fallen past the bottom bound, 
*   and the ScoreText object, updating it as the player plays the game.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;              // Manage text on-screen
using UnityEngine.SceneManagement; // Manage scene reloading

public class ScoreManager : MonoBehaviour
{
    // Score Text
    public Text scoreText;                     // Reference to the ScoreText object in Canvas
    public GameObject exitObject;              // Reference to the Exit GameObject
    public Transform player;                   // Reference to the player transform

    private int score = 0;                     // Initialized score of 0
    private int totalGems = 40;                // The total amount of gems the player has to collect
    private bool gameCompleted = false;        // Track if the game has been completed
    private bool playerFellOutOfWorld = false; // Track if the player fell past the bottom of the world

    // Start is called before the first frame update
    void Start()
    {
        // Initialize score text
        UpdateScoreText();
        exitObject.SetActive(false); // Ensure the exit is disabled at the start of the game
    }

    void Update()
    {
        // Check if the player has fallen below y = -9
        if (!playerFellOutOfWorld && player.position.y < -9)
        {
            DisplayFallMessage();
        }


        // Check for input of 'R' if the player has beaten the game or has fallen out of the world
        if ((gameCompleted || playerFellOutOfWorld) && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
        }
    }

    public void IncrementScore()
    {
        // Increase the score by 1 and update the text
        score++;
        UpdateScoreText();

        // Check if the player has collected all the gems
        if (score >= totalGems)
        {
            // Update score text to show completion message
            scoreText.text = "You collected all of the gems!\nHead for the exit!";
            exitObject.SetActive(true); // Enable exit
        }
    }

    private void UpdateScoreText()
    {
        // Update the score text with the currently collected gem count
        scoreText.text = "Score: " + score.ToString() + " \n(40 to collect)";
    }

    public void DisplayRestartMessage()
    {
        scoreText.text = "You win!\nPress R to play again!";
        gameCompleted = true;
    }

    private void DisplayFallMessage()
    {
        scoreText.text = "You fell through the world!\nPress R to retry!";
        playerFellOutOfWorld = true;
    }
}
