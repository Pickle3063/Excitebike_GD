using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Crash : MonoBehaviour {

    //checks if the player has crashed
    bool isCrashed = false;
    bool isBRotCrashed = false;
    bool isFRotCrashed = false;

    //number to increase timer by
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
        //if wheelie crash
        if (isCrashed)
        {
            GroundCon.DecreaseRot();
            //the button you mash to speed up the timer after a crash
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                LaneSwitch.SpeedUpCrashTime();
            }
        }
        //if rotated back crash
        if (isBRotCrashed)
        {
            GroundCon.DecreaseRot();
            //the button you mash to speed up the timer after a crash
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                LaneSwitch.SpeedUpCrashTime();
            }
        }
        //if rotated forwards crash
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

    //toggles if you were in a wheelie crash
    public void ChangeIsCrashed()
    {
        isCrashed = !isCrashed;
        //which toggles another boolean checking if you need the recovery lane
        if (isCrashed)
        {
            LaneSwitch.NeedTopLaneTrue();
        }
        else
        {
            LaneSwitch.NeedTopLaneFalse();
        }
    }
    //toggles if you were in a back rotation crash mentioned in other scripts
    public void ChangeIsBRotCrashed()
    {
        isBRotCrashed = !isBRotCrashed;
        if (isBRotCrashed)
        {

            LaneSwitch.NeedTopLaneTrue();
        }
        else
        {
            LaneSwitch.NeedTopLaneFalse();
        }

    }

    //toggles forward rotational crash true
    public void ChangeIsFRotCrashedTrue()
    {
        isFRotCrashed = true;
        if (isFRotCrashed)
        {
            LaneSwitch.NeedTopLaneTrue();

        }
        
    }
    //toggles forward rotational crash false
    public void ChangeIsFRotCrashedFalse()
    {
        isFRotCrashed = false;
        if(!isFRotCrashed)
        {
            LaneSwitch.NeedTopLaneFalse();
        }
    }

    //for checking which kind of crash you have taken
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
