/*
* John Nguyen
* Golem.cs
* Assignment 5B - 3D Prototype with ProBuilder
* From Follow Along video. Unchanged.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Enemy
{
    protected int damage;

    protected override void Awake()
    {
        base.Awake();
        health = 120;
        GameManager.Instance.score += 2;
    }

    protected override void Attack(int amount)
    {
        Debug.Log("Golem attacks!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TakeDamage(float amount)
    {
        Debug.Log("You took " + amount + " points of damage!");
    }
}
