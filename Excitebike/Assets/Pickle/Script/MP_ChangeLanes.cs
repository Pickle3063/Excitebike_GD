using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_ChangeLanes : ByTheTale.StateMachine.MachineBehaviour
{
   

    public override void AddStates()
    {
        AddState<LaneOne>();
        AddState<LaneTwo>();
        AddState<LaneThree>();
        AddState<LaneFour>();
        AddState<RecLane>();

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
    
    protected GameObject floor = GameObject.Find("floor");
    protected Vector3 newPos;
    protected GameObject SHRampOne;
    protected GameObject SHRampTwo;
    protected GameObject SHRampThree;


    public override void Enter()
    {
        lValues = GetMachine<MP_ChangeLanes>().GetComponent<MP_LaneValues>();
        Accel = GetMachine<MP_ChangeLanes>().GetComponent<MP_Boost_Accel>();
        Control = GetMachine<MP_ChangeLanes>().GetComponent<MP_Controls>();
        Heating = GetMachine<MP_ChangeLanes>().GetComponent<MP_Overheat>();
        Crashing = GetMachine<MP_ChangeLanes>().GetComponent<MP_Crash>();
        
        SHRampOne = GameObject.Find("SHR");
        SHRampTwo = GameObject.Find("SHR1");
        SHRampThree = GameObject.Find("SHR2");
        lValues.ResetTimer();


    }

    public override void Execute()
    {
        floor.transform.position = Vector3.Lerp(floor.transform.position, newPos, lValues.GetSpeed() * Time.deltaTime);
        //checks if player has crashed OR overheated
        if (lValues.GetNeedToplane())
        {
            //slowly moves player to the recovery lane
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
        base.Enter();
        newPos = new Vector3(29.7f, lValues.GetHeightOne(), 2.47f);
        
        Debug.Log("entered lane one");
    }
   
    public override void Execute()
    {
        
        base.Execute();
       
        
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
        newPos = new Vector3(29.7f, lValues.GetHeightTwo(), 2.47f);
        
        Debug.Log("entered lane two");
    }

    public override void Execute()
    {
        base.Execute();
        SHRampOne.GetComponent<BoxCollider>().enabled = false;
        SHRampTwo.GetComponent<BoxCollider>().enabled = false;
        SHRampThree.GetComponent<BoxCollider>().enabled = false;
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
        newPos = new Vector3(29.7f, lValues.GetHeightThree(), 2.47f);
        
        Debug.Log("entered lane three");
    }

    public override void Execute()
    {
        base.Execute();
        SHRampOne.GetComponent<BoxCollider>().enabled = true;
        SHRampTwo.GetComponent<BoxCollider>().enabled = true;
        SHRampThree.GetComponent<BoxCollider>().enabled = true;
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
        newPos = new Vector3(29.7f, lValues.GetHeightFour(), 2.47f);
        
        Debug.Log("entered lane four");
    }

    public override void Execute()
    {
        base.Execute();
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
        Accel.ResetSpeed();
        newPos = new Vector3(29.7f, lValues.GetRecHeight(), 2.47f);
        Debug.Log("entered lane rec");
    }

    public override void Execute()
    {
       
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

        floor.transform.position = Vector3.Lerp(floor.transform.position, newPos, lValues.GetSpeed() * Time.deltaTime);

        if (Heating.GetIsOverheated())
        {
            if(lValues.GetTimePassed() > lValues.GetCrashTimer())
            {
                Heating.ChangeIsOverheated();
                machine.ChangeState<LaneFour>();
            }
        }
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
            }
        }
    }

    public override void Exit()
    {
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

