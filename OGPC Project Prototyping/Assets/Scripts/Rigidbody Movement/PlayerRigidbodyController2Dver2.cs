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
    public static bool inSleek = false;
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
    public string previousStuckWall = "";
    public GameObject mainCamera;


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
        if (mainCamera.GetComponent<PlayerInput>().GetJumpKey() && isGrounded) {
            //rb.AddForce
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            // if the player is still parented to a moving wall, unparent them
            if (transform.parent) {
                transform.parent = null;
            }
        }

        // gliding mechanic \\
        // checking if the player can glide=
        if (mainCamera.GetComponent<PlayerInput>().GetGlidingKey() && !isGrounded) {
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
            if (mainCamera.GetComponent<PlayerInput>().GetJumpKey()) {
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                // make the player wall jump and un-stick them from the wall
                rb.AddForce(jump * wallJumpForce, ForceMode2D.Impulse);
                isStick = false;
            }
        }
        // if the player lets go of the 'W' key 
        if (mainCamera.GetComponent<PlayerInput>().GetGlidingUp()) {
            isStick = false;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        // if the player moves right
        if (rb.velocity.x > 0) GetComponent<SpriteRenderer>().flipX = false;
        // if the player moves left
        if (rb.velocity.x < 0) GetComponent<SpriteRenderer>().flipX = true;
    }

    // ground and wall collision with the player \\
    void OnCollisionEnter2D(Collision2D hit) {
        // if the player touches the ground \\
        if (hit.contacts[0].point.y < transform.position.y && hit.contacts.Length == 1) {
            isGrounded = true;
            isGliding = false;
            previousStuckWall = "";
        }
        // if the player touches the wall \\
        if (mainCamera.GetComponent<PlayerInput>().GetGlidingKey() && !sleek2D.inSleek) {
            if (hit.contacts.Length > 1) {
                // Left wall \\
                if (hit.contacts[0].point.x < transform.position.x) {
                    if (previousStuckWall == "Right" || previousStuckWall == "") {
                        previousStuckWall = "Left";
                        rb.constraints = RigidbodyConstraints2D.FreezeAll;
                        isGrounded = false;
                        isStick = true;    
                    }
                }
                // Right Wall \\
                else if (hit.contacts[0].point.x > transform.position.x) {
                    if (previousStuckWall == "Left" || previousStuckWall == "") {
                        previousStuckWall = "Right";
                        rb.constraints = RigidbodyConstraints2D.FreezeAll;
                        isGrounded = false;
                        isStick = true;                 
                    }
                }
            }
        }
        rb.rotation = 0;
    }

    // making sure that if the player is on the ground, that isGrounded is true
    void OnCollisionStay2D(Collision2D hit) {
        if (hit.contacts[0].point.y < transform.position.y && hit.contacts.Length == 1) {
            isGrounded = true;
            isGliding = false;
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
        if (col.gameObject.tag == "Narrative Trigger") {
            col.GetComponent<Narrative_trigger_script>().GetTriggerAction(rb.velocity);
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
