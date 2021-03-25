using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour {

	/*
		This script uses the character controller to move the player,
		so have that on the player first before trying to play
	*/

	// the character controller \\
	private CharacterController controller;
	// player jump variables \\
	public float gravity = 9.81f; 
	public float jumpForce = 3.5f;
	private float directionY;
	// player movement variables \\
	public float speed = 5f;
	// player gliding variables \\
	public bool playerFacing = true; //this variable will be explained later in the comments
	public bool isGliding = false;
	// player wall stick mechanic \\
	public bool isStick = false;
	public bool cannotReStick = false;
	public bool wallJump = false;
	private int restickTimer = 50;

	// Use this for initialization
	void Start () {
		// grabbing the character controller
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		// code to get vector and input \\
		float hInput = Input.GetAxis("Horizontal");
		Vector3 direction = new Vector3(hInput, 0f, 0f);

		// restick timer to allow for wall jumping \\
		if (cannotReStick) {
			restickTimer--;
			if (restickTimer <= 0) {
				cannotReStick = false;
				wallJump = false;
				restickTimer = 500;
			}
		}

		// jump code \\
		// if the player isn't gliding, first of all
		if (isGliding == false) {
			// jumping stuff
			if (Input.GetKeyDown(KeyCode.Space)) {
				if (controller.isGrounded) {
					directionY = jumpForce;
				}
				// if the player is sticking to the wall, let them be able to jump from the wall
				else if (isStick) {
					directionY = jumpForce;
					direction.y = directionY;
					isStick = false;
					wallJump = true;
					cannotReStick = true;
				}
			}
			// if the player is sticking to the wall, disable gravity
			if (isStick == false) {
				directionY -= gravity * Time.deltaTime;
			}
			direction.y = directionY;
		}

		// changing the playerFacing based on the key presses (for the gliding mechanic) \\
		if (Input.GetKeyDown(KeyCode.A) && isGliding == false && isStick == false) { // if the player moves left, the playerFacing changes to false
			playerFacing = false;
		}
		else if (Input.GetKeyDown(KeyCode.D) && isGliding == false && isStick == false) { // if the player moves right, the playerFacing changes to true
			playerFacing = true;
		}

		// player glide code \\
		// checking if the player presses and holds the button to start gliding and not on the ground
		if (Input.GetKey(KeyCode.W) && controller.isGrounded == false) {
			if (isStick == false && wallJump == false) {
				isGliding = true;
			}
		}
		// checking if the player releases the button
		else if (Input.GetKeyUp(KeyCode.W)) {
			isGliding = false;
			if (isStick) {
				isStick = false; // if the player lets go of glide, unstick them from the wall
			}
			// if the player was parented to a moving wall, un-parent them
			if (transform.parent) {
				transform.parent = null;
			}
		}

		// glide movement
		if (isGliding && isStick == false && wallJump == false) {
			if (playerFacing == false) { // if the player is facing left, change the horizontal input to -1
				hInput = -1f;
			}
			else if (playerFacing == true) { // if the player is facing right, change the horizontal input to 1
				hInput = 1f;
			}
			// since the horizontal input has changed, redo the direction variable to account for that
			direction = new Vector3(hInput, 0f, 0f);
			// adding gravity back because some reason redoing the direction variable does something like that
			direction.y -= gravity * Time.deltaTime * 2;
		}

		// if the player is sticking onto a wall, turn off glide \\
		if (isStick) {
			isGliding = false;
		}

		// moves the player \\
		// stop moving the player if the player is trying to stick to a wall
		if (isStick == false) {
			controller.Move(direction * speed * Time.deltaTime);
		}
	}

	// checks if the player collides with any objects \\
	void OnControllerColliderHit(ControllerColliderHit hit) {
		// if the player hits the ground, turn gliding off
		if (hit.gameObject.tag == "Ground" || hit.gameObject.tag == "Platform") {
			isGliding = false;
		}
		// if the player hits the wall while gliding, stick them to the wall or a moving wall
		if (hit.gameObject.tag == "Wall" || hit.gameObject.tag == "Moving Wall") {
			if (isGliding && Input.GetKey(KeyCode.W) && cannotReStick == false) {
				isStick = true;
				isGliding = false;
				playerFacing = !playerFacing;
				// if the player hits a moving wall, have them stick to it by parenting them to the wall
				if (hit.gameObject.tag == "Moving Wall") {
					gameObject.transform.parent = hit.gameObject.transform;
				}
			}
		}
	}
}
