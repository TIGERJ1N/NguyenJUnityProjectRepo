using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput; // get's horizontal input
    public float speed = 10.0f; // for player's speed
    private float xRange = 14; // for boundary

    void Update()
    {
        // Get horizontal input
        horizontalInput = Input.GetAxis("Horizontal");

        // Transform horizontally with input
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);


        // Keep player in bounds
        if (transform.position.x < -xRange) // left-bound
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange) // right-bound
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}
