using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MP_AirControl : MonoBehaviour
{
<<<<<<< HEAD
    Quaternion backRot;
    Quaternion midRot;
    Quaternion forRot;

    [SerializeField] Quaternion curRot;
=======
    Quaternion backRot; //rotation leaning back
    Quaternion midRot; //neutral rotation
    Quaternion forRot; //forward leaning rotation

    //current rotation
    Quaternion curRot;
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae

    float backZ = 42.975f;
    float midZ = 0f;
    float forZ = -42.975f;

    [SerializeField] float speed;
<<<<<<< HEAD
    [SerializeField] float BackCrashTime;

=======
    //timer used for landing on right side of ramp while rotated back
    //[SerializeField] float BackCrashTime; 

        //timer setup
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    float timer = .1f;
    float timePassed;

    bool inAir;
    bool isFor;

<<<<<<< HEAD
=======
    //simple state machine
    //adds states
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    enum RotateStates
    {
        BackState,
        MidState,
        ForState,
        inactiveState
    }

<<<<<<< HEAD
    [SerializeField] RotateStates curState = RotateStates.BackState;
=======
    //sets starting state
    RotateStates curState = RotateStates.inactiveState;
    //creates a dictionary of states
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    Dictionary<RotateStates, Action> fsm = new Dictionary<RotateStates, Action>();

    MP_RampCon RCon;
    MP_Boost_Accel Accel;
    MP_Crash Crashing;
    MP_LaneValues lValue;

    private void Start()
    {
<<<<<<< HEAD
=======
        //adding states to dictionary
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
        fsm.Add(RotateStates.BackState, new Action(StateBack));
        fsm.Add(RotateStates.MidState, new Action(StateMid));
        fsm.Add(RotateStates.ForState, new Action(StateFor));
        fsm.Add(RotateStates.inactiveState, new Action(StateInactive));

<<<<<<< HEAD
        SetState(RotateStates.BackState);

=======
        //also sets starting state
        SetState(RotateStates.inactiveState);

        //quaternion roatations of each rotation
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
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
<<<<<<< HEAD
        fsm[curState].Invoke();
        timePassed += Time.deltaTime;

        curRot = transform.rotation;

        if(curState == RotateStates.ForState)
        {
            isFor = true;
        }
        else
        {
            isFor = false;
        }

        if (RCon.GetGTASwitch())
        {
=======
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
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
            curState = RotateStates.inactiveState;
        }
    }

    private void OnTriggerExit(Collider other)
    {
<<<<<<< HEAD
        if(other.tag == "Ramp")
        {
            inAir = true;
            if (RCon.GetWasWheelie())
            {
                GetComponent<Rigidbody>().AddForce(transform.up * (Accel.GetSpeed() * 3000));
                
=======
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
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
                RCon.SetWasWheelieFalse();
  
            }

        }
    }

<<<<<<< HEAD
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ramp" && curState == RotateStates.BackState)
        {
            lValue.BackRotCrash();
            Crashing.ChangeIsBRotCrashed();

        }
    }

    void StateBack()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, backRot, speed * Time.deltaTime);
=======


    void StateBack()
    {
        //sets rotation for leaning back and says it isn't leaning forward
        isFor = false;
        transform.rotation = Quaternion.Slerp(transform.rotation, backRot, speed * Time.deltaTime);
        
        //allows for changing rotatin in air after timer is done
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
        if (timePassed > timer && inAir)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
<<<<<<< HEAD
=======
                //resets timer and changes state
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
                ResetTimePassed();
                curState = RotateStates.MidState;
            }
        }
    }
    void StateMid()
    {
<<<<<<< HEAD
        transform.rotation = Quaternion.Slerp(transform.rotation, midRot, speed * Time.deltaTime);
        if(timePassed > timer && inAir)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
=======
        //sets rotation for neutral in air and says it isn't leaning forward
        isFor = false;
        transform.rotation = Quaternion.Slerp(transform.rotation, midRot, speed * Time.deltaTime);

        //allows for changing rotatin in air after timer is done
        if (timePassed > timer && inAir)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                //resets timer and changes state
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
                ResetTimePassed();
                curState = RotateStates.ForState;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
<<<<<<< HEAD
=======
                //resets timer and changes state
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
                ResetTimePassed();
                curState = RotateStates.BackState;
            }
        }
    }
    void StateFor()
    {
<<<<<<< HEAD
        transform.rotation = Quaternion.Slerp(transform.rotation, forRot, speed * Time.deltaTime);
        if(timePassed > timer && inAir)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
=======
        //sets rotation for forward leaning rotation and says it is leaning forward
        isFor = true;
        transform.rotation = Quaternion.Slerp(transform.rotation, forRot, speed * Time.deltaTime);

        //allows for changing rotatin in air after timer is done
        if (timePassed > timer && inAir)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                //resets timer and changes state
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
                ResetTimePassed();
                curState = RotateStates.MidState;
            }
        }
    }

<<<<<<< HEAD
    void StateInactive()
    {
        if (!RCon.GetGTASwitch())
        {
=======
    //inactive state for when you aren't in the air
    void StateInactive()
    {
        //if in air
        if (!RCon.GetGTASwitch())
        {
            //sets the state to back leaning rotation
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
            curState = RotateStates.BackState;
        }
    }

<<<<<<< HEAD
    public void SetInitialState()
    {
        curState = RotateStates.BackState;
    }
=======
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae

    void SetState(RotateStates newState)
    {
        curState = newState;
    }

<<<<<<< HEAD
=======
    //resets timer
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    void ResetTimePassed()
    {
        timePassed = 0;
    }

<<<<<<< HEAD
=======
    //checks if in forward leaning position
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    public bool GetIsFor()
    {
        return isFor;
    }
<<<<<<< HEAD

    public float GetBackCrashTime()
    {
        return BackCrashTime;
    }

=======
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

>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
}
