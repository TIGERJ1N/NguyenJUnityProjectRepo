/*
* John Nguyen
* RepeatBackground.cs
* Assignment 4 - Prototype 3
* This is the repeat background script, which ensures that the background is able to "repeat" by slicing the pre-made background in two, and
* repositioning it back to it's original starting point when the middle of it passes the player (creating a "looping" background).
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        // Save the starting position of the background to a Vector3 variable
        startPosition = transform.position;

        // Set the repeatWidth to half of the width of the background using the BoxCollider
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // If the background is further to the left than the repeatWidth, reset it to its start position
        if (transform.position.x < startPosition.x - repeatWidth)
        {
            transform.position = startPosition;
        }
    }
}
