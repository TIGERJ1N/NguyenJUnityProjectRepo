/*
* John Nguyen
* HostileTarget.cs
* Assignment 5B - 3D Prototype with ProBuilder
* Added this to work on Step 2, first requirement. It overrides the IsHit() and OnHit() methods from IDamageable (implementation of interface).
* Also, this script has HostileTarget inheriting from class Target (completes first part of Step 2, Inheritance).
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileTarget : Target
{
    private void Awake()
    {
        health = 10f;
    }

    protected override void Die()
    {
        base.Die();
    }

    public override bool IsHit()
    {
        return health > 0;
    }

    public override void OnHit()
    {
        Debug.Log($"Hostile {gameObject.name} was hit! Current health: {health}");
    }
}
