using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

<<<<<<< HEAD
    public MP_Acceleration accel;
    public MP_Controls control;
    private bool pause;

	// Use this for initialization
	void Start () {
        accel = GetComponent<MP_Acceleration>();
        control = GetComponent<MP_Controls>();
    }


    // Update is called once per frame
    void Update () {

        if (pause && Input.GetKeyDown(KeyCode.Return))
        {
            pause = false;
            control.enabled = false;
            accel.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Return) && !pause)
        {
            pause = true;
            control.enabled = true;
            accel.enabled = true;
        }

    }
=======
    public MP_Boost_Accel accel;
    public MP_Controls control;
    private bool pause = false;

	// Use this for initialization
	void Start () {
        accel = GetComponent<MP_Boost_Accel>();
        control = GetComponent<MP_Controls>();
    }


    // Update is called once per frame
    void Update () {

        //if you hit enter while paused
        if (pause && Input.GetKeyDown(KeyCode.Return) && pause)
        {
            // turn paused off and turn controls on
            pause = false;
            control.enabled = true;
            accel.enabled = true;
        }
        //if you hit enter while not paused
        else if (Input.GetKeyDown(KeyCode.Return) && !pause)
        {
            //turn paused on and disable controls
            pause = true;
            control.enabled = false;
            accel.enabled = false;
            
        }

    }
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
}

