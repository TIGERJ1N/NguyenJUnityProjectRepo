/*
* John Nguyen
* DestroyObjectX.cs
* Assignment 8 - Challenge 5
* This file handles the destruction of prefab objects when 2 seconds have elapsed
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectX : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2); // destroy particle after 2 seconds
    }


}
