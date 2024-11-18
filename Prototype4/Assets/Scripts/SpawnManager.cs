/*
* John Nguyen
* SpawnManager.cs
* Assignment 7 - Prototype 4
* This is the spawn manager script, which manages how enemies and powerups are spawned, the wave count, the game over state,
* and the game over state based on the wave count.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;

    public GameObject powerupPrefab;

    public int enemyCount;
    public int waveNumber = 1;

    // Reference to wave text
    public TextMeshProUGUI waveText;

    // Game Over Text Reference
    public TextMeshProUGUI gameOverText;

    // Track whether the game has actually started
    public TextMeshProUGUI startText;
    private bool gameStarted = false;

    // Track whether the game is over
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0; // Pause the game initially

        SpawnEnemyWave(waveNumber);
        SpawnPowerup(0);

        // Start up the wave text
        UpdateWaveText();
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            // Instantiate the enemy in the random position
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private void SpawnPowerup(int powerupsToSpawn)
    {
        for (int i = 0; i < powerupsToSpawn; i++)
        {
            // Instantiate the enemy in the random position
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        // Generating a random position on the platform
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            startText.gameObject.SetActive(false);
            Time.timeScale = 1; // Start/Resume the game
            gameStarted = true;
        }

        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        if (!gameStarted) return;

        if (isGameOver) return;

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup(1);
            UpdateWaveText();
        }

        // Win condition
        if (waveNumber > 10)
        {
            GameOver("You Win! Press R to Restart!");
            return;
        }
    }

    private void GameOver(string message)
    {
        isGameOver = true;
        Time.timeScale = 0; // Pause the game because of the loss
        DisplayGameOverMessage(message);
    }

    private void DisplayGameOverMessage(string message)
    {
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = message;
        waveText.gameObject.SetActive(false);
    }

    void UpdateWaveText()
    {
        waveText.text = $"Wave: {waveNumber}";
    }

    private void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
