using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public float springForce = 2.25f;
    public GameObject player;
    private Rigidbody playerRB;

    // get the player rigidbody \\
    void Start() {
        playerRB = player.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            // get the player's velocity \\
            Vector3 vel = playerRB.velocity;

            // adding that velocity in the force times a multiplier in the opposite direction \\
            playerRB.AddForce(-vel * springForce, ForceMode.Impulse);
        }
    }

}
