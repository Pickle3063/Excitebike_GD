using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Boost_Accel : MonoBehaviour {

    //works exactly like the script MP_Acceleration
    [SerializeField] float speed;
    bool boosting;
<<<<<<< HEAD
    bool canFill;
    //checking if the player is stopped
    bool stopped;

=======
    //checking if the player is stopped
    bool stopped;

    //prevents boost from passing this speed
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    [SerializeField] float maxBoostSpeed;
    //prevents acceleration from going past this number(set in the inspector)
    [SerializeField] float maxSpeed;
    float minSpeed = 0;
<<<<<<< HEAD
    GameObject PCont;
 
    [SerializeField] private float bar;
    private float bar_tofill = 10.0F;  //# of seconds it takes to fill bar
    private float bar_usage = 5.0F;   //No of seconds it can be used for
    float maxBar = 20f;

    public GameObject tempMeter;

     GameObject mudslide;

    [SerializeField] float OverheatTimer;
=======
    //the player container
    GameObject PCont;
 
    private float bar; //overheating bar
    private float bar_tofill = 10.0F;  //# of seconds it takes to fill bar
    private float bar_usage = 5.0F;   //No of seconds it can be used for
    float maxBar = 20f; //setting the full bar's value

    public GameObject tempMeter;

    [SerializeField] float OverheatTimer; //setting how long to be crashed from an overheat
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae

    MP_LaneValues LaneSwitch;
    MP_Overheat Heating;

    // Use this for initialization
    void Start()
    {
        PCont = GameObject.Find("PlayerContainer");
<<<<<<< HEAD
        mudslide = GameObject.Find("Mudslide");
        
=======
        
        //sets the overheat bar to it's max value
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
        bar = maxBar;
        LaneSwitch = GetComponent<MP_LaneValues>();
        Heating = GetComponent<MP_Overheat>();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if(bar>= maxBar)
        {
            canFill = false;
        }

        
    }

    void FixedUpdate()
    {

        if (!canFill)
        {
            bar -= bar_usage * Time.deltaTime;
            if (bar <= 0)
            {
                boosting = false;
                bar = maxBar;
                speed = minSpeed;
                LaneSwitch.OverheatTime();
                Heating.ChangeIsOverheated();

                //reset your speed here to what it was before

            }

        }
        else
        {
            if (bar < maxBar)
            {
                bar += bar_tofill * Time.deltaTime;
            }

        }

        tempMeter = GameObject.Find("TempBar");
        //scaling the tempmeter to match the level of overheat
        Vector3 barSize = Vector3.zero;
        barSize.x = bar / -15;
        barSize.y = 0.4157013f;
        barSize.z = 1;
        tempMeter.transform.localScale = barSize;




        //moving it forward a little bit so it only "grows to the right"
        Vector3 tempPos = tempMeter.transform.localPosition;
        tempPos.x = -1.2f - tempMeter.transform.localScale.x / 2;
        tempMeter.transform.localPosition = tempPos;


    }

    void OnTriggerEnter(Collider mudslide)
    {
        if (mudslide.name == "Mudslide")
        {
            speed = speed / 2;
            Debug.Log("Test");
        }
    }

    //controls acceleration, is called in the controls script
    public void Accelerate()
=======
        
    }

    void FixedUpdate()
    {

        tempMeter = GameObject.Find("TempBar");
        //scaling the tempmeter to match the level of overheat
        Vector3 barSize = Vector3.zero;
    barSize.x = bar / -15;
        barSize.y = 0.4157013f;
        barSize.z = 1;
        tempMeter.transform.localScale = barSize;

        //moving it forward a little bit so it only "grows to the right"
        Vector3 tempPos = tempMeter.transform.localPosition;
    tempPos.x = -1.2f - tempMeter.transform.localScale.x / 2;
        tempMeter.transform.localPosition = tempPos;


    }

//controls acceleration, is called in the controls script
public void Accelerate()
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    {
        //print("Accelerate");
        //tells the script the player is no longer stopped
        stopped = false;
        //this moves the floor to the left, multiplied by speed which is constantly increased while button is held
<<<<<<< HEAD
        PCont.transform.Translate(Vector2.right * (speed += (Time.deltaTime * .15f)));

       
        //prevents speed from going too high
=======
        PCont.transform.Translate(Vector2.right * (speed += (Time.deltaTime * .15f)));

       

        //prevents speed from going too high
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }

    }
    //controls deceleration, is called in the controls script
    public void Decelerate()
    {
<<<<<<< HEAD
=======
       
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
        //checks if player is moving(not stopped)
        if (!stopped)
        {
            //slows the rate at which the floor is moved but still moves the floor to simulate deceleration
            PCont.transform.Translate(Vector2.right * (speed -= (Time.deltaTime * .1f)));

            //prevents speed from going negative
            if (speed < minSpeed)
            {
                speed = minSpeed;
                //tells script player is stopped when they hit 0 speed
                stopped = true;
            }

        }
    }

    public void Boost()
    {
        //print("Boost");
        boosting = true;
        
        //the only difference other than the stopped/boosting bool is this, it leaves Time.deltaTime normal, can be increased by multiplying Time.deltaTime;
<<<<<<< HEAD
        PCont.transform.Translate(Vector2.right * (speed += (Time.deltaTime * .15f)));
        
=======
        PCont.transform.Translate(Vector2.right * (speed += (Time.deltaTime * .15f)));
        //depletes bar while boosting
        bar -= bar_usage * Time.deltaTime;
        //checks if bar is out, overheats if true
        if (bar <= 0)
        {
            //stops your boost
            boosting = false;
            //resets bar and speed
            bar = maxBar;
            speed = minSpeed;
            //sets the crash timer and sets overheated to true
            LaneSwitch.OverheatTime();
            Heating.ChangeIsOverheated();
        }
        //stops boost speed from going over max
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
        if (speed > maxBoostSpeed)
        {
            speed = maxBoostSpeed;
        }
    }

<<<<<<< HEAD
    public void StopBoost()
    {
        canFill = true;
        if (boosting)
        {
=======
    //controls deceleration of boost
    public void StopBoost()
    {
        //if the bar is less than max then fill it up
       if(bar < maxBar)
        {
            bar += bar_tofill * Time.deltaTime;
        }
        if (boosting)
        {
            //slows player and checks for max and min speed of regular acceleration
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
            PCont.transform.Translate(Vector2.right * (speed -= Time.deltaTime * .1f));
            if(speed > maxSpeed)
            {
                speed = maxSpeed - .9f;
            }
          
            if (speed < minSpeed)
            {
                speed = minSpeed;
                boosting = false;
            }
        }
    }

<<<<<<< HEAD
=======
    //for cutting the current speed in half
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    public void HalveSpeed()
    {
        speed = speed * 0.5f;
    }

<<<<<<< HEAD
=======
    //for setting the current speed to a quarter of itself
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    public void QuarterSpeed()
    {
        speed = speed * 0.25f;
    }

<<<<<<< HEAD
=======
    //sets speed to 0
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    public void ResetSpeed()
    {
        speed = 0;
    }

<<<<<<< HEAD
=======
    //gets current speed
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    public float GetSpeed()
    {
        return speed;
    }

<<<<<<< HEAD
=======
    //checks the stopped boolean
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    public bool GetStopped()
    {
        return stopped;
    }

<<<<<<< HEAD
=======
    //the timer for overheating
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    public float GetOverheatTime()
    {
        return OverheatTimer;
    }
}
