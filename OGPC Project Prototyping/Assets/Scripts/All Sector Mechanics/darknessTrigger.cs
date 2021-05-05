using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class darknessTrigger : MonoBehaviour
{
    public bool turnDark = true; // true if the trigger turns the environment dark, false if the opposite
    public GameObject manager;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            // if the trigger turns the setting dark \\
            if (turnDark) {
                if (other.gameObject.transform.position.x < gameObject.transform.position.x) {
                    StartCoroutine(manager.GetComponent<darknessManager>().fadeToDark());
                }    
                else if (other.gameObject.transform.position.x > gameObject.transform.position.x) {
                    StartCoroutine(manager.GetComponent<darknessManager>().fadeToLight());
                } 
            }
            // if the trigger turns the setting light \\
            else {
                if (other.gameObject.transform.position.x > gameObject.transform.position.x) {
                    StartCoroutine(manager.GetComponent<darknessManager>().fadeToDark());
                }    
                else if (other.gameObject.transform.position.x < gameObject.transform.position.x) {
                    StartCoroutine(manager.GetComponent<darknessManager>().fadeToLight());
                } 
            }
        }
    }
}
