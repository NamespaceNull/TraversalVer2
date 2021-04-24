using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goop : MonoBehaviour
{
    // the player's mass will be when interacting with the goop
    public float massInGoop = 1.75f;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.mass = massInGoop;
        }
    }

    // reverting the player mass back when they leave the goop
    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.mass = 1;
        }
    }
} 
