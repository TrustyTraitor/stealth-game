using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : GuardState
{
    private int targetPoint = 0;
    private IEnumerator pathUpdateDelayHandler;

    public PatrolState(GuardContext context, GuardBrain.GuardStates key) : base(context, key) {}

    private IEnumerator UpdatePath()
    {
        while (true)
        {
            context.agent.SetDestination(context.patrolPoints[targetPoint].position);

            yield return new WaitForSeconds(context.info.pathUpdateDelay);
        }
    }

    public override void EnterState()
    {
        context.agent.stoppingDistance = 0f;

        pathUpdateDelayHandler = UpdatePath();
        context.parentObj.StartCoroutine(pathUpdateDelayHandler);
    }

    public override void ExitState()
    {
        context.parentObj.StopCoroutine(pathUpdateDelayHandler);
        targetPoint = (targetPoint + 1) % context.patrolPoints.Length;
    }

    public override void UpdateState()
    {
        context.animator.SetFloat("Speed", context.agent.velocity.sqrMagnitude);
    }

    public override GuardBrain.GuardStates GetNextState()
    {
        if (context.isAlerted) return GuardBrain.GuardStates.Chase;

        if (context.agent.pathStatus == NavMeshPathStatus.PathComplete
            && context.agent.remainingDistance <= 0.01f)
        {
            return GuardBrain.GuardStates.Idle;
        }

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
