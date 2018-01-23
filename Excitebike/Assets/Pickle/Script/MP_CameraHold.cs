using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_CameraHold : MonoBehaviour {
<<<<<<< HEAD

    Vector3 Pos;
    float yVal;
	// Use this for initialization
	void Start () {
		 
       
       

    }
	
	// Update is called once per frame
	void Update () {

        yVal = GameObject.Find("Camerahold").transform.position.y;
        Pos = new Vector3(GameObject.Find("PlayerContainer").transform.position.x, yVal, -5);
        transform.position = Pos;
    }


    public void CamPosPlus()
    {
        yVal = yVal + 1;
        
    }

    public void CamPosMin()
    {
        yVal = yVal - 1;
        
    }

=======
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
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
}
