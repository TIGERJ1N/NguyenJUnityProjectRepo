/*
    * John Nguyen
    * HealthSystem.cs
    * Assignment 3 - Challenge2
    * This is the health system script, which is largely pre-written to provide a health system UI with it's functions
    * This script also allows the player to restart the game when the game is over (either through a win or loss)
    *   There is also a leftover AddMaxHealth() function that can be used to increase the amount of total hearts the player has,
    *   however it goes unused in this Challenge
    * An addition that was made here was to allow the HealthSystem script to access the score integer variable in DisplayScore.cs, that way we could add a win condition to the game
*/

//This script is based on https://www.youtube.com/watch?v=3uyolYVsiWc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public int health;
    public int maxHealth;

    // Added: Access the DisplayScore script to check for score
    private DisplayScore displayScoreScript;

    public List<Image> hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public bool gameOver = false;

    public GameObject winText; // Added: Created a new win text object to be displayed when the player wins
    public GameObject gameOverText;

    private void Start()
    {
        displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>(); // Added: access DisplayScore script
    }

    void Update()
    {
        //If health is somehow more than max health, set health to max health
        if (health > maxHealth)
        {
            health = maxHealth;
        }


        for (int i = 0; i < hearts.Count; i++)
        {
            //Display full or empty heart sprite based on current health
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            //Show the number of hearts equal to current max health
            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        // Added: Add a win condition here in health system, giving it access to the score variable in DisplayScore.cs
        if (GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>().score >= 5)
        {
            gameOver = true;
            winText.SetActive(true); // Added: creation of a win text to be displayed when the player wins the game

            //Press R to restart if game is over
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (health <= 0)
        {
            gameOver = true;
            gameOverText.SetActive(true);

            //Press R to restart if game is over
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }

    public void TakeDamage()
    {
        health--;
    }

    public void AddMaxHealth()
    {
        maxHealth++;
    }


}
