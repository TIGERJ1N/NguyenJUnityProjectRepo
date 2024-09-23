/*
* John Nguyen
* ScoreManager.cs
* Assignment 4 - Challenge 3
* This is the score manager script, which helps the game detect when the player has run into money (incrementing score) and
* bombs (causes a gameover). It also displays text on-screen notifying the player of the current game state, allowing players to 
* restart the game if they wish.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;

    public PlayerControllerX playerControllerScript;

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
            playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerX>();
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

        // Win Condition (10 points):
        if (score >= 10)
        {
            playerControllerScript.gameOver = true;
            won = true;

            scoreText.text = "You win!" + "\n" + "Press R to Try Again!";
        }

        // Loss Condition (hit bomb):
        if (playerControllerScript.gameOver && !won)
        {
            scoreText.text = "You Lose!" + "\n" + "Press R to Try Again!";
        }

        // Press R to restart if game is over
        if (playerControllerScript.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
