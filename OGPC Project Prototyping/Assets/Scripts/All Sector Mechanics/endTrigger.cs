using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endTrigger : MonoBehaviour
{
    public static bool end = false;

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            end = true;
        }
    }
}
