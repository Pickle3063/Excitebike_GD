using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_LaneValues : MonoBehaviour {
    //the heights of the four different lanes
    [SerializeField] float heightOne = -1.4f;
    [SerializeField] float heightTwo = -0.4f;
    [SerializeField] float heightThree = 0.6f;
    [SerializeField] float heightFour = 1.6f;
    [SerializeField] float heightRec = 2.6f;

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
    MP_Boost BoostScript;

    private void Start()
    {
        Crashing = GetComponent<MP_Crash>();
        GroundCon = GetComponent<MP_GroundControl>();
        BoostScript = GetComponent<MP_Boost>();
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
