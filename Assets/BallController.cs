using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody ballBody;
    public GameController gameController;
    public int launchAngle;
    public int initialSpeed;
    public int speedIncrease;
    private Vector3 speedMemory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void serve(int towardsPlayer) {
        // float angle = Random.Range(33, 50);
        float vx = initialSpeed * Mathf.Cos((launchAngle*Mathf.PI)/180);
        float vy = initialSpeed * Mathf.Sin((launchAngle*Mathf.PI)/180);
        speedMemory = new Vector3( vx, vy, 0);
        ballBody.velocity = speedMemory;
        Debug.Log("Velocity " + ballBody.velocity.ToString());
    }

    void OnCollisionEnter(Collision collisionInfo) {
        Vector3 impulse = collisionInfo.impulse;
        if(impulse.x != 0) {
            speedMemory = Vector3.Scale(speedMemory, new Vector3(-1,1,1));
            ballBody.velocity = speedMemory;
        }
        if(impulse.y != 0) {
            speedMemory = Vector3.Scale(speedMemory, new Vector3(1,-1,1));
            ballBody.velocity = speedMemory;
        }
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Here in trigger");
        GameController.get().scoreGoal(0);
    }
}
