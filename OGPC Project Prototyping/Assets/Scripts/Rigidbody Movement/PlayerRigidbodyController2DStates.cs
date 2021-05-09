using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigidbodyController2DStates : MonoBehaviour
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
    // ire variables \\
    public float ireBurst = 14f;
    // jump variables \\
    private Vector2 jump;
    public float jumpForce = 10f;
    // gliding variables \\
    public int drag = 15;
    // wall stick variables \\
    public float wallJumpForce = 15f;

    public ContactPoint2D[] contactPoints;
    public bool collided = false;

    public bool grounded;
    public bool airborne;
    public bool gliding;
    public bool sticking;
    public bool swimming;


    // getting necessary variables at the start of the program \\
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        //jump = new Vector3(0f, 2f, 0f);
        jump = new Vector2(0f, 1f);
    }

    // where most of the code is going to be \\
    void Update() {

        // lateral desired movement \\
        float lateral = Input.GetAxis("Horizontal");
        bool key_space = Input.GetKey(KeyCode.Space);
        bool key_w = Input.GetKey(KeyCode.W);

        if (contactPoints.Length == 0 || !collided) {
            grounded = false;
            airborne = true;
            gliding = key_w;
            sticking = false;
            swimming = false;
        }
        else {
            int lowerContactCount = 0;
            int upperContactCount = 0;
            int sideContactCount = 0;
            for(int i = 0; i < contactPoints.Length; i++) {
                if (contactPoints[i].point.y - (transform.position.y - 0.45) < 0) {
                    lowerContactCount++;
                }
                else if (contactPoints[i].point.y - (transform.position.y + 0.45) > 0) {
                    upperContactCount++;
                }
                else {
                    sideContactCount++;
                }
            }

            
            if (lowerContactCount > 0) { // only any lower contact points \\
                grounded = true;
                airborne = false;
                gliding = false;
                sticking = false;
                swimming = false;
            } 
            else if (sideContactCount == 0) { // only upper contact points and no lower contact points \\
                grounded = false;
                airborne = true;
                gliding = key_w;
                sticking = false;
                swimming = false;
            } 
            else if (sideContactCount > 0) { // contains some side contact points and no lower contact points \\
                grounded = false;
                airborne = false;
                gliding = false;
                sticking = true;
                swimming = false;
            }

        }

        rb.drag = 0;
        rb.gravityScale = fullGravity;

        if (!sticking) rb.velocity = new Vector2(lateral * speed, rb.velocity.y);
        if (grounded && key_space) rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
        if (gliding) rb.drag = drag;
        //if (sticking) rb.gravityScale = 0;
        if (sticking && key_space) rb.AddForce(jump * wallJumpForce, ForceMode2D.Impulse);


        /*

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
            rb.gravityScale = fullGravity;
        }

        */
    }


    // these here is because the walls and ground are the same thing
    void OnCollisionStay2D(Collision2D hit)
    {

        contactPoints = hit.contacts;




        /*
        int contactQuantity = hit.contactCount;
        int goodPointCount = 0;

        for (int i = 0; i < contactQuantity; i++)
        {
            if (hit.GetContact(i).point.y - (transform.position.y - 0.45) < 0)
            {
                goodPointCount++;
            }
        }

        if (goodPointCount == contactQuantity)
        {
            isGrounded = true;
            isGliding = false;
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.gravityScale = 0;
                isGrounded = false;
                isStick = true;
            }
            else
            {
                isGrounded = false;
                isStick = false;
            }
        }
        */
    }


    // if the player stays on the ground for some time, let them jump again \\
    void OnCollisionEnter2D(Collision2D hit) {

        collided = true;

        /*
        int contactQuantity = hit.contactCount;
        int goodPointCount = 0;

        for (int i = 0; i < contactQuantity; i++) {
            if (hit.GetContact(i).point.y - (transform.position.y - 1) < 0) {
                goodPointCount++;
            }
        }

        if(goodPointCount==contactQuantity) {
            isGrounded = true;
            isGliding = false;
        }
        else {
            if(Input.GetKey(KeyCode.W)) {
                rb.gravityScale = 0;
                isGrounded = false;
                isStick = true;
            }
            else
            {
                isGrounded = false;
                isStick = false;
            }
        }
        */


        /*
        Collider2D collider = hit.collider;

        Vector3 contactPoint = hit.contacts[0].point;
        Vector3 center = collider.bounds.center;

        bool right = contactPoint.x > center.x;

        //Debug.Log("Right: " + right);

        if (right) {
            if (Input.GetKey(KeyCode.W)) {
                rb.gravityScale = 0;
                isGrounded = false;
                isStick = true;
            }
        }
        else {
            isGrounded = true;
            isGliding = false;
        }
        */
    }

    // making sure isGrounded is false when the player is in the air \\
    void OnCollisionExit2D(Collision2D hit) {
        collided = false;
        //if (hit.gameObject.tag == "Ground" || hit.gameObject.tag == "Platform") {
        //    isGrounded = false;
        //    isStick = false;
        //}
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
            swimming = true; // THIS WILL NOT ACTUALLY CAUSE SWIMMING
        }
        //if (col.gameObject.tag == "Spring") {
        //    isGrounded = false;
        //}
	}
    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "goop") {
            speed = 7f;
        }
        else if (col.gameObject.tag == "sleek") {
            speed = 7f;
        }
        if (col.gameObject.tag == "Ire") {
            swimming = false;
        }
    }

}
