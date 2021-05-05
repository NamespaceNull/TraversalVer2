using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ire : MonoBehaviour
{
    public int setDrag = 25;
    public bool inIre = false;
    public float ireBurst = 10f;
    public GameObject player;
    private Rigidbody playerRB;

    void Start() {
        playerRB = player.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            inIre = true;
            playerRB.drag = setDrag;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            inIre = false;
            playerRB.drag = 0;
        }
    }

    void Update() {
        if (inIre) {
            if (Input.GetKeyDown(KeyCode.W)) {
                playerRB.AddForce(new Vector3(0, ireBurst, 0), ForceMode.Impulse);
            }
        }
    }
}
