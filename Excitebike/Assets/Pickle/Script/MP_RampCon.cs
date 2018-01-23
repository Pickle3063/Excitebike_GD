using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_RampCon : MonoBehaviour {

    MP_GroundControl GCon;
    MP_AirControl ACon;
    MP_Boost_Accel Accel;
    MP_LaneValues lValue;
    MP_Crash Crashing;

    //rotation of 0
    Quaternion resetRot;

   bool wasWheelie;
    //how long to remain crashed from a crash of landing rotated forward
   [SerializeField] float forCrashTime;
    //for the check if you were rotated forward
   bool WasFor;
    //handles the switching between ground to air
   bool GroundToAirSwitch;
   

    // Use this for initialization
    void Start()
    {
        GCon = GetComponent<MP_GroundControl>();
        ACon = GetComponent<MP_AirControl>();
        Accel = GetComponent<MP_Boost_Accel>();
        lValue = GetComponent<MP_LaneValues>();
        Crashing = GetComponent<MP_Crash>();
        //setting the reset rotation to 0
        resetRot = new Quaternion(0f, 0f, 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        //checks if you were in a wheelie
        wasWheelie = GCon.GetIsWheelie();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //if entered a ramp collider
        if (other.tag == "Ramp")
        {
            //checks if you were in a wheelie
            wasWheelie = GCon.GetIsWheelie();
            //turns off ground control
            GCon.enabled = false;
          //sets the switch to on ground false/in air true
            GroundToAirSwitch = false;
            

        }
        //if entered the collider of the floor the player sits on
        if (other.tag == "PlayerFloor")
        {
            //turns ground control on
            GCon.enabled = true;
            //checks if you were rotated forward
            WasFor = ACon.GetIsFor();
            //if you were
            if (WasFor)
            {
                //sets the crash timer for this type of crash
                lValue.ForRotCrash();
                //says you did crash this way
                Crashing.ChangeIsFRotCrashedTrue();
                //turns the boolean for checking landing forward to false to not repeat the process
                ACon.TurnIsForOff();
                //resets the check for rotated forward
                WasFor = ACon.GetIsFor();
            }
            //sets the switch to on ground true/in air false
            GroundToAirSwitch = true;
            //sets current speed to a quarter of what it was
            Accel.QuarterSpeed();
            //resets rotation of player
            transform.rotation = Quaternion.Slerp(transform.rotation, resetRot, 1f * Time.deltaTime);
            
        }
    }
    //for getting this crash's timer
    public float GetFRotTime()
    {
        return forCrashTime;
    }
    //for getting the bool for ground or air
    public bool GetGTASwitch()
    {
        return GroundToAirSwitch;
    }
    //sets if you were in a wheelie to false
    public void SetWasWheelieFalse()
    {
        wasWheelie = false;
    }
    //for checking if you were in a wheelie
    public bool GetWasWheelie()
    {
        return wasWheelie;
    }
}
