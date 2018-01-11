using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Controls : MonoBehaviour {

    MP_Acceleration ACC;
    MP_Boost BST;

	// Use this for initialization
	void Start () {
        ACC = gameObject.GetComponent<MP_Acceleration>();
        BST = gameObject.GetComponent<MP_Boost>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            print("A button pressed");

            ACC.Accelerate();
        }
        else
        {
            ACC.Decelerate();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            print("B button pressed");

            BST.Boost();
        }
        else
        {
            BST.StopBoost();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            print("UP Directional pressed");


        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            print("DOWN Directional pressed");


        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            print("LEFT Directional pressed");


        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            print("RIGHT Directional pressed");


        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            print("START button pressed");


        }

        if (Input.GetKeyDown(KeyCode.Quote))
        {
            print("SELECT button pressed");


        }

    }
}
