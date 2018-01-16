using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MP_ChangeLanes : MonoBehaviour {

    //sets up the lanes as states
    enum LaneStates
    {
        ONE,//bottom lane
        TWO,//second lane up
        THREE,//third lane up
        FOUR,//fourth lane up
        RECLANE//where the player goes after crashing or overheating
    }

    //sets current state as lane three(second from the top)
    [SerializeField] LaneStates curState = LaneStates.ONE;
    Dictionary<LaneStates, Action> fsm = new Dictionary<LaneStates, Action>();

    //the heights of the four different lanes
    [SerializeField] float heightOne = -1.4f;
    [SerializeField] float heightTwo = -0.4f;
    [SerializeField] float heightThree = 0.6f;
    [SerializeField] float heightFour = 1.6f;
    [SerializeField] float heightRec = 2.6f;

    //speed at which the player changes lanes
    [SerializeField] float speed;

    //used to change the player's height(changing lanes)
    Vector3 curPos;

    //stops the state change from being called back to back
    [SerializeField] float timer = 0.2f;
    [SerializeField] float timePassed;
    //secondary timer for when you crash
    [SerializeField] float crashTimer;

    //checks if the player needs to go to the lane above four for overheating or crashing
    bool needTopLane = false;

    //accessing scripts
    MP_Crash Crashing;
    MP_Controls Controls;
    MP_Acceleration Accel;
    MP_GroundControl GroundCon;

    // Use this for initialization
    void Start() {
        //adding the four states to the dictionary
        fsm.Add(LaneStates.ONE, new Action(StateOne));
        fsm.Add(LaneStates.TWO, new Action(StateTwo));
        fsm.Add(LaneStates.THREE, new Action(StateThree));
        fsm.Add(LaneStates.FOUR, new Action(StateFour));
        fsm.Add(LaneStates.RECLANE, new Action(StateRec));
        SetState(LaneStates.ONE);

        curPos = transform.position;

        Crashing = GetComponent<MP_Crash>();
        Controls = GetComponent<MP_Controls>();
        Accel = GetComponent<MP_Acceleration>();
        GroundCon = GetComponent<MP_GroundControl>();
    }

    // Update is called once per frame
    void Update() {
        //continues to call current state every frame
        fsm[curState].Invoke();
        //sets the current position every frame
        //transform.SetPositionAndRotation(curPos, transform.rotation);

        transform.position = Vector3.Lerp(transform.position, curPos, speed * Time.deltaTime);

        //timer
        timePassed += Time.deltaTime;

        //checks if player has crashed OR overheated
        if (needTopLane)
        {
            //slowly moves player to the recovery lane
            if (timePassed > timer && curState != LaneStates.RECLANE)
            {
                //disables player input, it needs both disabled for some reason
                Controls.enabled = false;
                Accel.enabled = false;
                
                //looping timer and state change
                timePassed = 0;
                curState++;
                
            }
        }
        
    }

    //used to set the timer to the crash time for a wheelie
    public void WheelieCrash()
    {
        crashTimer = GroundCon.GetWheelieTime();
    }

    //used by MP_Crash to speed up the timer during a crash
    public void SpeedUpCrashTime()
    {
        timePassed = timePassed + Crashing.GetSpeedUpTime();
    }

    //toggles boolean
    public void ChangeNeedTopLane()
    {
        needTopLane = !needTopLane;
    }

    //for checking true or false in other scripts
    public bool GetNeedTopLane()
    {
        return needTopLane;
    }

    //called in controls, moves the player up a lane
    public void MoveUp()
    {
        //prevents lane from going above four
        //moves lane up one
        if(curState != LaneStates.FOUR && timePassed > timer)
        {
            //resetting timer then switching states
            timePassed = 0;
            curState++;
            
        }
        
    }

    public void MoveDown()
    {
        //prevents lane from going below one
        //moves lane down one
       if(curState != LaneStates.ONE && timePassed > timer)
        {
            //resetting timer then switching states
            timePassed = 0;
            curState--;
            
        }
    }

    //sets the height for each lane
    void StateOne()
    {
        curPos = new Vector3(-32.984f, heightOne, -2);
        
    }

    void StateTwo()
    {
        curPos = new Vector3(-32.984f, heightTwo, -2);
       
    }
    
    void StateThree()
    {
        curPos = new Vector3(-32.984f, heightThree, -2);
      
    }

    void StateFour()
    {
        curPos = new Vector3(-32.984f, heightFour, -2);
      
    }

    void StateRec()
    {
        curPos = new Vector3(-32.984f, heightRec, -2);

        //insert if check for overheating
        /*if(isOverheating){
         * if(!overheating{
         * curState = LaneStates.FOUR;
         * }
         * }
         */
        //checking if the reason for going to this state if for crashing
        if (Crashing.GetIsCrashed())
        {
            //keeps player in recovery lane for set amount of time
            if(timePassed > crashTimer)
            {
                //resets timer, toggles isCrashed, changes lane to the top lane, reenables input
                timePassed = 0;
                Crashing.ChangeIsCrashed();
                curState = LaneStates.FOUR;
                Controls.enabled = true;
                Accel.enabled = true;
            }
        }
    }
   
    void SetState(LaneStates newState)
    {
        curState = newState;
    }
}
