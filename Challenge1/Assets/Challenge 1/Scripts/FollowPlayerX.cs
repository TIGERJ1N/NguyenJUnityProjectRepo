/*
 * John Nguyen
 * Assignment 2 - Challenge 1
 * Description of Code: Positions the camera to the side of the plane.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    // Changes camera to be off to the side of the plane
    public GameObject plane;
    private Vector3 offset = new Vector3(30, 0, 10);

    // Update is called once per frame
    void Update()
    {
        transform.position = plane.transform.position + offset;
    }
}
