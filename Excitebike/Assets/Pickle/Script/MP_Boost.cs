using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Boost : MonoBehaviour {

    //works exactly like the script MP_Acceleration
    float speed;
    bool boosting;
    GameObject floor;
    [SerializeField] float maxSpeed;
    float minSpeed = 0;

    private float bar = 0.0F; //bar at start
    private float bar_tofill = 30.0F;  //# of seconds it takes to fill bar
    private float bar_usage = 10.0F;   //No of seconds it can be used for

    MP_Crash Overheat;
    MP_ChangeLanes LaneSwitch;
    


    // Use this for initialization
    void Start () {
        floor = GameObject.Find("floor");
        
        

    }

    // Update is called once per frame
    void Update () {
		
	}

     void FixedUpdate()
    {

        if (boosting)
        {
            bar -= (1F / bar_usage) * Time.deltaTime; //If player is boosting the bar/fuel is reduced to 0 over a period of m_tank_usage seconds

            if (bar <= 0)
            {
                boosting = false;
                bar = 0;
                speed = minSpeed;
                print("out of gas");
         
                //consequences of bar <= 0, overheating script to be placed here.

            }
            else
            {
               
                //else to make sure controls aren't disabled for good without a way to be activated again.
            }


        }
        else if (bar < 1)
        {
            bar += (1F / bar_tofill) * Time.deltaTime; //If you're just travelling normally your tank will fill up over a period of m_tank_tofill seconds.

        }

    }

    public void Boost()
    {
        //print("Boost");
        boosting = true;
        //the only difference other than the stopped/boosting bool is this, it leaves Time.deltaTime normal, can be increased by multiplying Time.deltaTime;
        floor.transform.Translate(Vector2.left * (speed += (Time.deltaTime)));

        if(speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }

    public void StopBoost()
    {
        if (boosting)
        {
            floor.transform.Translate(Vector2.left * (speed -= Time.deltaTime * .5f));
            if(speed < minSpeed)
            {
                speed = minSpeed;
                boosting = false;
            }
        }
    }
}
