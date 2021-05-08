using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goop2D : MonoBehaviour
{
// the player's mass will be when interacting with the goop \\
    public float massInGoop = 1.25f;
    // the liquid will still have an effect on the player after moveTimer miliseconds \\
    private GameObject player;
    private Rigidbody2D playerRB;
    private float moveTimer = 1000f;

    // grabbing the player object and rigidbody \\
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
    }

    // checking if the player enters the goop \\
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            playerRB.mass = massInGoop;
            StopAllCoroutines();
        }
    }

    // reverting the player mass back when they leave the goop
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            StartCoroutine("timer");
        }
    }

    // timer coroutine to slowly revert the changes made to the player mass \\
    IEnumerator timer() {
        for (int i = 0; i < moveTimer; i++) {
            playerRB.mass -= (massInGoop - 1) / moveTimer;
            yield return null;
        }
        // if the player mass isn't exactly 1 by the end, make it so \\
        if (playerRB.mass != 1) {
            playerRB.mass = 1;
        }
    }
}
