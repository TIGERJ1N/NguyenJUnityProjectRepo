/*
    * John Nguyen
    * MoveForward.cs
    * Assignment 3 - Prototype2
    * This is the move forward script, which allows the player's projectiles (the food prefabs) to move upward and the animals to move downwards at a constant speed
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
