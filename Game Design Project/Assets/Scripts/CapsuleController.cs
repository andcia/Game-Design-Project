using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CapsuleController : MonoBehaviour {

	// this controls the rigidbody movement
	Vector3 _movement;

	// this is how fast the capsule will move
	public float speed = 10f;

	// refer to the Rigidbody component
	// this does not mean that the Rigidbody will be available
	// by default.
	protected Rigidbody _rigidbody;


	protected GameObject inRange;


	// when the object wakes up (is created), get its components
	void Awake () {

		// Get the Rigidbody component on this object.
		// GetComponent <Type> ();
		_rigidbody = GetComponent <Rigidbody> ();

	}


	void Update () {

		if (Input.GetKeyDown (KeyCode.Space) && inRange != null) {
			Destroy (inRange);
		}

	}

	
	// Fixed Update is used for Physics and Regular Intervals
	void FixedUpdate () {

		// the player will press on the left and right keys
		float horizontal = Input.GetAxisRaw ("Horizontal");

		// the player will press on the up and down keys
		float vertical = Input.GetAxisRaw ("Vertical");

		Move (horizontal, vertical);

	}


	// Controls the player movement
	void Move (float h, float v) {

		// Sets the movement I'm inputting on the keyboard
		_movement.Set (h, 0, v);

		// make sure the player is moving on a circle, not a square
		_movement = _movement.normalized * speed * Time.deltaTime;

		// moves the player to a specified position
		_rigidbody.MovePosition (transform.position + _movement);

		// rotate the player towards the direction we want
		if (_movement != Vector3.zero) {
			_rigidbody.MoveRotation (Quaternion.LookRotation (_movement));
		}
	}

	void OnTriggerEnter (Collider c)
	{
		if (c.tag == "cube") {

			inRange = c.gameObject;
			
		}
	}

	void OnTriggerExit (Collider c)
	{
		if (c.tag == "cube"  && c.gameObject == inRange) {

			inRange = null;

		}
	}

}

