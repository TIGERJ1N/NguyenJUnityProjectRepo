﻿/*
* John Nguyen
* PlayerControllerX.cs
* Assignment 4 - Challenge 3
* This is the player controller script, pre-provided by the challenge package. 
* 
* Additions to this script include:
*   Allowing access to the rigidbody and the score manager, adding a "isLowEnough" condition to check the height of balloon before 
*   letting players ascend, incrementing score if the player collides with money, and playing a "bounce" sound when the player hits the 
*   bottom of the screenspace.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    // Added: a bouncy sound to the balloon when it bounces off of the invisible bouncy floors
    public AudioClip bouncySound;

    // Added (Start()): a boolean that checks if the player is "low enough", if they are, they can continue to float upwards
    private bool isLowEnough;

    // Added: Adds access to the score component, allowing collisions with money to increment score
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        // Allow the script to access rigidbody so player can float up when spacebar is pressed
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

        // Added: The boolean to check whether the player is low enough from the top of the screen for them to float upwards
        isLowEnough = true;

        scoreManager = GameObject.FindObjectOfType<ScoreManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerRb.position.y > 15)
        {
            isLowEnough = false;
        } else
        {
            isLowEnough = true;
        }

        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            if (isLowEnough == true) // Added/Adjusted: Check to see if the isLowEnough condition is true
            {
                playerRb.AddForce(Vector3.up * floatForce);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks, and increment score by one
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            scoreManager.score++;
            Destroy(other.gameObject);
        }

        // Added: if player collides with the invisible bouncy floor, they will be bounced upwards
        if (other.gameObject.CompareTag("InvisibleBouncyFloor") && !gameOver)
        {
            playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            playerAudio.PlayOneShot(bouncySound, 1.0f);
        }

    }

}
