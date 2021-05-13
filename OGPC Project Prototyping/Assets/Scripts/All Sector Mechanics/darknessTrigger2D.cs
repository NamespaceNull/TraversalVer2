using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class darknessTrigger2D : MonoBehaviour
{
    public bool turnDark = true; // true if the trigger turns the environment dark, false if the opposite
    public GameObject manager;
    public static bool dark = false;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            // if the trigger turns the setting dark \\
            if (turnDark) {
                if (other.gameObject.transform.position.x < gameObject.transform.position.x) {
                    StartCoroutine(manager.GetComponent<darknessManager>().fadeToDark());
                    dark = true;
                }    
                else if (other.gameObject.transform.position.x > gameObject.transform.position.x) {
                    StartCoroutine(manager.GetComponent<darknessManager>().fadeToLight());
                    dark = false;
                } 
            }
            // if the trigger turns the setting light \\
            else {
                if (other.gameObject.transform.position.x > gameObject.transform.position.x) {
                    StartCoroutine(manager.GetComponent<darknessManager>().fadeToDark());
                    dark = true;
                }    
                else if (other.gameObject.transform.position.x < gameObject.transform.position.x) {
                    StartCoroutine(manager.GetComponent<darknessManager>().fadeToLight());
                    dark = false;
                } 
            }
        }
    }
}
