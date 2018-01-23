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
<<<<<<< HEAD
    [SerializeField] float timer = 0.2f;
    [SerializeField] float timePassed;
    //secondary timer for when you crash
    [SerializeField] float crashTimer;
=======
    float timer = 0.2f;
    float timePassed;
    //secondary timer for when you crash
    float crashTimer;
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae

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
<<<<<<< HEAD
        timePassed += Time.deltaTime;
 
    }

=======
        //the timer
        timePassed += Time.deltaTime;
 
    }
    //getting heights
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
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
<<<<<<< HEAD

=======
    //getting this script's speed
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    public float GetSpeed()
    {
        return speed;
    }
<<<<<<< HEAD

=======
    //getting the general timer
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    public float GetTimer()
    {
        return timer;
    }
<<<<<<< HEAD
    
=======
    //getting how much time has passed 
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    public float GetTimePassed()
    {
        return timePassed;
    }
<<<<<<< HEAD

=======
    //getting the timer for a crash
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    public float GetCrashTimer()
    {
        return crashTimer;
    }
<<<<<<< HEAD

=======
    //for if you need the recovery lane
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    public bool GetNeedToplane()
    {
        return needTopLane;
    }
<<<<<<< HEAD

    public void ChangeNeedTopLane()
    {
        needTopLane = !needTopLane;
    }

=======
    //sets needing the recovery lane to true
    public void NeedTopLaneTrue()
    {
        needTopLane = true;
    }
    //sets needing the recovery lane to false
    public void NeedTopLaneFalse()
    {
        needTopLane = false;
    }
    //for setting the crash timer to the overheat timer
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    public void OverheatTime()
    {
        crashTimer = BoostScript.GetOverheatTime();
    }

    //used to set the timer to the crash time for a wheelie
    public void WheelieCrash()
    {
        crashTimer = GroundCon.GetWheelieTime();
    }
<<<<<<< HEAD

    public void BackRotCrash()
    {
        crashTimer = ACon.GetBackCrashTime();
    }

    public void ForRotCrash()
    {

=======
    //used to set the timer to the crash time for landing on the right side of a ramp while rotated back
    //public void BackRotCrash()
    //{
    //    crashTimer = ACon.GetBackCrashTime();
    //}

        //used to set the timer to the crash timer for landing on the track while rotated forward
    public void ForRotCrash()
    {
        crashTimer = RCon.GetFRotTime();
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    }

    //used by MP_Crash to speed up the timer during a crash
    public void SpeedUpCrashTime()
    {
        timePassed = timePassed + Crashing.GetSpeedUpTime();
    }

<<<<<<< HEAD
=======
    //resetting timer
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    public void ResetTimer()
    {
        timePassed = 0;
    }
}
