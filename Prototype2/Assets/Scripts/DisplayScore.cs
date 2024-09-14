/*
    * John Nguyen
    * DisplayScore.cs
    * Assignment 3 - Prototype2
    * This is the display score script, which handles the displaying of score under the health system UI element.
    * It connects with DetectCollisions.cs to update the score text (textbox.text = "Score: " + score;) by 1 whenever a food projectile hits an animal
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
        textbox.text = "Score: " + score;
    }
}
