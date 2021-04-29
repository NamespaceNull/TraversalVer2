using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleek : MonoBehaviour
{
    // what the player's mass will be while in the sleek \\
    public float massInSleek = 0.75f;

    // checking if the player is in the sleek \\
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.mass = massInSleek;
        }
    }

    // reverting changes once the player leaves the sleek \\
    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.mass = 1;
        }
    }
}