using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : GuardState
{
    public ChaseState(GuardContext context, GuardBrain.GuardStates key) : base(context, key) {}

    public override void EnterState()
    {
        context.agent.stoppingDistance = 10f;
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {

    }

    public override GuardBrain.GuardStates GetNextState()
    {
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other)
    {
    }

    public override void OnTriggerExit(Collider other)
    {
    }

    public override void OnTriggerStay(Collider other)
    {
    }
}
