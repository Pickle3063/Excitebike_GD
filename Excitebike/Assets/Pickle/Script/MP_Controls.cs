using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Controls : MonoBehaviour {

    bool canAccel;
    bool canBoost;
    bool canRot;

<<<<<<< HEAD
    MP_LaneValues lValues;
    MP_CameraHold CamHold;

    // Use this for initialization
    void Start() {
        canAccel = true;
        canBoost = true;
        canRot = true;
        lValues = GetComponent<MP_LaneValues>();
        CamHold = GameObject.FindWithTag("MainCamera").GetComponent<MP_CameraHold>();
=======
    // Use this for initialization
    void Start() {
        //bools to check if the player can accelerate, boost or rotate(wheelie)
        canAccel = true;
        canBoost = true;
        canRot = true;
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //print("A button pressed");
<<<<<<< HEAD
=======
            //after A button is pressed it checks if you can currently accelerate, then it calls the acceleration function
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
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
<<<<<<< HEAD
=======
            //checks if you can boost after B button press, if you can then it calls the boosting function
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
            if (canBoost)
            {
                gameObject.GetComponent<MP_Boost_Accel>().Boost();
            }
        }
        //if not holding buttong to boost then it calls the function that stops boosting and decelerates below threshold for boosting
        else
        {
            gameObject.GetComponent<MP_Boost_Accel>().StopBoost();
<<<<<<< HEAD
        }


        if (Input.GetKey(KeyCode.W) && lValues.GetTimePassed() > lValues.GetTimer())
        {
            CamHold.CamPosPlus();

=======
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
        }
        if (Input.GetKey(KeyCode.S) && lValues.GetTimePassed() > lValues.GetTimer())
        {

<<<<<<< HEAD
            CamHold.CamPosMin();
       

        }
        if (Input.GetKey(KeyCode.A))
        {
            // print("LEFT Directional pressed");
=======
        //these controls only work when you are on the ground
        if (Input.GetKey(KeyCode.A))
        {
            // print("LEFT Directional pressed");
            //checks if you can rotate then calls the rotation function, making the player do a wheelie
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
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

<<<<<<< HEAD
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
=======
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
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
}
