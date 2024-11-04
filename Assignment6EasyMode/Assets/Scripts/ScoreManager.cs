/*
* John Nguyen
* ScoreManager.cs
* Assignment 5B - 3D Prototype with ProBuilder
* This is the ScoreManager script. It manages the on-screen UI text by linking with the Target.cs and YouWinTriggerZone scripts.
* This script in particular tracks the current game state (targets destroyed). If all 30 targets are destroyed, then the game is considered "over" at that time.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool won;
    public static int targetsHit;
    public static bool displayWinMessage;

    public Text textbox;

    private void Start()
    {
        gameOver = false;
        won = false;
        targetsHit = 0;
        displayWinMessage = false;

        textbox.text = "Targets Hit: " + targetsHit + "/30";
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver && !displayWinMessage)
        {
            textbox.text = "Targets Hit: " + targetsHit + "/30";
        }

        if (targetsHit >= 30 && !gameOver)
        {
            won = true;
            gameOver = true;
            textbox.text = "All targets hit!\nGet to the end!";
        }
    }
}
