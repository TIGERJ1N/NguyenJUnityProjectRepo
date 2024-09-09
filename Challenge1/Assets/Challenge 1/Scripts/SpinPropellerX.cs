/*
 * John Nguyen
 * Assignment 2 - Challenge 1
 * Description of Code: Spins the front propeller on the plane.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    // Applies a rate of rotation to the propeller
    private float propellerRotate = 50;

    // Update is called once per frame ... actually updates the propeller to spin
    void Update()
    {
        transform.Rotate(Vector3.forward * propellerRotate);
    }
}
