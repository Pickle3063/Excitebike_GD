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
        //AddState<LaneOneSHR>();
        //AddState<LaneOneHR>();
        //AddState<LaneOneSR>();
        //AddState<LaneOneBR>();
        //AddState<LaneOneBuR>();
        //AddState<LaneOneBBuR>();
        //AddState<LaneOneER>();
        //AddState<LaneOneSHRAir>();
        //AddState<LaneOneHRAir>();
        //AddState<LaneOneSRAir>();
        //AddState<LaneOneBRAir>();
        //AddState<LaneOneBuRAir>();
        //AddState<LaneOneBBuRAir>();
        //AddState<LaneOneERAir>();
        //AddState<LaneTwoSHR>();
        //AddState<LaneTwoHR>();
        //AddState<LaneTwoSR>();
        //AddState<LaneTwoBR>();
        //AddState<LaneTwoBuR>();
        //AddState<LaneTwoBBuR>();
        //AddState<LaneTwoER>();
        //AddState<LaneTwoSHRAir>();
        //AddState<LaneTwoHRAir>();
        //AddState<LaneTwoSRAir>();
        //AddState<LaneTwoBRAir>();
        //AddState<LaneTwoBuRAir>();
        //AddState<LaneTwoBBuRAir>();
        //AddState<LaneTwoERAir>();
        //AddState<LaneThreeSHR>();
        //AddState<LaneThreeHR>();
        //AddState<LaneThreeSR>();
        //AddState<LaneThreeBR>();
        //AddState<LaneThreeBuR>();
        //AddState<LaneThreeBBuR>();
        //AddState<LaneThreeER>();
        //AddState<LaneThreeSHRAir>();
        //AddState<LaneThreeHRAir>();
        //AddState<LaneThreeSRAir>();
        //AddState<LaneThreeBRAir>();
        //AddState<LaneThreeBuRAir>();
        //AddState<LaneThreeBBuRAir>();
        //AddState<LaneThreeERAir>();
        //AddState<LaneFourSHR>();
        //AddState<LaneFourHR>();
        //AddState<LaneFourSR>();
        //AddState<LaneFourBR>();
        //AddState<LaneFourBuR>();
        //AddState<LaneFourBBuR>();
        //AddState<LaneFourER>();
        //AddState<LaneFourSHRAir>();
        //AddState<LaneFourHRAir>();
        //AddState<LaneFourSRAir>();
        //AddState<LaneFourBRAir>();
        //AddState<LaneFourBuRAir>();
        //AddState<LaneFourBBuRAir>();
        //AddState<LaneFourERAir>();

        SetInitialState<LaneOne>();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }


}

public class MP_ChangeLanesState : ByTheTale.StateMachine.State
{
    protected MP_LaneValues lValues;
    protected MP_Acceleration Accel;
    protected MP_Controls Control;
    protected MP_Overheat Heating;
    protected MP_Crash Crashing;
    protected GameObject player = GameObject.Find("Player");
    protected Vector3 newPos;

    public override void Enter()
    {
        lValues = GetMachine<MP_ChangeLanes>().GetComponent<MP_LaneValues>();
        Accel = GetMachine<MP_ChangeLanes>().GetComponent<MP_Acceleration>();
        Control = GetMachine<MP_ChangeLanes>().GetComponent<MP_Controls>();
        Heating = GetMachine<MP_ChangeLanes>().GetComponent<MP_Overheat>();
        Crashing = GetMachine<MP_ChangeLanes>().GetComponent<MP_Crash>();
        lValues.ResetTimer();


    }

    public override void Execute()
    {
        player.transform.position = Vector3.Lerp(player.transform.position, newPos, lValues.GetSpeed() * Time.deltaTime);
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
        newPos = new Vector3(-32.984f, lValues.GetHeightOne(), -4);
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

    //void OntriggerEnter(Collider other)
    //{
    //    if(other.tag == "Small Half Ramp")
    //    {
    //        machine.ChangeState<LaneOneSHR>();
    //    }

    //    if(other.tag == "Half Ramp")
    //    {
    //        machine.ChangeState<LaneOneHR>();
    //    }
    //    if(other.tag == "Small Ramp")
    //    {
    //        machine.ChangeState<LaneOneSR>();
    //    }
    //    if (other.tag == "Big Ramp")
    //    {
    //        machine.ChangeState<LaneOneBR>();
    //    }
    //    if (other.tag == "Bump Ramp")
    //    {
    //        machine.ChangeState<LaneOneBuR>();
    //    }
    //    if (other.tag == "Small Ramp")
    //    {
    //        machine.ChangeState<LaneOneSR>();
    //    }
    //}
    
    public override void Exit() { }
   
}

public class LaneTwo : MP_ChangeLanesState
{
    
    public override void Enter()
    {
        base.Enter();
        newPos = new Vector3(-32.984f, lValues.GetHeightTwo(), -4);
        Debug.Log("entered lane two");
    }

    public override void Execute()
    {
        base.Execute();
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
        newPos = new Vector3(-32.984f, lValues.GetHeightThree(), -4);
        Debug.Log("entered lane three");
    }

