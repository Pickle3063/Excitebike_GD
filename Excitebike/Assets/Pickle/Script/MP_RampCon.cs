using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_RampCon : MonoBehaviour {

    MP_GroundControl GCon;
    MP_AirControl ACon;
    MP_Boost_Accel Accel;
    MP_LaneValues lValue;
    MP_Crash Crashing;

<<<<<<< HEAD
    Quaternion resetRot;

   [SerializeField] bool wasWheelie;
    [SerializeField] float forCrashTime;
    bool WasFor;
    bool GroundToAirSwitch;
=======
    //rotation of 0
    Quaternion resetRot;

   bool wasWheelie;
    //how long to remain crashed from a crash of landing rotated forward
   float forCrashTime;
    //for the check if you were rotated forward
   bool WasFor;
    //handles the switching between ground to air
   bool GroundToAirSwitch;
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
   

    // Use this for initialization
    void Start()
    {
        GCon = GetComponent<MP_GroundControl>();
        ACon = GetComponent<MP_AirControl>();
        Accel = GetComponent<MP_Boost_Accel>();
        lValue = GetComponent<MP_LaneValues>();
        Crashing = GetComponent<MP_Crash>();
<<<<<<< HEAD
=======
        //setting the reset rotation to 0
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
        resetRot = new Quaternion(0f, 0f, 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
=======
        //checks if you were in a wheelie
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
        wasWheelie = GCon.GetIsWheelie();
        
    }

    private void OnTriggerEnter(Collider other)
    {
<<<<<<< HEAD
        if (other.tag == "Ramp")
        {
            wasWheelie = GCon.GetIsWheelie();
            GCon.enabled = false;
            GroundToAirSwitch = false;
            ACon.SetInitialState();

        }
        if (other.tag == "PlayerFloor")
        {
            
            GCon.enabled = true;
            WasFor = ACon.GetIsFor();
            if (WasFor)
            {
                lValue.ForRotCrash();
                Crashing.ChangeIsFRotCrashed();
            }
            GroundToAirSwitch = true;
            
            Accel.QuarterSpeed();
=======
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
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
            transform.rotation = Quaternion.Slerp(transform.rotation, resetRot, 1f * Time.deltaTime);
            
        }
    }
<<<<<<< HEAD

=======
    //for getting this crash's timer
    public float GetFRotTime()
    {
        return forCrashTime;
    }
    //for getting the bool for ground or air
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    public bool GetGTASwitch()
    {
        return GroundToAirSwitch;
    }
<<<<<<< HEAD
=======
    //sets if you were in a wheelie to false
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    public void SetWasWheelieFalse()
    {
        wasWheelie = false;
    }
<<<<<<< HEAD
=======
    //for checking if you were in a wheelie
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    public bool GetWasWheelie()
    {
        return wasWheelie;
    }
}
