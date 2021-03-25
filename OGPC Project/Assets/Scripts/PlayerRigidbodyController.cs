using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigidbodyController : MonoBehaviour
{ 
    /*
        for this to work you need to change the game gravity to -19.62 
    */  
    
    // main variables \\
    public Rigidbody rb;
    // movement variables \\
    public float speed = 7f;
    // jump variables \\
    private Vector3 jump;
    public float jumpForce = 5f;
    public bool isGrounded = true;
    // gliding variables \\
    public bool isGliding = false;
    public int drag = 15;
    // wall stick variables \\
    public bool isStick = false;
    public float wallJumpForce = 15f;

    // getting necessary variables at the start of the program \\
    void Start() {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0f, 2f, 0f);
    }

    // where most of the code is going to be \\
    void Update() {

        // basic left and right player movement controls \\
        // the act of moving the player across the screen
        float mH = Input.GetAxis("Horizontal");
        if (isStick == false) {
            rb.velocity = new Vector3(mH * speed, rb.velocity.y, 0f);
        }

        // player jump 
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            // if the player is still parented to a moving wall, unparent them
            if (transform.parent) {
                transform.parent = null;
            }
        }

        // gliding mechanic \\
        // checking if the player can glide
        if (Input.GetKey(KeyCode.W) && isGrounded == false) {
            isGliding = true;
        }
        else {
            isGliding = false;
        }
        // if the player is gliding, increase their drag to slow their descent 
        if (isGliding && isStick == false) {
            rb.drag = drag;
        }
        else {
            rb.drag = 0;
        }

        // player wall stick and jump mechanic \\
        if (isStick) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                // make the player wall jump and un-stick them from the wall
                rb.AddForce(jump * wallJumpForce, ForceMode.Impulse);
                isStick = false;
                // if the player was parented to a moving wall, unparent them
                if (transform.parent) {
                    transform.parent = null;
                }
            }
        }
        // if the player lets go of the 'W' key or isStick is false for some reason, reset isStick and useGravity
        if (Input.GetKeyUp(KeyCode.W) || isStick == false) {
            isStick = false;
            rb.useGravity = true;
        }
    }

    // if the player stays on the ground for some time, let them jump again \\
    void OnCollisionEnter(Collision hit) {
        // player collision with the ground and platforms
        if (hit.gameObject.tag == "Ground" || hit.gameObject.tag == "Platform") {
            isGrounded = true;
            isGliding = false;
        }
        // player collision with walls and moving walls
        if (hit.gameObject.tag == "Moving Wall" || hit.gameObject.tag == "Wall") {
            if (Input.GetKey(KeyCode.W)) {
                rb.useGravity = false;
                isStick = true; 
            }
        }
        // if the player collides with a moving wall, parent them to the wall to allow them to move with it
        if (hit.gameObject.tag == "Moving Wall") {
            gameObject.transform.parent = hit.gameObject.transform;
        }
    }

}
