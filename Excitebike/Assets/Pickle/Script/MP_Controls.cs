using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Controls : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            print("A button pressed");
            //these are written out because I was experiencing weird NullReferenceExcpetions when I made shortcuts
            gameObject.GetComponent<MP_Acceleration>().Accelerate();
        }
        else
        {
            gameObject.GetComponent<MP_Acceleration>().Decelerate();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            print("B button pressed");
            gameObject.GetComponent<MP_Boost>().Boost();
        }
        else
        {
            gameObject.GetComponent<MP_Boost>().StopBoost();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            print("UP Directional pressed");
            gameObject.GetComponent<MP_ChangeLanes>().MoveUp();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            print("DOWN Directional pressed");
            gameObject.GetComponent<MP_ChangeLanes>().MoveDown();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            print("LEFT Directional pressed");
            gameObject.GetComponent<MP_GroundControl>().IncreaseRot();
        }
        else
        {
            gameObject.GetComponent<MP_GroundControl>().DecreaseRot();
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

    /*void AButton()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            print("A button pressed");
            //these are written out because I was experiencing weird NullReferenceExcpetions when I made shortcuts
            gameObject.GetComponent<MP_Acceleration>().Accelerate();
        }
        else
        {
            gameObject.GetComponent<MP_Acceleration>().Decelerate();
        }
    }

    void BButton()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            print("B button pressed");
            gameObject.GetComponent<MP_Boost>().Boost();
        }
        else
        {
            gameObject.GetComponent<MP_Boost>().StopBoost();
        }
    }

    void UpDirectional()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            print("UP Directional pressed");
            gameObject.GetComponent<MP_ChangeLanes>().MoveUp();
        }
    }

    void DownDirectional()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            print("DOWN Directional pressed");
            gameObject.GetComponent<MP_ChangeLanes>().MoveDown();
        }
    }

    void LeftDirectional()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            print("LEFT Directional pressed");
            gameObject.GetComponent<MP_GroundControl>().IncreaseRot();
        }
        else
        {
            gameObject.GetComponent<MP_GroundControl>().DecreaseRot();
        }
    }

    void RightDirectional()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            print("RIGHT Directional pressed");
        }
    }

    void StartButton()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            print("START button pressed");
        }
    }

    void SelectButton()
    {
        if (Input.GetKeyDown(KeyCode.Quote))
        {
            print("SELECT button pressed");
        }
    }*/
}
