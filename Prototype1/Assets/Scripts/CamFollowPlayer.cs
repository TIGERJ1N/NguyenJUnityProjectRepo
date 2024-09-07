﻿/*
 * John Nguyen
 * Assignment 2 - Prototype 1
 * Allows the camera to follow the player object at a set distance and position behind the player model
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{

    public GameObject player;

    private Vector3 offset = new Vector3(0, 5, -10);

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
