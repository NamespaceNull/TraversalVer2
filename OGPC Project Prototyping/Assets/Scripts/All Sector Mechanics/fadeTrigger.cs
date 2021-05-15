using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeTrigger : MonoBehaviour
{
    public static bool entered = false;

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            entered = true;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            entered = false;
        }
    }
}
