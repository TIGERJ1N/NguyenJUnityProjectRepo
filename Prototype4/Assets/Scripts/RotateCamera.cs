/*
* John Nguyen
* RotateCamera.cs
* Assignment 7 - Prototype 4
* This is the rotate camera script from the Follow Along. This went unchanged.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;
    

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
