using UnityEngine;
using System.Collections;

// Simple Rolling Ball Game code - 18 Oct 2015 Daniel Wood
// Add this code to a script called 'move' and then attach the script to a sphere in your game

[RequireComponent (typeof(Rigidbody))]

public class BallMove : MonoBehaviour {

	public float xForce = 10.0f;
	public float zForce = 10.0f;
	public float yForce = 500.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		// this is for the X axis' movement (moving left and right)
		float x = 0.0f;

		if (Input.GetKey (KeyCode.A)) {
			x = x - xForce;
		}

		if (Input.GetKey (KeyCode.D)) {
			x = x + xForce;
		}

		// this is for the Z axis' movement (moving backwards and forwards)
		float z = 0.0f;

		if (Input.GetKey (KeyCode.S)) {
			z = z - zForce;
		}

		if (Input.GetKey (KeyCode.W)) {
			z = z + zForce;
		}

		// this is for the Y axis' movement (jumping)
		float y = 0.0f;

		if (Input.GetKeyDown (KeyCode.Space)) {
			y = yForce;
		}

		GetComponent<Rigidbody> ().AddForce (x, y, z);

	}
}