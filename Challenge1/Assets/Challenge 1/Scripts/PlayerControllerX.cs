/*
 * John Nguyen
 * Assignment 2 - Challenge 1
 * Description of Code: Pre-written code for Challenge 1. Takes input from player, W or S, and rotates the plane upward and downward.
 *                      Has a few edits: Vector3.forward, and Time.deltaTime were changed/added.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * Time.deltaTime *speed);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput);
    }
}
