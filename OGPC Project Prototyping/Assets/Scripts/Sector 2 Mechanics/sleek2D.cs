using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleek2D : MonoBehaviour
{
    // what the player's mass will be while in the sleek \\
    public float massInSleek = 0.75f;
    // the liquid will still have an effect on the player after moveTimer miliseconds \\
    private GameObject player;
    private Rigidbody2D playerRB;
    private float moveTimer = 1000f;

    // getting the player object and rigidbody \\
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
    }

    // checking if the player is in the sleek \\
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            playerRB.mass = massInSleek;
            StopAllCoroutines();
        }
    }

    // reverting changes once the player leaves the sleek \\
    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            StartCoroutine("timer");
        }
    }

    // timer coroutine to slowly revert the changes made to the player mass \\
    IEnumerator timer() {
        for (int i = 0; i < moveTimer; i++) {
            playerRB.mass += (1 - massInSleek) / moveTimer;
            yield return null;
        }
        // if the player mass isn't exactly 1 by the end, make it so \\
        if (playerRB.mass != 1) {
            playerRB.mass = 1;
        }
    }
}
