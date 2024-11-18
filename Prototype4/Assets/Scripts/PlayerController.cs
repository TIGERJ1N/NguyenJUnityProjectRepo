/*
* John Nguyen
* PlayerController.cs
* Assignment 7 - Prototype 4
* This is the player controller script that manages the players movement in the game.
* It also tracks the game over state (based on whether or not the player fell off the platform) and how collisions work with other objects.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed;
    private float forwardInput;

    private GameObject focalPoint;

    public bool hasPowerup;
    private float powerupStrength = 15.0f;
    public GameObject powerupIndicator;

    // Float for fall threshold (failure condition)
    private float fallThreshold = -10f;

    // Game Over Text, Wave Text references
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI waveText;

    private bool isGameOver = false; // Track whether the game is over

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.FindGameObjectWithTag("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");

        // Move our powerup indicator to the ground below our player
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if (transform.position.y < fallThreshold)
        {
            GameOver("You Lose! Press R to Restart!");
            waveText.gameObject.SetActive(false);
        }

        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    private void FixedUpdate()
    {
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);

            StartCoroutine(PowerupCountdownRoutine());

            powerupIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Debug.Log("Player collided with: " + collision.gameObject.name + " with powerup set to " + hasPowerup);

            // Get a local reference to the enemy rigidbody
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            // Set a Vector3 with a direction away from the player
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;

            // Add force away from player
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    // GameOver function to show the player that they've lost by falling off the sides
    private void GameOver(string message)
    {
        isGameOver = true;
        Debug.Log(message);
        Time.timeScale = 0; // Pause the game because of the loss
        DisplayGameOverMessage(message);
    }

    private void DisplayGameOverMessage(string message)
    {
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = message;
    }

    void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0); // Reload the scene
    }
}
