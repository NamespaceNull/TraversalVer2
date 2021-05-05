using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public int maxTimer = 2000;
    private int timer;
    public bool changeDirection = true;
    public int speed = 2;

    // have the timer equal to the max timer given
    void Start() {
        timer = maxTimer;
    }
    // Update is called once per frame
    void Update()
    {
        if (changeDirection) {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            timer--;
            if (timer <= 0) {
                changeDirection = false;
                timer = maxTimer;
            }
        }
        else {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
            timer--;
            if (timer <= 0) {
                changeDirection = true;
                timer = maxTimer;
            }
        }
    }
}
