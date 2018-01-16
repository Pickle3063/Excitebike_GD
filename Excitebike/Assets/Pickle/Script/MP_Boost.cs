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

    private float bar = 0.0F;
    private float bar_tofill = 30.0F;  //# of seconds it takes to fill bar
    private float bar_usage = 10.0F;   //No of seconds it can be used for

    // Use this for initialization
    void Start () {
        floor = GameObject.Find("floor");
	}
	
	// Update is called once per frame
	void Update () {

        if (boosting)
        {
            bar -= (1F / bar_usage) * Time.deltaTime;
            if (bar <= 0)
            {
                boosting = false;
                bar = 0;
                speed = minSpeed;
                print("out of gas");
                gameObject.GetComponent<MP_ChangeLanes>().MoveUp();
                //reset your speed here to what it was before
              
            }
            
        }
        else if(bar < 1)
 {
            bar += (1F / bar_tofill) * Time.deltaTime;

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
