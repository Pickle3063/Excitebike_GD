using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Crash : MonoBehaviour {

    //checks if the player has crashed
    bool isCrashed = false;
    bool isBRotCrashed = false;
    bool isFRotCrashed = false;

    [SerializeField] float speedUpRecovery;

    //accessing scripts
    MP_LaneValues LaneSwitch;
    MP_GroundControl GroundCon;
    MP_RampCon RCon;

	// Use this for initialization
	void Start () {

        LaneSwitch = GetComponent<MP_LaneValues>();
        GroundCon = GetComponent<MP_GroundControl>();
        RCon = GetComponent<MP_RampCon>();
	}
	
	// Update is called once per frame
	void Update () {
        //works with ResetRot to finish rotation
        if (isCrashed)
        {
            GroundCon.DecreaseRot();
            //the button you mash to speed up the timer after a crash
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                LaneSwitch.SpeedUpCrashTime();
            }
        }
        if (isBRotCrashed)
        {
            GroundCon.DecreaseRot();
            //the button you mash to speed up the timer after a crash
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                LaneSwitch.SpeedUpCrashTime();
            }
        }
        if (isFRotCrashed)
        {
            GroundCon.DecreaseRot();
            //the button you mash to speed up the timer after a crash
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                LaneSwitch.SpeedUpCrashTime();
            }
        }
    }

    //toggles the boolean isCrashed
    public void ChangeIsCrashed()
    {
        isCrashed = !isCrashed;
        //which toggles another boolean
        if (isCrashed)
        {
            LaneSwitch.ChangeNeedTopLane();
        }
        else
        {
            LaneSwitch.ChangeNeedTopLane();
        }
    }

    public void ChangeIsBRotCrashed()
    {
        isBRotCrashed = !isBRotCrashed;
        if (isBRotCrashed)
        {

            LaneSwitch.ChangeNeedTopLane();
        }
        else
        {
            LaneSwitch.ChangeNeedTopLane();
        }

    }

    public void ChangeIsFRotCrashed()
    {
        isFRotCrashed = !isFRotCrashed;
        if (isFRotCrashed)
        {
            LaneSwitch.ChangeNeedTopLane();

        }
        else
        {
            LaneSwitch.ChangeNeedTopLane();
        }
    }

    //for checking if the boolean is true of false in other scripts
    public bool GetIsCrashed()
    {
        return isCrashed;
    }

    public bool GetIsBRotCrashed()
    {
        return isBRotCrashed;
    }

    public bool GetIsFRotCrashed()
    {
        return isFRotCrashed;
    }

    //for speeding up the timer when you crash to recover quicker
    public float GetSpeedUpTime()
    {
        return speedUpRecovery;
    }
}
