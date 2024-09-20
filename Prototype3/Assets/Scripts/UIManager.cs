/*
* John Nguyen
* UIManager.cs
* Assignment 4 - Prototype 3
* This is the UI manager script, which sets up the Score text in the top left with conditions made to change the text if the player wins the game
* by achieving 10 points, or lose the game if they run into an obstacle. Also allows the player to restart the game when 'R' is pressed.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    public PlayerController playerControllerScript;

    public bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        if (scoreText == null)
        {
            scoreText = FindObjectOfType<Text>();
        }

        if (playerControllerScript == null)
        {
            playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        // Display score until game is over
        if (!playerControllerScript.gameOver)
        {
            scoreText.text = "Score: " + score;
        }

        // Loss Condition: Hit an obstacle (even once)
        if (playerControllerScript.gameOver && !won)
        {
            scoreText.text = "You lose!" + "\n" +
                             "Press R to Try Again!";
        }

        // Win Condition: 10 points
        if (score >= 10)
        {
            playerControllerScript.gameOver = true;
            won = true;

            // Stop player running
            //playerControllerScript.StopRunning();

            scoreText.text = "You win!" + "\n" +
                             "Press R to Try Again!";
        }

        // Press R to restart if game is over
        if (playerControllerScript.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
