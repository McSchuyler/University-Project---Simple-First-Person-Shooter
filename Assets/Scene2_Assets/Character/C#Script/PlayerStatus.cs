using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

    public enum State { Alive, Death };
    public State currentState;
    public bool die = false;

    void Start()
    {
        currentState = State.Alive;
    }

    void Update()
    {
        if(currentState == State.Death && die == false)
        {
            die = true;
        }
    }
}
