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
    //private float spawnInterval = 4.0f; ... Commented out, as it's moved to the SpawnRandomBallWithDelay() coroutine

    // Start is called before the first frame update
    void Start()
    {
        // Comment out InvokeRepeating to instead use the coroutine
        //InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);

        // Start the coroutine to randomly spawn balls on a delay
        StartCoroutine("SpawnRandomBallWithDelay");
    }

    // Coroutine to spawn random balls on a delay
    IEnumerator SpawnRandomBallWithDelay()
    {
        yield return new WaitForSeconds(startDelay);

        while (true) // runs indefinitely until the program/game is ended
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

        // Pick a random ball
        int ballIndex = Random.Range(0, ballPrefabs.Length);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }

}
