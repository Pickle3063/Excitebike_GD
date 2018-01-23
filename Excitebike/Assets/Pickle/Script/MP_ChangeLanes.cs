using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_ChangeLanes : ByTheTale.StateMachine.MachineBehaviour
{
   
<<<<<<< HEAD

    public override void AddStates()
    {
        AddState<LaneOne>();
        AddState<LaneTwo>();
        AddState<LaneThree>();
        AddState<LaneFour>();
        AddState<RecLane>();

=======
    //adding the individual lane states
    public override void AddStates()
    {
        AddState<LaneOne>(); //bottom lane
        AddState<LaneTwo>();
        AddState<LaneThree>();
        AddState<LaneFour>(); //top lane
        AddState<RecLane>(); //recovery lane

        //setting the starting lane
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
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
<<<<<<< HEAD
    protected MP_CameraHold CamHold;
    
    protected GameObject floor = GameObject.Find("floor");
    protected Vector3 newPos;
    protected GameObject SHRampOne;
    protected GameObject SHRampTwo;
    protected GameObject SHRampThree;


=======
    
    //gets the floor object which contains all of the visual parts of the track
    protected GameObject floor = GameObject.Find("floor");
    //the position to move to when used
    protected Vector3 newPos;
    //gets the three small half ramps on the track, can be added or reduced for each track
    protected GameObject SHRampOne;
    protected GameObject SHRampTwo;
    protected GameObject SHRampThree;

    //used in states to have references set
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    public override void Enter()
    {
        lValues = GetMachine<MP_ChangeLanes>().GetComponent<MP_LaneValues>();
        Accel = GetMachine<MP_ChangeLanes>().GetComponent<MP_Boost_Accel>();
        Control = GetMachine<MP_ChangeLanes>().GetComponent<MP_Controls>();
        Heating = GetMachine<MP_ChangeLanes>().GetComponent<MP_Overheat>();
        Crashing = GetMachine<MP_ChangeLanes>().GetComponent<MP_Crash>();
<<<<<<< HEAD
        CamHold = GetMachine<MP_ChangeLanes>().GetComponent<MP_CameraHold>();
        
        SHRampOne = GameObject.Find("SHR");
        SHRampTwo = GameObject.Find("SHR1");
        SHRampThree = GameObject.Find("SHR2");
=======
        
        //finds the individual ramp colliders by name
        SHRampOne = GameObject.Find("SHR");
        SHRampTwo = GameObject.Find("SHR1");
        SHRampThree = GameObject.Find("SHR2");
        //sets the timepassed to 0 on the script referenced
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
        lValues.ResetTimer();


    }

    public override void Execute()
    {
<<<<<<< HEAD
        floor.transform.position = Vector3.Lerp(floor.transform.position, newPos, lValues.GetSpeed() * Time.deltaTime);

        //checks if player has crashed OR overheated
        if (lValues.GetNeedToplane())
        {
            //slowly moves player to the recovery lane
=======
        //moves the floor to whatever is set as newPos in each state, simulates a change in lanes
        floor.transform.position = Vector3.Lerp(floor.transform.position, newPos, lValues.GetSpeed() * Time.deltaTime);
        //checks if player has crashed OR overheated
        if (lValues.GetNeedToplane())
        {
            //if timer allows it then you move to the recovery lane
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
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
<<<<<<< HEAD
        base.Enter();
=======
        //calls the enter that sets up the references and resets the timer
        base.Enter();
        //sets the newPos for lane one
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
        newPos = new Vector3(29.7f, lValues.GetHeightOne(), 2.47f);
        
        Debug.Log("entered lane one");
    }
   
    public override void Execute()
    {
<<<<<<< HEAD
        
        base.Execute();
       
        
        if (Input.GetKey(KeyCode.W) && lValues.GetTimePassed() > lValues.GetTimer())
        {
   
=======
        //calls the execute set up in the changelanesstate
        base.Execute();
       
        //checks for the Up directional and the timer to be complete(prevents lane skipping), which moves the lane up one
        if (Input.GetKey(KeyCode.W) && lValues.GetTimePassed() > lValues.GetTimer())
        {
            
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
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
<<<<<<< HEAD
=======
        //sets the newPos to lane two
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
        newPos = new Vector3(29.7f, lValues.GetHeightTwo(), 2.47f);
        
        Debug.Log("entered lane two");
    }

    public override void Execute()
    {
        base.Execute();
<<<<<<< HEAD
        SHRampOne.GetComponent<BoxCollider>().enabled = false;
        SHRampTwo.GetComponent<BoxCollider>().enabled = false;
        SHRampThree.GetComponent<BoxCollider>().enabled = false;
        if (Input.GetKey(KeyCode.W) && lValues.GetTimePassed() > lValues.GetTimer())
        {
    
=======
        //disables the small half ramp colliders upon entering this lane as the ramp only takes up the third and fourth lane
        SHRampOne.GetComponent<BoxCollider>().enabled = false;
        SHRampTwo.GetComponent<BoxCollider>().enabled = false;
        SHRampThree.GetComponent<BoxCollider>().enabled = false;
        //two different inputs can happen in this lane, checks if you want to increase or decrease which lane you are in
        if (Input.GetKey(KeyCode.W) && lValues.GetTimePassed() > lValues.GetTimer())
        {

>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
            machine.ChangeState<LaneThree>();

        }
        if (Input.GetKey(KeyCode.S) && lValues.GetTimePassed() > lValues.GetTimer())
        {
<<<<<<< HEAD
            
=======

>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
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
<<<<<<< HEAD

        base.Enter();
=======
        base.Enter();
        //sets the newPos to lane three
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
        newPos = new Vector3(29.7f, lValues.GetHeightThree(), 2.47f);
        
        Debug.Log("entered lane three");
    }

    public override void Execute()
    {
        base.Execute();
<<<<<<< HEAD
        SHRampOne.GetComponent<BoxCollider>().enabled = true;
        SHRampTwo.GetComponent<BoxCollider>().enabled = true;
        SHRampThree.GetComponent<BoxCollider>().enabled = true;
        if (Input.GetKey(KeyCode.W) && lValues.GetTimePassed() > lValues.GetTimer())
        {
           
=======
        //enables the colliders for the small half ramps upon entering and being in the third lane, also works for lane four
        SHRampOne.GetComponent<BoxCollider>().enabled = true;
        SHRampTwo.GetComponent<BoxCollider>().enabled = true;
        SHRampThree.GetComponent<BoxCollider>().enabled = true;
        //checks for lane up or down
        if (Input.GetKey(KeyCode.W) && lValues.GetTimePassed() > lValues.GetTimer())
        {

>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
            machine.ChangeState<LaneFour>();

        }
        if (Input.GetKey(KeyCode.S) && lValues.GetTimePassed() > lValues.GetTimer())
        {
<<<<<<< HEAD
           
=======

>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
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
<<<<<<< HEAD
=======
        //sets newPos to lane four
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
        newPos = new Vector3(29.7f, lValues.GetHeightFour(), 2.47f);
        
        Debug.Log("entered lane four");
    }

    public override void Execute()
    {
        base.Execute();
<<<<<<< HEAD
        if (Input.GetKey(KeyCode.S) && lValues.GetTimePassed() >lValues.GetTimer() )
        {
       
=======
        //only checks for lane down as you can't go above four
        if (Input.GetKey(KeyCode.S) && lValues.GetTimePassed() >lValues.GetTimer() )
        {

>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
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
<<<<<<< HEAD
        Accel.ResetSpeed();
        newPos = new Vector3(29.7f, lValues.GetRecHeight(), 2.47f);
=======
        //sets the player's speed to 0
        Accel.ResetSpeed();
        //sets newPos to the recovery lane
        newPos = new Vector3(29.7f, lValues.GetRecHeight(), 2.47f);
        
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
        Debug.Log("entered lane rec");
    }

    public override void Execute()
    {
<<<<<<< HEAD
       
=======
       //toggles the ability to accelerate, boost and rotate to false
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
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

<<<<<<< HEAD
        floor.transform.position = Vector3.Lerp(floor.transform.position, newPos, lValues.GetSpeed() * Time.deltaTime);

        if (Heating.GetIsOverheated())
        {
            if(lValues.GetTimePassed() > lValues.GetCrashTimer())
            {
=======
        //moves the floor so the player is in the recovery lane
        floor.transform.position = Vector3.Lerp(floor.transform.position, newPos, lValues.GetSpeed() * Time.deltaTime);

        //if you are overheated
        if (Heating.GetIsOverheated())
        {
            //and the over heated timer is done
            if(lValues.GetTimePassed() > lValues.GetCrashTimer())
            {
                //set player to not overheating and change lanes to the top lane
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
                Heating.ChangeIsOverheated();
                machine.ChangeState<LaneFour>();
            }
        }
<<<<<<< HEAD
        if (Crashing.GetIsCrashed())
        {
            if (lValues.GetTimePassed() > lValues.GetCrashTimer())
            {
                Crashing.ChangeIsCrashed();
                machine.ChangeState<LaneFour>();
            }
        }
        if (Crashing.GetIsBRotCrashed())
        {
            if (lValues.GetTimePassed() > lValues.GetCrashTimer())
            {
                Crashing.ChangeIsBRotCrashed();
                machine.ChangeState<LaneFour>();
            }
        }
        if (Crashing.GetIsFRotCrashed())
        {
            if(lValues.GetTimePassed() > lValues.GetCrashTimer())
            {
                Crashing.ChangeIsFRotCrashed();
                machine.ChangeState<LaneFour>();
=======
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
        //if (Crashing.GetIsBRotCrashed())
        //{
        //    if (lValues.GetTimePassed() > lValues.GetCrashTimer())
        //    {
        //        Crashing.ChangeIsBRotCrashed();
                
        //        machine.ChangeState<LaneFour>();
        //    }
        //}
        //checks if you crashed from landing on the track while rotated forward
        if (Crashing.GetIsFRotCrashed())
        {
            //if the timer for this type of crash is done
            if(lValues.GetTimePassed() > lValues.GetCrashTimer())
            {
                //set no longer crashed and change lanes
                Crashing.ChangeIsFRotCrashedFalse();
                
                machine.ChangeState<LaneFour>();
                
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
            }
        }
    }

    public override void Exit()
    {
<<<<<<< HEAD
=======
        //checks if the booleans in the controls script are false and turns them back on
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
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
<<<<<<< HEAD
=======
        
>>>>>>> 3d6ed963f533b44d17c0579c8f7804359aea14ae
    }

}

