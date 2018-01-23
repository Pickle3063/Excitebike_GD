using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_RampCon : MonoBehaviour {

    MP_GroundControl GCon;
    MP_AirControl ACon;
    MP_Boost_Accel Accel;
    MP_LaneValues lValue;
    MP_Crash Crashing;

    Quaternion resetRot;

   [SerializeField] bool wasWheelie;
    [SerializeField] float forCrashTime;
    bool WasFor;
    bool GroundToAirSwitch;
   

    // Use this for initialization
    void Start()
    {
        GCon = GetComponent<MP_GroundControl>();
        ACon = GetComponent<MP_AirControl>();
        Accel = GetComponent<MP_Boost_Accel>();
        lValue = GetComponent<MP_LaneValues>();
        Crashing = GetComponent<MP_Crash>();
        resetRot = new Quaternion(0f, 0f, 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        wasWheelie = GCon.GetIsWheelie();
        
    }

    private void OnTriggerEnter(Collider other)
    {
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
            transform.rotation = Quaternion.Slerp(transform.rotation, resetRot, 1f * Time.deltaTime);
            
        }
    }

    public bool GetGTASwitch()
    {
        return GroundToAirSwitch;
    }
    public void SetWasWheelieFalse()
    {
        wasWheelie = false;
    }
    public bool GetWasWheelie()
    {
        return wasWheelie;
    }
}
