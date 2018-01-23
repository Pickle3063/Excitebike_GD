using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Overheat : MonoBehaviour {

    bool isOverheated;

    MP_LaneValues LaneSwitch;
    MP_Boost_Accel BoostScript;

	// Use this for initialization
	void Start () {
        LaneSwitch = GetComponent<MP_LaneValues>();
        BoostScript = GetComponent<MP_Boost_Accel>();
	}
	
	// Update is called once per frame
	void Update () {

        //stops the use of boost while you are overheating
        if (isOverheated)
        {
            BoostScript.StopBoost();
        }
	}

    //toggles overheating
    public void ChangeIsOverheated()
    {
        isOverheated = !isOverheated;
        //if overheating then you need the recovery lane
        if (isOverheated)
        {
            LaneSwitch.NeedTopLaneTrue();
        }
        //if not overheating then you don't need the recovery lane anymore
        else
        {
            LaneSwitch.NeedTopLaneFalse();
        }
    }

    //for other scripts to check the state of the bool
    public bool GetIsOverheated()
    {
        return isOverheated;
    }
}
