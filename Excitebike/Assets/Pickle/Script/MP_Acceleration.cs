using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Acceleration : MP_Controls {
    //tracks acceleration
    float speed;
    //prevents acceleration from going past this number(set in the inspector)
    [SerializeField] float maxSpeed;
    //checking if the player is stopped
    bool stopped;
    //getting the floor, as the player never moves forward, instead the floor moves left
    GameObject floor;
    //prevents player from going backwards
    float minSpeed = 0;

	// Use this for initialization
	void Start () {
        //finds the GameObject named floor and saves it to be moved later, is case sensitive
        floor = GameObject.Find("floor");
	}
	
    //controls acceleration, is called in the controls script
    public void Accelerate()
    {
        //print("Accelerate");
        //tells the script the player is no longer stopped
        stopped = false;
        //this moves the floor to the left, multiplied by speed which is constantly increased while button is held
        floor.transform.Translate(Vector2.left * (speed += (Time.deltaTime * .1f)));
        //prevents speed from going too high
        if(speed > maxSpeed)
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
            floor.transform.Translate(Vector2.left * (speed -= (Time.deltaTime * .1f)));
            //prevents speed from going negative
            if (speed < minSpeed)
            {
                speed = minSpeed;
                //tells script player is stopped when they hit 0 speed
                stopped = true;
            }
            
        }
    }

    public float GetSpeed()
    {
        return speed;
    }

}
