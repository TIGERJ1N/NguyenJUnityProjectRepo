/*
* John Nguyen
* SpawnManagerX.cs
* Assignment 4 - Challenge 3
* This is the spawn manager script, pre-provided by the challenge package. Only one change was made on line 24, which used to say "PrawnsObject"
* in the InvokeRepeating() method, but was changed to "SpawnObjects" to reflect the actual method's name to spawn objects.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;

    private PlayerControllerX playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval); // Fixed: Was "PrawnsObject" before, now "SpawnObjects"
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Spawn obstacles
    void SpawnObjects ()
    {
        // Set random spawn location and random object index
        Vector3 spawnLocation = new Vector3(30, Random.Range(5, 15), 0);
        int index = Random.Range(0, objectPrefabs.Length);

        // If game is still active, spawn new object
        if (!playerControllerScript.gameOver)
        {
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        }

    }
}
