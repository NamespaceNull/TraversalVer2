using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	// player movement code \\
	public CharacterController thing;
	public float speed = 10f;
	public Rigidbody rb;
	private Vector3 inputVector;
	private Vector3 direction;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
		// old player movement code\\
		float hInput = Input.GetAxis("Horizontal");
		direction.x = hInput * speed;

		thing.Move(direction * Time.deltaTime);
	}
	/*
	void FixedUpdate() {
		// player movement \\
		inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * speed, 0);
		rb.velocity = inputVector;
	}
	*/
}
