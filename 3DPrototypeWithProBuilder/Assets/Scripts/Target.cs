/*
* John Nguyen
* Target.cs
* Assignment 5B - 3D Prototype with ProBuilder
* This is the Target script. It manages any given enemy's health value so that, when it hits 0, the object this script is attached to "dies"/is destroyed.
* Slight edit here to link it to the ScoreManager script (increment targetsHit by 1 for each target destroyed).
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 30f; // Originally 50f, but now 30f to avoid repetitive stress injury on fingers

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        ScoreManager.targetsHit++;
        Destroy(gameObject);
    }
}
