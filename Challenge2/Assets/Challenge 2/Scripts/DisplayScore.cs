/*
    * John Nguyen
    * DisplayScore.cs
    * Assignment 3 - Challenge2
    * This is the DisplayScore script which updates the player's score with text every time a ball is caught by a dog
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Text textbox;

    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Set text component reference on start
        textbox = GetComponent<Text>();
        textbox.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        // Update the Score text for every time a ball is caught by a dog.
        textbox.text = "Score: " + score;
    }
}
