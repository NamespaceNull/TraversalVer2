using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumenLight : MonoBehaviour
{
    // important variables \\
    public Transform player;
    public Light lightThing;
    public float intensityAmount = 5;
    public int distanceBeforeLight = 9;

    // getting the light component \\
    void Start() {
        lightThing = GetComponent<Light>();
    }

    // gets the distance from the lumen light to the player
    // once gotten the distance, change the intensity of the light depending on the distance
    void Update()
    {
        // get the distance 
        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);

        // change the intensity
        if (distance < distanceBeforeLight) {
            lightThing.intensity = intensityAmount - distance;
        }
        else {
            lightThing.intensity = 0f;
        }
    }
}
