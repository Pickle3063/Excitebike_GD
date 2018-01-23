using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_CameraHold : MonoBehaviour {
    //the position the camera should move to
    Vector3 Pos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //setting up the position, the X is the player, the Y is where it is in correlation with the floor, and the Z is how far back it is
        Pos = new Vector3(GameObject.Find("PlayerContainer").transform.position.x, 0.59f + GameObject.Find("floor").transform.position.y, -10);
        //sets the position to Pos
        transform.SetPositionAndRotation(Pos, transform.rotation);
	}
}
