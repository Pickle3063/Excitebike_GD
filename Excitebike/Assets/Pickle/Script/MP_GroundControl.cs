using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MP_GroundControl : MonoBehaviour {

    enum WheelieStates
    {
        IDLE,
        WHEELIE,
        READYTOCRASH,
        CRASH,

        NUM_STATES
    }

    WheelieStates curState = WheelieStates.IDLE;
    Dictionary<WheelieStates, Action> fsm = new Dictionary<WheelieStates, Action>();

    Quaternion curRot;
    Quaternion newRot;

	// Use this for initialization
	void Start () {
        fsm.Add(WheelieStates.IDLE, new Action(StateIdle));
        fsm.Add(WheelieStates.WHEELIE, new Action(StateWheelie));
        fsm.Add(WheelieStates.READYTOCRASH, new Action(StateReadyToCrash));
        fsm.Add(WheelieStates.CRASH, new Action(StateCrash));
        
	}
	
	// Update is called once per frame
	void Update () {
        fsm[curState].Invoke();

	}

    public void IncreaseRot()
    {
        curRot.Set(0f, 0f, 0f, 0f);
        newRot.Set(0f, 0f, 54f, 0f);
        Quaternion.RotateTowards(curRot, newRot, 2 * Time.deltaTime);
    }
    
    public void DecreaseRot()
    {

    }

    void StateIdle()
    {

    }

    void StateWheelie()
    {

    }

    void StateReadyToCrash()
    {

    }

    void StateCrash()
    {

    }

    void SetState(WheelieStates newState)
    {
        curState = newState;
    }
}
