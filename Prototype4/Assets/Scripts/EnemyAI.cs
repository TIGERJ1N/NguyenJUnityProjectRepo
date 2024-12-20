﻿/*
* John Nguyen
* EnemyAI.cs
* Assignment 7 - Prototype 4
* This is the enemy AI script from the follow along video. This went unchanged.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody enemyRb;
    public GameObject player;
    public float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        // Add force toward the direction from the player to the enemy


        // Vector for direction from enemy to player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        // Add force toward player
        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
