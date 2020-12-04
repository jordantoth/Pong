using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static int playerSpeed = 10000;
    public Rigidbody playerBody;
    public int playerNumber;
    public string upKey;
    public string downKey;

    void FixedUpdate()
    {
        if (Input.GetKey(upKey)) {
            playerBody.AddForce(0, playerSpeed*Time.deltaTime, 0);
        }
        if (Input.GetKey(downKey)) {
            playerBody.AddForce(0, -playerSpeed*Time.deltaTime, 0);
        }
    }
}
