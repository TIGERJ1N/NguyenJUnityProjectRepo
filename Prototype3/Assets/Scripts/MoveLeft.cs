/*
* John Nguyen
* MoveLeft.cs
* Assignment 4 - Prototype 3
* This is the MoveLeft script, which allows the background and obstacles contained in the game scene to move left past the player's model.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30f;
    private float leftBound = -15;

    // Add reference to playerControllerScript
    private PlayerController playerControllerScript;

    private void Start()
    {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        // Destroy obstacles out of bounds when they exit screen left
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
