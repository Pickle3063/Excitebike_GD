using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

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

        if (pause && Input.GetKeyDown(KeyCode.Return))
        {
            pause = false;
            control.enabled = true;
            accel.enabled = true;
            
        }
        else if (Input.GetKeyDown(KeyCode.Return) && !pause)
        {
            pause = true;
            control.enabled = false;
            accel.enabled = false;
        }

    }
}

