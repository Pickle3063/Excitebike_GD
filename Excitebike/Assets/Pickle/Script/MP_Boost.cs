using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Boost : MonoBehaviour {

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
        floor.transform.Translate(Vector2.left * (speed += (Time.deltaTime * 2)));

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
