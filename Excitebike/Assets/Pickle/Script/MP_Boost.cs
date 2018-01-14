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

	// Use this for initialization
	void Start () {
        floor = GameObject.Find("floor");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Boost()
    {
        print("Boost");
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
            }
        }
    }
}
