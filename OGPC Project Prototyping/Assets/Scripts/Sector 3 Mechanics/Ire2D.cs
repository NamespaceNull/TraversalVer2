using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ire2D : MonoBehaviour
{
    // variables \\
    public int setDrag = 25;
    public bool inIre = false;
    public float ireBurst = 60f;
    public GameObject player;
    private Rigidbody2D playerRB;

    // at the start, find the player rigidbody component \\
    void Start() {
        playerRB = player.GetComponent<Rigidbody2D>();
    }

    // when the player enters the ire, set the drag to the setDrag \\
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            inIre = true;
            playerRB.drag = setDrag;
        }
    }

    // when the player exits, reset the drag \\
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            inIre = false;
            playerRB.drag = 0;
        }
    }

    // allow the player to burst upwards when they are in the ire \\
    void Update() {
        if (inIre) {
            if (Input.GetKeyDown(KeyCode.W)) {
                playerRB.AddForce(new Vector2(0, ireBurst), ForceMode2D.Impulse);
            }
        }
    }
}
