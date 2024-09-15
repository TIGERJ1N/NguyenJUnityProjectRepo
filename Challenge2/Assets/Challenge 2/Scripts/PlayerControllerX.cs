/*
    * John Nguyen
    * PlayerControllerX.cs
    * Assignment 3 - Challenge2
    * This PlayerControllerX script, which allows the player to send dogs out from their player model when the space bar is pressed down
    * Added in this player controller script is a cooldown timer of 2 seconds after a dog has been sent out
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    bool dogSentCoolDown = false; // Added: Game starts with player having NOT sent a dog yet -- cooldown off

    // Update is called once per frame
    void Update()
    {
        if (dogSentCoolDown == false) { // Added: Check if cooldown is off, if cooldown IS off, send a dog. If not, don't send a dog.
            if (Input.GetKeyDown(KeyCode.Space))
                {
                    Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

                    // Added: Start the dogCoolDown() coroutine after sending a dog out
                    dogSentCoolDown = true;
                    StartCoroutine(dogCoolDown());
            }
        }
    }

    // Added: dogCoolDown() coroutine, called by Update() above when a dog has been sent out
    IEnumerator dogCoolDown()
    {
        yield return new WaitForSeconds(2.0f); // if a dog was recently sent out -- wait 2 seconds before allowing another dog

        dogSentCoolDown = false; // set the cooldown to off, allowing another dog to be sent
    }
}
