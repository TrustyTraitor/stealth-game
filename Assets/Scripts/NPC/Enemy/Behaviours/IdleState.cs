using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : GuardState
{
    private float EnterIdleTime, CurrentTime;

    public IdleState(GuardContext context, GuardBrain.GuardStates key) : base(context, key) {}

    public override void EnterState()
    {
        EnterIdleTime = Time.time;
        Debug.Log($"Enter idle: {EnterIdleTime}");
    }

    public override void ExitState()
    {
        Debug.Log($"Exit Time: {CurrentTime}");
    }

    public override void UpdateState()
    {
        CurrentTime = Time.time;
    }

    public override GuardBrain.GuardStates GetNextState()
    {
        //if (context.isAlerted) return GuardBrain.GuardStates.Chase;
        if (CurrentTime - EnterIdleTime >= context.info.IdleTime) return GuardBrain.GuardStates.Patrol;

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
