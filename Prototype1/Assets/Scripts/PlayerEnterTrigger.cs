using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Attach this to the player
public class PlayerEnterTrigger : MonoBehaviour
{
    // Set this reference in the Inspector
    public Text textbox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerZone"))
        {
            textbox.text = "You win!";
        }
    }

}
