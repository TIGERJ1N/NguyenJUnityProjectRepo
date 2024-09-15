/*
    * John Nguyen
    * SpawnManager.cs
    * Assignment 3 - Prototype2
    * This is the spawn manager, which randomly decides between 1.5 to 3.0 seconds when to spawn a new animal from the top of the screen so long as the game is not "over"
    *                                                           ^^ (float randomDelay = Random.Range(1.5f, 3.0f);)                                              ^^ (while (!healthSystem.gameOver))
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Set this array of references in the inspector
    public GameObject[] prefabsToSpawn;

    // Variables for Spawn Position
    private float leftBound = -14;
    private float rightBound = 14;
    private float spawnPosZ = 20;

    public HealthSystem healthSystem;

    // Update is called once per frame
    void Update()
    {
        // This if goes un-used because we moved a lot of things out of it in Steps 5 and 6.
        // if (Input.GetKeyDown(KeyCode.S))
        {
            // Step 1:
            // Spawn 0th prefab at top of screen
            // Instantiate(prefabsToSpawn[0], new Vector3(0, 0, 20), prefabsToSpawn[0].transform.rotation);

            // Step 2:
            // Pick a random index between 0 and the length of the array
            // int prefabIndex = Random.Range(0, prefabsToSpawn.Length);

            // Instantiate(prefabsToSpawn[prefabIndex], new Vector3(0, 0, 20), prefabsToSpawn[prefabIndex].transform.rotation);

            // Step 3:
            // Randomly generate index and spawn position

            // Generate index -- pick a random animal index
            // int prefabIndex = Random.Range(0, prefabsToSpawn.Length);

            // Generate spawn position -- pick a random position for the animal
            // Vector3 spawnPos = new Vector3(Random.Range(leftBound, rightBound), 0, spawnPosZ);

            // Spawn our animals
            // Instantiate(prefabsToSpawn[prefabIndex], spawnPos, prefabsToSpawn[prefabIndex].transform.rotation);

            // Step 4
            // SpawnRandomPrefab();
        }
    }

    // Step 5: add void Start() method so that the program continually spawns new animals ... First, the script must find the HealthSystem so that it is initialized
    private void Start()
    {
        // Get a reference to the health system script
        healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>(); ;

        // Step 5: InvokeRepeating() calls the method repeatedly: ("methodName", startDelay, spawnInterval);
        // InvokeRepeating("SpawnRandomPrefab", 2, 1.5f);

        // Step 6: We get rid of InvokeRepeating, instead using a Coroutine (SpawnRandomPrefabWithCoroutine()) to spawn the prefabs
        StartCoroutine(SpawnRandomPrefabWithCoroutine());

    }

    // Step 6: Create a new method, return type IEnumerator with yield return new WaitForSeconds(); to wait a few seconds at the start of the program before spawning prefabs
    IEnumerator SpawnRandomPrefabWithCoroutine()
    {
        // Add a three second delay before first spawning the prefabs
        yield return new WaitForSeconds(3f);

        while (!healthSystem.gameOver)
        {
            // Instead of copy-pasting, call the encapsulated method that was already written
            SpawnRandomPrefab();

            // Creates a randomized delay so that animals spawn with random timings
            float randomDelay = Random.Range(1.5f, 3.0f);

            // Wait for a random amount of seconds (1.5f, 3.0f) before continuing the while loop (wait some seconds to spawn another prefab)
            yield return new WaitForSeconds(randomDelay);
        }
    }

    // Step 4: Move all of the code from Step 3 down to it's own method, SpawnRandomPrefab()
    void SpawnRandomPrefab()
    {
        // The below comes from Step 3 above and is unchanged
        // Generate index -- pick a random animal index
        int prefabIndex = Random.Range(0, prefabsToSpawn.Length);

        // Generate spawn position -- pick a random position for the animal
        Vector3 spawnPos = new Vector3(Random.Range(leftBound, rightBound), 0, spawnPosZ);

        // Spawn our animals
        Instantiate(prefabsToSpawn[prefabIndex], spawnPos, prefabsToSpawn[prefabIndex].transform.rotation);
    }
}
