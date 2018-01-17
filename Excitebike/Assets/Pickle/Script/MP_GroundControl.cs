using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MP_GroundControl : MonoBehaviour {

    //checks that the player is not doing a wheelie
    bool isGrounded;
    //saves starting quaternion rotation
    Quaternion StartRot;
    //saves current quaternion rotation
    Quaternion curRot;
    //speed the player rotates
    [SerializeField] float Speed;
    //how long the player is in the recovery lane for a wheelie crash
    [SerializeField] float WheelieCrashTimer;
    //used to find the number equal to a specific rotation for use later
    [SerializeField] float curZRot;

    //accessing crash script
    MP_Crash Crashing;
    MP_LaneValues LaneSwitch;

	// Use this for initialization
	void Start() {
        //sets starting rotation for later use
         StartRot = transform.rotation;
        Crashing = GetComponent<MP_Crash>();
        LaneSwitch = GetComponent<MP_LaneValues>();
	}
	
	// Update is called once per frame
	void Update () {
        
        CrashCheck();
        //updating the current rotation every frame
        curRot = transform.rotation;
        curZRot = curRot.z;
        //makes sure the player stops rotating when they hit the ground
        if (transform.rotation.z <= 0)
        {
            isGrounded = true;
            transform.rotation = StartRot;
            
        }
	}

    //increases Z rotation by a speed
    public void IncreaseRot()
    {
        isGrounded = false;
        gameObject.transform.Rotate(new Vector3(0f, 0f, Speed));
       
    }
    
    //decreases Z rotation by a speed
    public void DecreaseRot()
    {
        if (!isGrounded)
        {
            gameObject.transform.Rotate(new Vector3(0f, 0f, -Speed));
        }
    }

    //for resetting rotation slowly
    public void ResetRot()
    {
        transform.rotation = Quaternion.Lerp(curRot, StartRot, Speed * Time.deltaTime);
    }

    //used for when crashing is implemented
    //uses the current Z rotation versus the number you get from curZRot at specific rotations
    void CrashCheck()
    {
        //checks to see if you're in that zone in which the player wobbles
        if(curRot.z > 0.4539904)//0.4539904 = 54f
        {
            //do animation stuff here i guess
            //sets the crash timer in MP_ChangeLanes to the crash timer for a wheelie
            //LaneSwitch.WheelieCrash();
        }

        //checks to see if player has crashed
        if(curRot.z > 0.5735764)//0.5735764 = 70f
        {
            //calls a function that sets the current crash timer to the wheelie crash timer
            LaneSwitch.WheelieCrash();
            //changing boolean that checks if you are crashing and starts rotation
            Crashing.ChangeIsCrashed();
            ResetRot();
            
        }
       
    }

    //the wheelie crash timer accessible by other scripts
    public float GetWheelieTime()
    {
        return WheelieCrashTimer;
    }
}
