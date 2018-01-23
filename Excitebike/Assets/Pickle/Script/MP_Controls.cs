using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Controls : MonoBehaviour {

    bool canAccel;
    bool canBoost;
    bool canRot;

    // Use this for initialization
    void Start() {
        //bools to check if the player can accelerate, boost or rotate(wheelie)
        canAccel = true;
        canBoost = true;
        canRot = true;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //print("A button pressed");
            //after A button is pressed it checks if you can currently accelerate, then it calls the acceleration function
            if (canAccel)
            {
                gameObject.GetComponent<MP_Boost_Accel>().Accelerate();
            }

        }
        //if you are no longer holding down the button it calls the deceleration function
        else
        {
            gameObject.GetComponent<MP_Boost_Accel>().Decelerate();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //print("B button pressed");
            //checks if you can boost after B button press, if you can then it calls the boosting function
            if (canBoost)
            {
                gameObject.GetComponent<MP_Boost_Accel>().Boost();
            }
        }
        //if not holding buttong to boost then it calls the function that stops boosting and decelerates below threshold for boosting
        else
        {
            gameObject.GetComponent<MP_Boost_Accel>().StopBoost();
        }

        //these controls only work when you are on the ground
        if (Input.GetKey(KeyCode.A))
        {
            // print("LEFT Directional pressed");
            //checks if you can rotate then calls the rotation function, making the player do a wheelie
            if (canRot)
            {
                gameObject.GetComponent<MP_GroundControl>().IncreaseRot();
            }
        }
        //if you stop pressing the button it calls the function to return the player back to starting rotation
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

    //for getting and toggling the  different booleans
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
