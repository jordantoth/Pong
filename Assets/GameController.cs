using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController get() { 
        if (_instance == null) {
            _instance = new GameController();
        }
        return _instance;
    } 
    private State currentState;
    private int[] score = new int[] { 0, 0 };
    private int maxScore = 10;
    private int playerTurn;
    public enum State 
    {
        GameOver,
        PreVolley,
        Volleying,
    }

    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        currentState = State.PreVolley;
    }

    // Update is called once per frame
    void Update()
    {
        if (string.Equals(currentState, State.PreVolley)) {
            if (Input.GetKey("space")) {
                currentState = State.Volleying;
                ball.GetComponent<BallController>().serve(1);
            }
        }
        else if (string.Equals(currentState, State.GameOver)) {
            if (Input.GetKey("space")) {
                score = new int[] {0, 0};
                currentState = State.PreVolley;
                ball.GetComponent<BallController>().serve(1);
            }
        }
    }

    public void scoreGoal(int playerNumber) {
        score[playerNumber]++;
        if (score[playerNumber] >= maxScore) {
            currentState = State.GameOver;
        } else {
            currentState = State.PreVolley;
        }
        Debug.Log(score.ToString());
    }
}
