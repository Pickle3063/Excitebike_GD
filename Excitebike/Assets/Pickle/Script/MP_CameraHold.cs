using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_CameraHold : MonoBehaviour {

    Vector3 Pos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Pos = new Vector3(GameObject.Find("PlayerContainer").transform.position.x, 0.59f + GameObject.Find("floor").transform.position.y, -10);
        transform.SetPositionAndRotation(Pos, transform.rotation);
	}
}
