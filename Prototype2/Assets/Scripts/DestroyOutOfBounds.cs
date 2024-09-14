using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 20;
    public float bottomBound = -10;

    // Update is called once per frame
    void Update()
    {
        // if food goes out of bounds, topBound
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }

        // if animal goes out of bounds, bottomBound
        if (transform.position.z < bottomBound)
        {
            Debug.Log("Game Over!");

            Destroy(gameObject);
        }
    }
}
