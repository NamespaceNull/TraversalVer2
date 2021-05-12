using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraZoomTrigger : MonoBehaviour
{
    // when the player enters the room \\
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            cameraZoom.zoomActive = true;
        }
    }
    // when the player exits the room
    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            cameraZoom.zoomActive = false;
        }
    }
}
