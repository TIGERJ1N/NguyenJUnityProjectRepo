/*
 * John Nguyen
 * ScoreManager.cs
 * Assignment 2 - Challenge 1
 * Description of Code: Manages the game over state, the win state, and the score, as well as outputs the correct win/loss text depending on
 *                      the aforementioned conditions.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    // Declarations of booleans and an int to track game over status, win status, and score
    public static bool gameOver;
    public static bool won;
    public static int score;

    public Text textbox;

    // Initialized values for game over status, win status, and score
    private void Start()
    {
        gameOver = false;
        won = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Displays score text so long as the game isn't over (conditions for "over" state below)
        if(!gameOver)
        {
            textbox.text = "Score: " + score;
        }

        // Win condition of 5 points
        if(score >= 5)
        {
            won = true;
            gameOver = true;
        }

        // If the player has gotten 5 points or has gone out of bounds (LoseOnOutOfBounds.cs), the game is "over" and can be restarted
        if(gameOver)
        {
            if (won)
            {
                textbox.text = "You win!\nPress R to try again!";
            }
            else
            {
                textbox.text = "You lose!\nPress R to try again!";
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }
}
