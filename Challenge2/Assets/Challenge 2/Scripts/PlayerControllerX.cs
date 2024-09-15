using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    bool dogSentCoolDown = false; // Game starts with player having NOT sent a dog yet -- cooldown off

    // Update is called once per frame
    void Update()
    {
        if (dogSentCoolDown == false) { // Check if cooldown is off, if cooldown IS off, send a dog. If not, don't send a dog.
            if (Input.GetKeyDown(KeyCode.Space))
                {
                    Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

                    // Start the dogCoolDown() method after sending a dog out
                    dogSentCoolDown = true;
                    StartCoroutine(dogCoolDown());
            }
        }
    }

    IEnumerator dogCoolDown()
    {
        yield return new WaitForSeconds(2.0f); // if a dog was recently sent out -- wait 2 seconds before allowing another dog

        dogSentCoolDown = false; // set the cooldown to off, allowing another dog to be sent
    }
}
