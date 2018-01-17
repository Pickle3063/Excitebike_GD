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

    [SerializeField] private float bar;
    private float bar_tofill = 30.0F;  //# of seconds it takes to fill bar
    private float bar_usage = 10.0F;   //No of seconds it can be used for
    float maxBar = 50f;

    [SerializeField] float OverheatTimer;

    MP_LaneValues LaneSwitch;
    MP_Overheat Heating;

    // Use this for initialization
    void Start()
    {
        floor = GameObject.Find("floor");
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

        if (boosting)
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

    }

    public void Boost()
    {
        //print("Boost");
        boosting = true;
        //the only difference other than the stopped/boosting bool is this, it leaves Time.deltaTime normal, can be increased by multiplying Time.deltaTime;
        floor.transform.Translate(Vector2.left * (speed += (Time.deltaTime * .15f)));

        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }

    public void StopBoost()
    {
        if (boosting)
        {
            floor.transform.Translate(Vector2.left * (speed -= Time.deltaTime * .1f));
            if (speed < minSpeed)
            {
                speed = minSpeed;
                boosting = false;
            }
        }
    }

    public float GetOverheatTime()
    {
        return OverheatTimer;
    }
}
