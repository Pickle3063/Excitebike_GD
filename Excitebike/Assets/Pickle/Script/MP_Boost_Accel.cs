using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Boost_Accel : MonoBehaviour {

    //works exactly like the script MP_Acceleration
    [SerializeField] float speed;
    bool boosting;
    //checking if the player is stopped
    bool stopped;

    //prevents boost from passing this speed
    [SerializeField] float maxBoostSpeed;
    //prevents acceleration from going past this number(set in the inspector)
    [SerializeField] float maxSpeed;
    float minSpeed = 0;
    //the player container
    GameObject PCont;
 
    private float bar; //overheating bar
    private float bar_tofill = 10.0F;  //# of seconds it takes to fill bar
    private float bar_usage = 5.0F;   //No of seconds it can be used for
    float maxBar = 20f; //setting the full bar's value

    public GameObject tempMeter;

    [SerializeField] float OverheatTimer; //setting how long to be crashed from an overheat

    MP_LaneValues LaneSwitch;
    MP_Overheat Heating;

    // Use this for initialization
    void Start()
    {
        PCont = GameObject.Find("PlayerContainer");
        
        //sets the overheat bar to it's max value
        bar = maxBar;
        LaneSwitch = GetComponent<MP_LaneValues>();
        Heating = GetComponent<MP_Overheat>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    {
        //print("Accelerate");
        //tells the script the player is no longer stopped
        stopped = false;
        //this moves the floor to the left, multiplied by speed which is constantly increased while button is held
        PCont.transform.Translate(Vector2.right * (speed += (Time.deltaTime * .15f)));

       

        //prevents speed from going too high
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }

    }
    //controls deceleration, is called in the controls script
    public void Decelerate()
    {
       
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
        if (speed > maxBoostSpeed)
        {
            speed = maxBoostSpeed;
        }
    }

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

    //for cutting the current speed in half
    public void HalveSpeed()
    {
        speed = speed * 0.5f;
    }

    //for setting the current speed to a quarter of itself
    public void QuarterSpeed()
    {
        speed = speed * 0.25f;
    }

    //sets speed to 0
    public void ResetSpeed()
    {
        speed = 0;
    }

    //gets current speed
    public float GetSpeed()
    {
        return speed;
    }

    //checks the stopped boolean
    public bool GetStopped()
    {
        return stopped;
    }

    //the timer for overheating
    public float GetOverheatTime()
    {
        return OverheatTimer;
    }
}
