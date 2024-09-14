using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach to food projectile prefab
public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) // other will be the animal that we hit with our food object
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
