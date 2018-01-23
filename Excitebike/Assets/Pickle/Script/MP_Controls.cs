using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Controls : MonoBehaviour {

    bool canAccel;
    bool canBoost;
    bool canRot;

    // Use this for initialization
    void Start() {
        canAccel = true;
        canBoost = true;
        canRot = true;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //print("A button pressed");
            if (canAccel)
            {
                gameObject.GetComponent<MP_Boost_Accel>().Accelerate();
            }

        }
        else
        {
            gameObject.GetComponent<MP_Boost_Accel>().Decelerate();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //print("B button pressed");
            if (canBoost)
            {
                gameObject.GetComponent<MP_Boost_Accel>().Boost();
            }
        }
        else
        {
            gameObject.GetComponent<MP_Boost_Accel>().StopBoost();
        }

        if (Input.GetKey(KeyCode.A))
        {
            // print("LEFT Directional pressed");
            if (canRot)
            {
                gameObject.GetComponent<MP_GroundControl>().IncreaseRot();
            }
        }
        else
        {
            gameObject.GetComponent<MP_GroundControl>().DecreaseRot();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            // print("START button pressed");
        }

        if (Input.GetKeyDown(KeyCode.Quote))
        {
            // print("SELECT button pressed");
        }
    }

    public bool GetCanAccel()
    {
        return canAccel;
    }
    public void ChangeCanAccel()
    {
        canAccel = !canAccel;
    }

    public bool GetCanBoost()
    {
        return canBoost;
    }
    public void ChangeCanBoost()
    {
        canBoost = !canBoost;
    }

    public bool GetCanRot()
    {
        return canRot;
    }
    public void ChangeCanRot()
    {
        canRot = !canRot;
    }
}
