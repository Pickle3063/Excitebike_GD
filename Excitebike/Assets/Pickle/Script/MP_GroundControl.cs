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
    //used to find the number equal to a specific rotation for use later
    [SerializeField] float curZRot;
    
	// Use this for initialization
	void Start() {
        //sets starting rotation for later use
         StartRot = transform.rotation;

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

    //used for when crashing is implemented
    //uses the current Z rotation versus the number you get from curZRot at specific rotations
    void CrashCheck()
    {
        //checks to see if you're in that zone in which the player wobbles
        if(curRot.z > 0.4539904)//0.4539904 = 54f
        {
            print("Crashing");
        }

        //checks to see if player has crashed
        if(curRot.z > 0.5735764)//0.5735764 = 70f
        {
            print("Crashed");
        }
       
    }
}
