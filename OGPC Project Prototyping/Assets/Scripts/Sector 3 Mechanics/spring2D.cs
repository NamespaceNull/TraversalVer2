using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spring2D : MonoBehaviour
{
    public float springForce = 2.25f;
    public GameObject player;
    private Rigidbody2D playerRB;

    // get the player rigidbody \\
    void Start() {
        playerRB = player.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Debug.Log("h");
            // get the player's velocity \\
            Vector3 vel = playerRB.velocity;

            // adding that velocity in the force times a multiplier in the opposite direction \\
            playerRB.AddForce(-vel * springForce, ForceMode2D.Impulse);
        }
    }
}
