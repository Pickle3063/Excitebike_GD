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

        if (isOverheated)
        {
            BoostScript.StopBoost();
        }
	}

    public void ChangeIsOverheated()
    {
        isOverheated = !isOverheated;
        if (isOverheated)
        {
            LaneSwitch.ChangeNeedTopLane();
        }
        else
        {
            LaneSwitch.ChangeNeedTopLane();
        }
    }

    public bool GetIsOverheated()
    {
        return isOverheated;
    }
}
