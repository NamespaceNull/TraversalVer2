using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigidbodyController2Dver2 : MonoBehaviour
{ 
    /*
        for this to work you need to change the game gravity to -19.62 
    */  
    
    // main variables \\
    public Rigidbody2D rb;
    // movement variables \\
    public float speed = 7f;
    public float fullGravity = 1.2f;
    public int speedFactor = 2;
    public float ireBurst = 10f;
    public bool inIre = false;
    // jump variables \\
    private Vector2 jump;
    public float jumpForce = 10f;
    public bool isGrounded = true;
    // gliding variables \\
    public bool isGliding = false;
    public int drag = 15;
    // wall stick variables \\
    public bool isStick = false;
    public float wallJumpForce = 15f;
    public int contactQuantity = 0;
    public string previousStuckWall = "";


    // getting necessary variables at the start of the program \\
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        //jump = new Vector3(0f, 2f, 0f);
        jump = new Vector2(0f, 2f);
    }

    // where most of the code is going to be \\
    void Update() {

        // basic left and right player movement controls \\
        // the act of moving the player across the screen
        float mH = Input.GetAxis("Horizontal");
        if (!isStick) {
            rb.velocity = new Vector2(mH * speed, rb.velocity.y);
        }

        // player jump 
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            //rb.AddForce
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            // if the player is still parented to a moving wall, unparent them
            if (transform.parent) {
                transform.parent = null;
            }
        }

        // gliding mechanic \\
        // checking if the player can glide
        if (Input.GetKey(KeyCode.W) && !isGrounded) {
            isGliding = true;
        }
        else {
            isGliding = false;
        }
        // if the player is gliding, increase their drag to slow their descent 
        if (isGliding && !isStick) {
            rb.drag = drag;
        }
        else {
            if (!inIre) {
                rb.drag = 0;
            }
        }

        // player wall stick and jump mechanic \\
        if (isStick) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                // make the player wall jump and un-stick them from the wall
                rb.AddForce(jump * wallJumpForce, ForceMode2D.Impulse);
                isStick = false;
            }
        }
        // if the player lets go of the 'W' key or isStick is false for some reason, reset isStick and useGravity
        if (Input.GetKeyUp(KeyCode.W) || isStick == false) {
            isStick = false;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    // if the player stays on the ground for some time, let them jump again \\
    void OnCollisionEnter2D(Collision2D hit) {
        // shoot raycasts to the right, left, and down to check for collisions \\
        RaycastHit2D[] hitsRight = Physics2D.RaycastAll(transform.position, Vector2.right, 5);
        RaycastHit2D[] hitsLeft = Physics2D.RaycastAll(transform.position, Vector2.left, 5);
        RaycastHit2D[] hitsDown = Physics2D.RaycastAll(transform.position, Vector2.down, 2);

        // if the player touches the ground \\
        if (hitsDown.Length > 1) {
            if (hitsDown[1].collider.gameObject.tag == "Ground") {
                isGrounded = true;
                isGliding = false;
                previousStuckWall = "";
            }
        }
        // if the player touches a wall \\
        else {
            // if the player touches a wall to their right \\
            if (hitsRight.Length > 1) {
                if (hitsRight[1].collider.gameObject.tag == "Ground") {
                    // if the player previously stuck to a left-sided wall, let them stick to the right-sided wall
                    if (previousStuckWall == "Left" || previousStuckWall == "") {
                        if (Input.GetKey(KeyCode.W)) {
                            rb.constraints = RigidbodyConstraints2D.FreezePosition;
                            isGrounded = false;
                            isStick = true;
                            previousStuckWall = "Right";
                        }
                    }
                }          
            }
            // if the player touches a wall to their left \\
            if (hitsLeft.Length > 1) {
                if (hitsLeft[1].collider.gameObject.tag == "Ground") {
                    // if the player previously stuck to a right-sided wall, let them stick to the left-sided wall
                    if (previousStuckWall == "Right" || previousStuckWall == "") {
                        if (Input.GetKey(KeyCode.W)) {
                            rb.constraints = RigidbodyConstraints2D.FreezePosition;
                            isGrounded = false;
                            isStick = true;
                            previousStuckWall = "Left";
                        }
                    }
                } 
            }
        }
    }

    // making sure isGrounded is false when the player is in the air \\
    void OnCollisionExit2D(Collision2D hit) {
        if (hit.gameObject.tag == "Ground" || hit.gameObject.tag == "Platform") {
            isGrounded = false;
            isStick = false;
        }
    }

    // on trigger stuff that checks if the player is in goop
    // and changes the player speed accordingly \\
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "goop") {
			speed /= speedFactor;
		}
        else if (col.gameObject.tag == "sleek") {
            speed *= speedFactor;
        }
        if (col.gameObject.tag == "Ire") {
            inIre = true;
        }
        if (col.gameObject.tag == "Spring") {
            isGrounded = false;
        }
	}
    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "goop") {
            speed = 7f;
        }
        else if (col.gameObject.tag == "sleek") {
            speed = 7f;
        }
        if (col.gameObject.tag == "Ire") {
            inIre = false;
        }
    }

}
