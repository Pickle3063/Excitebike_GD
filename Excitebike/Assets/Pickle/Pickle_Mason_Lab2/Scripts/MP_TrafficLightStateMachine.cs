using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP_TrafficLightStateMachine : ByTheTale.StateMachine.MachineBehaviour
{
    public override void AddStates()
    {
        AddState<GreenStateMP>();
        AddState<YellowStateMP>();
        AddState<RedStateMP>();
        AddState<FlashYellowStateMP>();

        SetInitialState<GreenStateMP>();
    }
    
    public void Flash()
    {
        
        if (IsCurrentState<GreenStateMP>())
        {
            ChangeState<FlashYellowStateMP>();
        }
        else
        {
            ChangeState<RedStateMP>();
        }
    }

    private void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Flash();
        }
    }
}

public class MP_TrafficLightState : ByTheTale.StateMachine.State
{
    protected MJP_TrafficLightOne trafficLight;

    public override void Enter()
    {
        trafficLight = GetMachine<MP_TrafficLightStateMachine>().GetComponent<MJP_TrafficLightOne>();

        trafficLight.ResetTimeSinceLastTransistion();
    }
}

public class GreenStateMP : MP_TrafficLightState
{
    public override void Enter()
    {
        base.Enter();
        trafficLight.GetGreenLight().material.color = Color.green;
    }

    public override void Execute()
    {
        if((trafficLight.GetTimePassed()) > (trafficLight.GetGreenTime()))
        {
            machine.ChangeState<YellowStateMP>();
        }
    }

    public override void Exit()
    {
        trafficLight.GetGreenLight().material.color = Color.grey;
    }
}

public class YellowStateMP : MP_TrafficLightState
{
    public override void Enter()
    {
        base.Enter();
        trafficLight.GetYellowLight().material.color = Color.yellow;
    }

    public override void Execute()
    {
        if((trafficLight.GetTimePassed()) > (trafficLight.GetYellowTime()))
        {
            machine.ChangeState<RedStateMP>();
        }
    }

    public override void Exit()
    {
        trafficLight.GetYellowLight().material.color = Color.grey;
    }
}

public class RedStateMP : MP_TrafficLightState
{
    public override void Enter()
    {
        base.Enter();
        trafficLight.GetRedLight().material.color = Color.red;
    }

    public override void Execute()
    {
        if((trafficLight.GetTimePassed()) > (trafficLight.GetRedTime()))
        {
            machine.ChangeState<GreenStateMP>();
        }
    }

    public override void Exit()
    {
        trafficLight.GetRedLight().material.color = Color.grey;
    }
}

public class FlashYellowStateMP : MP_TrafficLightState
{
    public override void Enter()
    {
        base.Enter();
        trafficLight.GetYellowLight().material.color = Color.yellow;
    }

    public override void Execute()
    {
        if ((trafficLight.GetTimePassed()) < (trafficLight.GetYellowTime() * .5f))
        {
            trafficLight.GetYellowLight().material.color = Color.yellow;
        }
        else if ((trafficLight.GetTimePassed()) > (trafficLight.GetYellowTime() * .5f))
        {
            trafficLight.GetYellowLight().material.color = Color.grey;
        }

        if((trafficLight.GetTimePassed()) > (trafficLight.GetYellowTime()))
        {
            machine.ChangeState<FlashYellowStateMP>();
        }
      
    }

    public override void Exit()
    {
        trafficLight.GetYellowLight().material.color = Color.grey;
    }
}
   
