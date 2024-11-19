/*
* John Nguyen
* GameManager.cs
* Assignment 7 - Challenge 4
* This is the game manager script. It tracks the UI elements for the game as well as game completion status.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text winLossText; // Reference to the win/loss UI text
    public Text startText;   // Reference to the start text
    public Text waveText;

    public bool gameActive = false;
    private int enemiesThroughGoal = 0;
    private int maxEnemies = 1; // Set the limit for the loss condition
    public int currentWave = 1;

    private bool hasGameStarted = false;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        winLossText.gameObject.SetActive(false);
        waveText.gameObject.SetActive(false);
        startText.text = "To complete a wave, get all of the balls into the other net!\n" +
            "If all of the balls get into your net, you'll lose!\n" +
            "To win, get past Wave 10!\n" +
            "\nPress Space to Start";
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameActive && Input.GetKeyDown(KeyCode.Space))
        {
            gameActive = true;
            hasGameStarted = true;
            startText.gameObject.SetActive(false); // Hide start text
            waveText.gameObject.SetActive(true);   // Show wave text
            Time.timeScale = 1;
        }

        if (currentWave > 10)
        {
            GameOver("You win! Press R to Restart!");
        }

        if (enemiesThroughGoal >= maxEnemies)
        {
            GameOver("You Lose! Press R to Restart!");
        }

        if (isGameOver && Input.GetKeyDown(KeyCode.R)) // Need to make sure that the player can't just spam R to restart game... GameOver && Input??
        {
            RestartGame();
        }
    }

    public void EnemyPassedGoal()
    {
        enemiesThroughGoal++;

        if (enemiesThroughGoal >= maxEnemies)
        {
            GameOver("You Lose! Press R to Restart!");
        }
    }

    public void StartNewWave()
    {
        enemiesThroughGoal = 0;
        maxEnemies = currentWave;
        waveText.text = "Wave: " + currentWave;
        currentWave++;
    }

    public void GameOver(string message)
    {
        winLossText.text = message;
        winLossText.gameObject.SetActive(true);
        gameActive = false;
        isGameOver = true;
        Time.timeScale = 0; // Freeze the game world on game over
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Ensure game resumes on restart
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        hasGameStarted = false;
        isGameOver = false;
    }
}
