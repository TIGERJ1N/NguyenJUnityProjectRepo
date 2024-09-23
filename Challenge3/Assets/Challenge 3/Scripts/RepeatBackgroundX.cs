/*
* John Nguyen
* RepeatBackgroundX.cs
* Assignment 4 - Challenge 3
* This is the repeat background script, preprovided by the challenge package. The only thing that was changed was line 20, which dealt with how the
* background was sliced so that it would repeat as it moved left past the balloon (from .size.y to .size.x).
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroundX : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;

    private void Start()
    {
        startPos = transform.position; // Establish the default starting position 
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; // Set repeat width to half of the background
    }

    private void Update()
    {
        // If background moves left by its repeat width, move it back to start position
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }

 
}


