using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum State
    {
        idle,
        walking,
        swimming,
        climbing
    }

    public State currentstate = State.idle;
    Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentstate)
        {
            case State.idle: Idle();  break;
            case State.walking: Walking();  break;
            case State.swimming: Swimming();  break;
            case State.climbing: Climbing();  break;
            default: break;

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "WaterTrigger")
        {
            currentstate = State.swimming;
        }
        else if(other.name == "MountainTrigger")
        {
            currentstate = State.climbing;
        }
    }

    void OnTriggerExit(Collider other)
        //if exiting any triggers then switch from the previous state into Walking
    {
        currentstate = State.walking;
    }

    void Swimming()
    {
        Debug.Log("I am Swimming");

    }

    void Climbing()
    {
        Debug.Log("I am Climbing");

    }

    void Idle()
    {
        Debug.Log("I am idle");
        if(lastPosition != transform.position)
            //if NOT in motion and you begin to add movement, you will be changed from idel to != idle and will be marked as Moving/walking
        {
            currentstate = State.walking;
        }
        lastPosition = transform.position;
    }

    void Walking()
    {
        
        Debug.Log("I am walking");
        if (lastPosition == transform.position)
            //if IN motion and you stop then this code will run to see if your last position is the SAME as the current position. If so you will be marked as stopped. The idle code will automatically change you back to idle
        {
            currentstate = State.idle;
        }
        lastPosition = transform.position;
    }
}
