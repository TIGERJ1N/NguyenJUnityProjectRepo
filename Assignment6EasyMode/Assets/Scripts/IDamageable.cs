/*
* John Nguyen
* IDamageable.cs
* Assignment 5B - 3D Prototype with ProBuilder
* From Follow Along video. Added IsHit() and OnHit() to perform the second part of Step 2 (Imeplementing an Interface).
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakeDamage(float amount);
    bool IsHit(); // New method to indicate if a target as hit
    void OnHit();
}