    public override void Execute()
    {
        base.Execute();
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
        newPos = new Vector3(-32.984f, lValues.GetHeightFour(), -4);
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
        Control.enabled = false;
        Accel.enabled = false;
        newPos = new Vector3(-32.984f, lValues.GetRecHeight(), -4);
        Debug.Log("entered lane rec");
    }

    public override void Execute()
    {
        player.transform.position = Vector3.Lerp(player.transform.position, newPos, lValues.GetSpeed() * Time.deltaTime);
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
    }

    public override void Exit()
    {
        Control.enabled = true;
        Accel.enabled = true;
    }

}

//public class LaneOneSHR : MP_ChangeLanesState
//{

//}
//public class LaneOneHR : MP_ChangeLanesState
//{

//}
//public class LaneOneSR : MP_ChangeLanesState
//{

//}
//public class LaneOneBR : MP_ChangeLanesState
//{

//}
//public class LaneOneBuR : MP_ChangeLanesState
//{

//}
//public class LaneOneBBuR : MP_ChangeLanesState
//{

//}
//public class LaneOneER : MP_ChangeLanesState
//{

//}

//public class LaneTwoSHR : MP_ChangeLanesState
//{

//}
//public class LaneTwoHR : MP_ChangeLanesState
//{

//}
//public class LaneTwoSR : MP_ChangeLanesState
//{

//}
//public class LaneTwoBR : MP_ChangeLanesState
//{

//}
//public class LaneTwoBuR : MP_ChangeLanesState
//{

//}
//public class LaneTwoBBuR : MP_ChangeLanesState
//{

//}
//public class LaneTwoER : MP_ChangeLanesState
//{

//}

//public class LaneThreeSHR : MP_ChangeLanesState
//{

//}
//public class LaneThreeHR : MP_ChangeLanesState
//{

//}
//public class LaneThreeSR : MP_ChangeLanesState
//{

//}
//public class LaneThreeBR : MP_ChangeLanesState
//{

//}
//public class LaneThreeBuR : MP_ChangeLanesState
//{

//}
//public class LaneThreeBBuR : MP_ChangeLanesState
//{

//}
//public class LaneThreeER : MP_ChangeLanesState
//{

//}

//public class LaneFourSHR : MP_ChangeLanesState
//{

//}
//public class LaneFourHR : MP_ChangeLanesState
//{

//}
//public class LaneFourSR : MP_ChangeLanesState
//{

//}
//public class LaneFourBR : MP_ChangeLanesState
//{

//}
//public class LaneFourBuR : MP_ChangeLanesState
//{

//}
//public class LaneFourBBuR : MP_ChangeLanesState
//{

//}
//public class LaneFourER : MP_ChangeLanesState
//{

//}

//public class LaneOneSHRAir : MP_ChangeLanesState
//{

//}
//public class LaneOneHRAir : MP_ChangeLanesState
//{

//}
//public class LaneOneSRAir : MP_ChangeLanesState
//{

//}
//public class LaneOneBRAir : MP_ChangeLanesState
//{

//}
//public class LaneOneBuRAir : MP_ChangeLanesState
//{

//}
//public class LaneOneBBuRAir : MP_ChangeLanesState
//{

//}
//public class LaneOneERAir : MP_ChangeLanesState
//{

//}

//public class LaneTwoSHRAir : MP_ChangeLanesState
//{

//}
//public class LaneTwoHRAir : MP_ChangeLanesState
//{

//}
//public class LaneTwoSRAir : MP_ChangeLanesState
//{

//}
//public class LaneTwoBRAir : MP_ChangeLanesState
//{

//}
//public class LaneTwoBuRAir : MP_ChangeLanesState
//{

//}
//public class LaneTwoBBuRAir : MP_ChangeLanesState
//{

//}
//public class LaneTwoERAir : MP_ChangeLanesState
//{

//}

//public class LaneThreeSHRAir : MP_ChangeLanesState
//{

//}
//public class LaneThreeHRAir : MP_ChangeLanesState
//{

//}
//public class LaneThreeSRAir : MP_ChangeLanesState
//{

//}
//public class LaneThreeBRAir : MP_ChangeLanesState
//{

//}
//public class LaneThreeBuRAir : MP_ChangeLanesState
//{

//}
//public class LaneThreeBBuRAir : MP_ChangeLanesState
//{

//}
//public class LaneThreeERAir : MP_ChangeLanesState
//{

//}

//public class LaneFourSHRAir : MP_ChangeLanesState
//{

//}
//public class LaneFourHRAir : MP_ChangeLanesState
//{

//}
//public class LaneFourSRAir : MP_ChangeLanesState
//{

//}
//public class LaneFourBRAir : MP_ChangeLanesState
//{

//}
//public class LaneFourBuRAir : MP_ChangeLanesState
//{

//}
//public class LaneFourBBuRAir : MP_ChangeLanesState
//{

//}
//public class LaneFourERAir : MP_ChangeLanesState
//{

//}

