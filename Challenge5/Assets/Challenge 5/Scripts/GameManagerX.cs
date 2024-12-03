/*
* John Nguyen
* GameManagerX.cs
* Assignment 8 - Challenge 5
* This file covers all of the on-screen UI elements, as well as manages all of the different aspects of gameplay.
* Added was the timer display (60 seconds down to 0, with text on-screen).
* Changed was the difficulty being passed over to the game manager from the DifficultyButtonX.cs script, so now the game manager changes the spawn rate based on
* the difficulty that the player chose at the title screen.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerX : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timerText; // ADDED: Timer display
    public GameObject titleScreen;
    public Button restartButton; 

    public List<GameObject> targetPrefabs;

    private int score;
    private float spawnRate = 1.5f;
    public bool isGameActive;

    private float spaceBetweenSquares = 2.5f; 
    private float minValueX = -3.75f; //  x value of the center of the left-most square
    private float minValueY = -3.75f; //  y value of the center of the bottom-most square

    private int timeRemaining = 60; // ADDED: Countdown time in seconds
    
    // Start the game, remove title screen, reset score, and adjust spawnRate based on difficulty button clicked
    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty; // ALTERTED: Difficulty buttons now adjust the spawnRate of prefabs
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        titleScreen.SetActive(false);

        timeRemaining = 60; // ADDED: Reset the timer when the scene is started/restarted
        StartCoroutine(CountdownTimer()); // ADDED: Start the countdown when the game has begun
    }

    // While game is active spawn a random target
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);

            if (isGameActive)
            {
                Instantiate(targetPrefabs[index], RandomSpawnPosition(), targetPrefabs[index].transform.rotation);
            }
            
        }
    }

    // Generate a random spawn position based on a random index from 0 to 3
    Vector3 RandomSpawnPosition()
    {
        float spawnPosX = minValueX + (RandomSquareIndex() * spaceBetweenSquares);
        float spawnPosY = minValueY + (RandomSquareIndex() * spaceBetweenSquares);

        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, 0);
        return spawnPosition;

    }

    // Generates random square index from 0 to 3, which determines which square the target will appear in
    int RandomSquareIndex()
    {
        return Random.Range(0, 4);
    }

    // Update score with value from target clicked
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    // ADDED: Countdown timer coroutine
    IEnumerator CountdownTimer()
    {
        while (timeRemaining > 0 && isGameActive)
        {
            yield return new WaitForSeconds(1); // Wait for the next frame
            timeRemaining--; // Decrement/subtract 1 second
            timerText.text = "Time: " + timeRemaining; // Update timer text as time counts down
        }

        if (timeRemaining <= 0)
        {
            GameOver();
        }
    }

    // Stop game, bring up game over text and restart button
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    // Restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
