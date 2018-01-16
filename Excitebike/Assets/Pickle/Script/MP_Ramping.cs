using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_Ramping : MonoBehaviour {

    [SerializeField] float speed;
    float newHeight;
    Vector3 curPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		curPos = new Vector3(-32.984f, newHeight, -2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ramp")
        {
            GetComponent<MP_ChangeLanes>().enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Ramp")
        {
            if (Input.GetKey(KeyCode.W))
            {
                newHeight = transform.position.y + 1;
                transform.position = Vector3.Lerp(transform.position, curPos, 0.1f);
            }
            if (Input.GetKey(KeyCode.S))
            {
                newHeight = transform.position.y - 1;
                transform.position = Vector3.Lerp(transform.position, curPos, 0.1f);
            }
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ramp")
        {
            GetComponent<MP_ChangeLanes>().enabled = true;
        }
    }
}
