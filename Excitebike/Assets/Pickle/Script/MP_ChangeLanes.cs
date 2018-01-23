using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_ChangeLanes : ByTheTale.StateMachine.MachineBehaviour
{
   
    //adding the individual lane states
    public override void AddStates()
    {
        AddState<LaneOne>(); //bottom lane
        AddState<LaneTwo>();
        AddState<LaneThree>();
        AddState<LaneFour>(); //top lane
        AddState<RecLane>(); //recovery lane

        //setting the starting lane
        SetInitialState<LaneOne>();
    }

}

public class MP_ChangeLanesState : ByTheTale.StateMachine.State
{
    protected MP_LaneValues lValues;
    protected MP_Boost_Accel Accel;
    protected MP_Controls Control;
    protected MP_Overheat Heating;
    protected MP_Crash Crashing;
    
    //gets the floor object which contains all of the visual parts of the track
    protected GameObject floor = GameObject.Find("floor");
    //the position to move to when used
    protected Vector3 newPos;
    //gets the three small half ramps on the track, can be added or reduced for each track
    protected GameObject SHRampOne;
    protected GameObject SHRampTwo;
    protected GameObject SHRampThree;

    //used in states to have references set
    public override void Enter()
    {
        lValues = GetMachine<MP_ChangeLanes>().GetComponent<MP_LaneValues>();
        Accel = GetMachine<MP_ChangeLanes>().GetComponent<MP_Boost_Accel>();
        Control = GetMachine<MP_ChangeLanes>().GetComponent<MP_Controls>();
        Heating = GetMachine<MP_ChangeLanes>().GetComponent<MP_Overheat>();
        Crashing = GetMachine<MP_ChangeLanes>().GetComponent<MP_Crash>();
        
        //finds the individual ramp colliders by name
        SHRampOne = GameObject.Find("SHR");
        SHRampTwo = GameObject.Find("SHR1");
        SHRampThree = GameObject.Find("SHR2");
        //sets the timepassed to 0 on the script referenced
        lValues.ResetTimer();


    }

    public override void Execute()
    {
        //moves the floor to whatever is set as newPos in each state, simulates a change in lanes
        floor.transform.position = Vector3.Lerp(floor.transform.position, newPos, lValues.GetSpeed() * Time.deltaTime);
        //checks if player has crashed OR overheated
        if (lValues.GetNeedToplane())
        {
            //if timer allows it then you move to the recovery lane
            if (lValues.GetTimePassed() > lValues.GetTimer() && !machine.IsCurrentState<RecLane>())
            {
                machine.ChangeState<RecLane>();
            }
        }
    }
}

public class LaneOne : MP_ChangeLanesState
{
 
    public override void Enter() {
        //calls the enter that sets up the references and resets the timer
        base.Enter();
        //sets the newPos for lane one
        newPos = new Vector3(29.7f, lValues.GetHeightOne(), 2.47f);
        
        Debug.Log("entered lane one");
    }
   
    public override void Execute()
    {
        //calls the execute set up in the changelanesstate
        base.Execute();
       
        //checks for the Up directional and the timer to be complete(prevents lane skipping), which moves the lane up one
        if (Input.GetKey(KeyCode.W) && lValues.GetTimePassed() > lValues.GetTimer())
        {
            
            machine.ChangeState<LaneTwo>();

        }
        
        
    }

    

    public override void Exit() { }
   
}

public class LaneTwo : MP_ChangeLanesState
{
    
    public override void Enter()
    {
        base.Enter();
        //sets the newPos to lane two
        newPos = new Vector3(29.7f, lValues.GetHeightTwo(), 2.47f);
        
        Debug.Log("entered lane two");
    }

    public override void Execute()
    {
        base.Execute();
        //disables the small half ramp colliders upon entering this lane as the ramp only takes up the third and fourth lane
        SHRampOne.GetComponent<BoxCollider>().enabled = false;
        SHRampTwo.GetComponent<BoxCollider>().enabled = false;
        SHRampThree.GetComponent<BoxCollider>().enabled = false;
        //two different inputs can happen in this lane, checks if you want to increase or decrease which lane you are in
        if (Input.GetKey(KeyCode.W) && lValues.GetTimePassed() > lValues.GetTimer())
        {

            machine.ChangeState<LaneThree>();

        }
        if (Input.GetKey(KeyCode.S) && lValues.GetTimePassed() > lValues.GetTimer())
        {

            machine.ChangeState<LaneOne>();

        }
    }


