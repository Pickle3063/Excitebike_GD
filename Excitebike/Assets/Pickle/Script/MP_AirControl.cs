using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MP_AirControl : MonoBehaviour
{
    Quaternion backRot;
    Quaternion midRot;
    Quaternion forRot;

    [SerializeField] Quaternion curRot;

    float backZ = 42.975f;
    float midZ = 0f;
    float forZ = -42.975f;

    [SerializeField] float speed;
    [SerializeField] float BackCrashTime;

    float timer = .1f;
    float timePassed;

    bool inAir;
    bool isFor;

    enum RotateStates
    {
        BackState,
        MidState,
        ForState,
        inactiveState
    }

    [SerializeField] RotateStates curState = RotateStates.BackState;
    Dictionary<RotateStates, Action> fsm = new Dictionary<RotateStates, Action>();

    MP_RampCon RCon;
    MP_Boost_Accel Accel;
    MP_Crash Crashing;
    MP_LaneValues lValue;

    private void Start()
    {
        fsm.Add(RotateStates.BackState, new Action(StateBack));
        fsm.Add(RotateStates.MidState, new Action(StateMid));
        fsm.Add(RotateStates.ForState, new Action(StateFor));
        fsm.Add(RotateStates.inactiveState, new Action(StateInactive));

        SetState(RotateStates.BackState);

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
            curState = RotateStates.inactiveState;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Ramp")
        {
            inAir = true;
            if (RCon.GetWasWheelie())
            {
                GetComponent<Rigidbody>().AddForce(transform.up * (Accel.GetSpeed() * 3000));
                
                RCon.SetWasWheelieFalse();
  
            }

        }
    }

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
        if (timePassed > timer && inAir)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                ResetTimePassed();
                curState = RotateStates.MidState;
            }
        }
    }
    void StateMid()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, midRot, speed * Time.deltaTime);
        if(timePassed > timer && inAir)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                ResetTimePassed();
                curState = RotateStates.ForState;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                ResetTimePassed();
                curState = RotateStates.BackState;
            }
        }
    }
    void StateFor()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, forRot, speed * Time.deltaTime);
        if(timePassed > timer && inAir)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                ResetTimePassed();
                curState = RotateStates.MidState;
            }
        }
    }

    void StateInactive()
    {
        if (!RCon.GetGTASwitch())
        {
            curState = RotateStates.BackState;
        }
    }

    public void SetInitialState()
    {
        curState = RotateStates.BackState;
    }

    void SetState(RotateStates newState)
    {
        curState = newState;
    }

    void ResetTimePassed()
    {
        timePassed = 0;
    }

    public bool GetIsFor()
    {
        return isFor;
    }

    public float GetBackCrashTime()
    {
        return BackCrashTime;
    }

}
