using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Boost : MonoBehaviour {

    //works exactly like the script MP_Acceleration

    //works exactly like the script MP_Acceleration
    float speed;
    bool boosting;
    GameObject floor;
    [SerializeField] float maxSpeed;
    float minSpeed = 0;

    [SerializeField] private float bar;
    private float bar_tofill = 10.0F;  //# of seconds it takes to fill bar
    private float bar_usage = 5.0F;   //No of seconds it can be used for
    float maxBar = 20;

    public GameObject tempMeter;

    [SerializeField] float OverheatTimer;

    MP_ChangeLanes LaneSwitch;
    MP_Overheat Heating;

    // Use this for initialization
    void Start()
    {
        floor = GameObject.Find("floor");
        bar = maxBar;
        LaneSwitch = GetComponent<MP_ChangeLanes>();
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
                //bar = maxBar;
                speed = minSpeed;
                //LaneSwitch.OverheatTime();
                Heating.ChangeIsOverheated();
                bar = 0.1f;

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
