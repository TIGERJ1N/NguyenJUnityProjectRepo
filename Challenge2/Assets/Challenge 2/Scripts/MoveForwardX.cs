/*
    * John Nguyen
    * MoveForwardX.cs
    * Assignment 3 - Challenge2
    * This is the MoveForwardX script, which is unchanged and imported as is from the Challenge2 package
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardX : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
