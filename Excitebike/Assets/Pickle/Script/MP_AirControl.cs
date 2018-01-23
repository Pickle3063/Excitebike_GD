using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MP_AirControl : MonoBehaviour
{
    Quaternion backRot; //rotation leaning back
    Quaternion midRot; //neutral rotation
    Quaternion forRot; //forward leaning rotation

    //current rotation
    Quaternion curRot;

    float backZ = 42.975f;
    float midZ = 0f;
    float forZ = -42.975f;

    [SerializeField] float speed;
    //timer used for landing on right side of ramp while rotated back
    //[SerializeField] float BackCrashTime; 

        //timer setup
    float timer = .1f;
    float timePassed;

    bool inAir;
    bool isFor;

    //simple state machine
    //adds states
    enum RotateStates
    {
        BackState,
        MidState,
        ForState,
        inactiveState
    }

    //sets starting state
    RotateStates curState = RotateStates.inactiveState;
    //creates a dictionary of states
    Dictionary<RotateStates, Action> fsm = new Dictionary<RotateStates, Action>();

    MP_RampCon RCon;
    MP_Boost_Accel Accel;
    MP_Crash Crashing;
    MP_LaneValues lValue;

    private void Start()
    {
        //adding states to dictionary
        fsm.Add(RotateStates.BackState, new Action(StateBack));
        fsm.Add(RotateStates.MidState, new Action(StateMid));
        fsm.Add(RotateStates.ForState, new Action(StateFor));
        fsm.Add(RotateStates.inactiveState, new Action(StateInactive));

        //also sets starting state
        SetState(RotateStates.inactiveState);

        //quaternion roatations of each rotation
        backRot = new Quaternion(0f, 0f, 0.3662982f, 0.9304975f);
        midRot = new Quaternion(0f, 0f, 0f, 1f);
        forRot = new Quaternion(0f, 0f, -0.3662982f, 0.9304975f);

        RCon = GetComponent<MP_RampCon>();
        Accel = GetComponent<MP_Boost_Accel>();
        Crashing = GetComponent<MP_Crash>();
        lValue = GetComponent<MP_LaneValues>();

        inAir = false;
        
    }

    private void Update()
    {
        //calls current state every update frame
        fsm[curState].Invoke();
        //timer
        timePassed += Time.deltaTime;

        //sets current rotation for checking quaternion
        curRot = transform.rotation;

        //if on the ground
        if (RCon.GetGTASwitch())
        {
            //set state to inactive(not rotating in air)
            curState = RotateStates.inactiveState;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if you've left the ramp's collider
        if(other.tag == "Ramp")
        {
            //sets player is in air
            inAir = true;
            //checks if you were in a wheelie
            if (RCon.GetWasWheelie())
            {
                //supposed to move player upwards
                GetComponent<Rigidbody>().AddForce(transform.up * (Accel.GetSpeed() * 3000));
                
                //sets was in a wheelie to false
                RCon.SetWasWheelieFalse();
  
            }

        }
    }



    void StateBack()
    {
        //sets rotation for leaning back and says it isn't leaning forward
        isFor = false;
        transform.rotation = Quaternion.Slerp(transform.rotation, backRot, speed * Time.deltaTime);
        
        //allows for changing rotatin in air after timer is done
        if (timePassed > timer && inAir)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                //resets timer and changes state
                ResetTimePassed();
                curState = RotateStates.MidState;
            }
        }
    }
    void StateMid()
    {
        //sets rotation for neutral in air and says it isn't leaning forward
        isFor = false;
        transform.rotation = Quaternion.Slerp(transform.rotation, midRot, speed * Time.deltaTime);

        //allows for changing rotatin in air after timer is done
        if (timePassed > timer && inAir)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                //resets timer and changes state
                ResetTimePassed();
                curState = RotateStates.ForState;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                //resets timer and changes state
                ResetTimePassed();
                curState = RotateStates.BackState;
            }
        }
    }
    void StateFor()
    {
        //sets rotation for forward leaning rotation and says it is leaning forward
        isFor = true;
        transform.rotation = Quaternion.Slerp(transform.rotation, forRot, speed * Time.deltaTime);

        //allows for changing rotatin in air after timer is done
        if (timePassed > timer && inAir)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                //resets timer and changes state
                ResetTimePassed();
                curState = RotateStates.MidState;
            }
        }
    }

    //inactive state for when you aren't in the air
    void StateInactive()
    {
        //if in air
        if (!RCon.GetGTASwitch())
        {
            //sets the state to back leaning rotation
            curState = RotateStates.BackState;
        }
    }


    void SetState(RotateStates newState)
    {
        curState = newState;
    }

    //resets timer
    void ResetTimePassed()
    {
        timePassed = 0;
    }

    //checks if in forward leaning position
    public bool GetIsFor()
    {
        return isFor;
    }
    //turns off the boolean saying you are no longer in a forward leaning position
    public void TurnIsForOff()
    {
        isFor = false;
    }

    //timer for landing on right side of ramp while leaning back
    //public float GetBackCrashTime()
    //{
    //    return BackCrashTime;
    //}

}
