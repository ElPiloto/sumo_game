using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple Rolling Ball Game code - 18 Oct 2015 Daniel Wood
// Add this code to a script called 'move' and then attach the script to a sphere in your game 
[RequireComponent(typeof(Rigidbody))]

public class BallMover : MonoBehaviour
{
    void Start(){
        if (playerNumber == 1) {
            left = playerOneKeys[0];
            right = playerOneKeys[1];
            down = playerOneKeys[2];
            up = playerOneKeys[3];
        } else if (playerNumber == 2) {
            left = playerTwoKeys[0];
            right = playerTwoKeys[1];
            down = playerTwoKeys[2];
            up = playerTwoKeys[3];
        }
    }

    public static KeyCode[] playerOneKeys = new KeyCode[] {KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.UpArrow };
    public static KeyCode[] playerTwoKeys = new KeyCode[] {KeyCode.A, KeyCode.D, KeyCode.S, KeyCode.W };

    public float xForce = 10.0f;
    public float zForce = 10.0f;
    public float yForce = 500.0f;

    private KeyCode left, right, up, down;

    public int playerNumber = 1;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Hello");
        // this is for the X axis' movement (moving left and right)
        float x = 0.0f;

        if (Input.GetKey(left))
        {
            x = x - xForce;
        }

        if (Input.GetKey(right))
        {
            x = x + xForce;
        }

        // this is for the Z axis' movement (moving backwards and forwards)
        float z = 0.0f;

        if (Input.GetKey(down))
        {
            z = z - zForce;
        }

        if (Input.GetKey(up))
        {
            z = z + zForce;
        }

        // this is for the Y axis' movement (jumping)
        float y = 0.0f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            y = yForce;
        }

        GetComponent<Rigidbody>().AddForce(x, y, z);

    }
}