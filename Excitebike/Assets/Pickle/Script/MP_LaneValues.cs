using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_LaneValues : MonoBehaviour {
    //the heights of the four different lanes
     float heightOne = 0f;
    float heightTwo = -1f;
    float heightThree = -2f;
     float heightFour = -3f;
     float heightRec = -4f;
    
    //speed at which the player changes lanes
    [SerializeField] float speed;

    //stops the state change from being called back to back
    [SerializeField] float timer = 0.2f;
    [SerializeField] float timePassed;
    //secondary timer for when you crash
    [SerializeField] float crashTimer;

    //checks if the player needs to go to the lane above four for overheating or crashing
    bool needTopLane = false;
    

    MP_Crash Crashing;
    MP_GroundControl GroundCon;
    MP_Boost_Accel BoostScript;
    MP_AirControl ACon;
    MP_RampCon RCon;

    private void Start()
    {
        Crashing = GetComponent<MP_Crash>();
        GroundCon = GetComponent<MP_GroundControl>();
        BoostScript = GetComponent<MP_Boost_Accel>();
        ACon = GetComponent<MP_AirControl>();
        RCon = GetComponent<MP_RampCon>();
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
 
    }

    public float GetHeightOne()
    {
        return heightOne;
    }

    public float GetHeightTwo()
    {
        return heightTwo;
    }

    public float GetHeightThree()
    {
        return heightThree;
    }

    public float GetHeightFour()
    {
        return heightFour;
    }

    public float GetRecHeight()
    {
        return heightRec;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public float GetTimer()
    {
        return timer;
    }
    
    public float GetTimePassed()
    {
        return timePassed;
    }

    public float GetCrashTimer()
    {
        return crashTimer;
    }

    public bool GetNeedToplane()
    {
        return needTopLane;
    }

    public void ChangeNeedTopLane()
    {
        needTopLane = !needTopLane;
    }

    public void OverheatTime()
    {
        crashTimer = BoostScript.GetOverheatTime();
    }

    //used to set the timer to the crash time for a wheelie
    public void WheelieCrash()
    {
        crashTimer = GroundCon.GetWheelieTime();
    }

    public void BackRotCrash()
    {
        crashTimer = ACon.GetBackCrashTime();
    }

    public void ForRotCrash()
    {

    }

    //used by MP_Crash to speed up the timer during a crash
    public void SpeedUpCrashTime()
    {
        timePassed = timePassed + Crashing.GetSpeedUpTime();
    }

    public void ResetTimer()
    {
        timePassed = 0;
    }
}
