/*
    * John Nguyen
    * SpawnManagerX.cs
    * Assignment 3 - Challenge2
    * This is the SpawnManagerX script with the following changes:
    * ... spawnInterval was moved into a new coroutine called SpawnRandomBallWithDelay() + usage of InvokeRepeating() was removed as a result
    * ... SpawnRandomBallWithDelay() allows the program to pick a random float value between 3.0 and 5.0 to assign the spawning of a new ball (as long as the game is not over)
    * ... in SpawnRandomBall(), the only things that were changed were: creation of a ballIndex to pick a random ball from 3 kinds + create a ball in a random position using a randomly picked ball
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    //private float spawnInterval = 4.0f; ... Changed: Commented out, as it's moved to the SpawnRandomBallWithDelay() coroutine

    public HealthSystem healthSystem;

    // Start is called before the first frame update
    void Start()
    {
        // Changed: Comment out InvokeRepeating to instead use the coroutine
        //InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);

        // Added: Start the coroutine to randomly spawn balls on a delay
        StartCoroutine("SpawnRandomBallWithDelay");
    }

    // Added: Coroutine to spawn random balls on a delay
    IEnumerator SpawnRandomBallWithDelay()
    {
        yield return new WaitForSeconds(startDelay);

        while (!healthSystem.gameOver) // runs indefinitely until the program/game is ended
        {
            float spawnInterval = Random.Range(3.0f, 5.0f);

            SpawnRandomBall();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // Added: Pick a random ball
        int ballIndex = Random.Range(0, ballPrefabs.Length);

        // Changed: instantiate ball at random spawn location using a randomized ball from the prefabs
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }

}
