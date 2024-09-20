/*
* John Nguyen
* PlayerController.cs
* Assignment 4 - Prototype 3
* This file is the player controller for Prototype 3. It gives the player's character model a rigid body and the ability to jump, a set of animations,
* a set of particles (dirt) that plays as the character runs, and audio that plays when the player jumps or crashes into an obstacle.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public ForceMode jumpForceMode;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;

    // Player character animations
    public Animator playerAnimator;

    // Particles
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    // Sound effects (jump, crash)
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    void Start()
    {
        // Set a reference to our rigid body component
        rb = GetComponent<Rigidbody>();

        // Set a reference to our animator component
        playerAnimator = GetComponent<Animator>();

        // Set reference to audio source component
        playerAudio = GetComponent<AudioSource>();

        // Start running animation on start
        playerAnimator.SetFloat("Speed_f", 1.0f);

        jumpForceMode = ForceMode.Impulse;

        // Modify gravity -- Moved down, but kept here for future reference
        //Physics.gravity *= gravityModifier;

        if (Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Jumping when the player presses space
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, jumpForceMode);
            isOnGround = false;

            // Set the trigger to play the jump animation
            playerAnimator.SetTrigger("Jump_trig");

            // Stop playing dirt particle on jump
            dirtParticle.Stop();

            // Play jump sound effect
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            // Play dirt particle when the player hits the ground
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;

            // Play death animation
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);

            // Play explosion particle
            explosionParticle.Play();

            // Play crash sound effect
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
