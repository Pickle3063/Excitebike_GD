using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Ramping : MonoBehaviour {

    float newHeight;
    Vector3 curPos;
    int Lane;
    float timePassed;
    float timer = .2f;

    MP_ChangeLanes Switchlanes;

    // Use this for initialization
    void Start() {
        Switchlanes = GetComponent<MP_ChangeLanes>();
    }

    // Update is called once per frame
    void Update() {
        curPos = new Vector3(-32.984f, newHeight, -2);
        timePassed += Time.deltaTime;

        if (Lane == 4)
        {
            Lane = 3;
        }

        SelectHeight();
    }

    public int GetLaneNumber()
    {
        return Lane;
    }

    void SelectHeight()
    {
        if (Lane == 0)
        {
            newHeight = -1.4f;
        }
        if (Lane == 1)
        {
            newHeight = -0.4f;
        }
        if (Lane == 2)
        {
            newHeight = 0.6f;
        }
        if (Lane == 3)
        {
            newHeight = 1.6f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ramp")
        {
            GetComponent<MP_ChangeLanes>().enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ramp")
        {
            if (Input.GetKeyDown(KeyCode.W) && timePassed > timer && Lane != 3)
            {
                Lane++;

                transform.SetPositionAndRotation(curPos, transform.rotation);

                timePassed = 0;

            }
            if (Input.GetKeyDown(KeyCode.S) && timePassed > timer && Lane != 0)
            {

                Lane--;

                transform.SetPositionAndRotation(curPos, transform.rotation);
                timePassed = 0;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ramp")
        {
            GetComponent<MP_ChangeLanes>().enabled = true;
            //Switchlanes.ExitRampState();
        }
    }

    public void LaneOne()
    {
        Lane = 0;
    }

    public void LaneTwo()
    {
        Lane = 1;
    }

    public void LaneThree()
    {
        Lane = 2;
    }
    public void LaneFour()
    {
        Lane = 3;
    }
}