    public override void Exit()
    {

    }

}

public class LaneThree : MP_ChangeLanesState
{
    public override void Enter()
    {
        base.Enter();
        //sets the newPos to lane three
        newPos = new Vector3(29.7f, lValues.GetHeightThree(), 2.47f);
        
        Debug.Log("entered lane three");
    }

    public override void Execute()
    {
        base.Execute();
        //enables the colliders for the small half ramps upon entering and being in the third lane, also works for lane four
        SHRampOne.GetComponent<BoxCollider>().enabled = true;
        SHRampTwo.GetComponent<BoxCollider>().enabled = true;
        SHRampThree.GetComponent<BoxCollider>().enabled = true;
        //checks for lane up or down
        if (Input.GetKey(KeyCode.W) && lValues.GetTimePassed() > lValues.GetTimer())
        {

            machine.ChangeState<LaneFour>();

        }
        if (Input.GetKey(KeyCode.S) && lValues.GetTimePassed() > lValues.GetTimer())
        {

            machine.ChangeState<LaneTwo>();

        }
    }

    
    public override void Exit()
    {

    }
}

public class LaneFour : MP_ChangeLanesState
{
    public override void Enter()
    {
        base.Enter();
        //sets newPos to lane four
        newPos = new Vector3(29.7f, lValues.GetHeightFour(), 2.47f);
        
        Debug.Log("entered lane four");
    }

    public override void Execute()
    {
        base.Execute();
        //only checks for lane down as you can't go above four
        if (Input.GetKey(KeyCode.S) && lValues.GetTimePassed() >lValues.GetTimer() )
        {

            machine.ChangeState<LaneThree>();

        }
    }
    public override void Exit()
    {
       
    }
}

public class RecLane : MP_ChangeLanesState
{
    public override void Enter()
    {
        base.Enter();
        //sets the player's speed to 0
        Accel.ResetSpeed();
        //sets newPos to the recovery lane
        newPos = new Vector3(29.7f, lValues.GetRecHeight(), 2.47f);
        
        Debug.Log("entered lane rec");
    }

    public override void Execute()
    {
       //toggles the ability to accelerate, boost and rotate to false
        if (Control.GetCanAccel())
        {
            Control.ChangeCanAccel();

        }
        if (Control.GetCanBoost())
        {
            Control.ChangeCanBoost();
        }
        
        if (Control.GetCanRot())
        {
            Control.ChangeCanRot();
        }

        //moves the floor so the player is in the recovery lane
        floor.transform.position = Vector3.Lerp(floor.transform.position, newPos, lValues.GetSpeed() * Time.deltaTime);

        //if you are overheated
        if (Heating.GetIsOverheated())
        {
            //and the over heated timer is done
            if(lValues.GetTimePassed() > lValues.GetCrashTimer())
            {
                //set player to not overheating and change lanes to the top lane
                Heating.ChangeIsOverheated();
                machine.ChangeState<LaneFour>();
            }
        }
        //if you have crashed from a wheelie
        if (Crashing.GetIsCrashed())
        {
            //and the timer for crashing from a wheelie is done
            if (lValues.GetTimePassed() > lValues.GetCrashTimer())
            {
                //set player to not crashed from a wheelie and change lanes to the top lane
                Crashing.ChangeIsCrashed();
                
                machine.ChangeState<LaneFour>();
            }
        }
        //checked for if you crashed from landing on the right side of a ramp while rotated back
        if (Crashing.GetIsBRotCrashed())
        {
            if (lValues.GetTimePassed() > lValues.GetCrashTimer())
            {
                Crashing.ChangeIsBRotCrashed();

                machine.ChangeState<LaneFour>();
            }
        }
        //checks if you crashed from landing on the track while rotated forward
        if (Crashing.GetIsFRotCrashed())
        {
            //if the timer for this type of crash is done
            if(lValues.GetTimePassed() > lValues.GetCrashTimer())
            {
                //set no longer crashed and change lanes
                Crashing.ChangeIsFRotCrashedFalse();
                
                machine.ChangeState<LaneFour>();
                
            }
        }
    }

    public override void Exit()
    {
        //checks if the booleans in the controls script are false and turns them back on
        if (!Control.GetCanAccel())
        {
            Control.ChangeCanAccel();

        }
        if (!Control.GetCanBoost())
        {
            Control.ChangeCanBoost();
        }
        if (!Control.GetCanRot())
        {
            Control.ChangeCanRot();
        }
        
    }

}

