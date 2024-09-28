using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class ChaseState : GuardState
{
    private GameObject target;
    private bool isTargetPlayer = false;
    private IEnumerator pathUpdateHandle;
    private IEnumerator ShootingHandler;

    public ChaseState(GuardContext context, GuardBrain.GuardStates key) : base(context, key) {}

    private float distanceToPlayer;

    private bool hasStartedShooting = false;
    private HealthComponent playerHC;

    public override void EnterState()
    {
        context.vision.onSuspicion += HandleSusObjects;

        context.agent.stoppingDistance = 10f;
        context.animator.SetBool("isAlerted", context.isAlerted);

        pathUpdateHandle = UpdatePath();
        context.parentObj.StartCoroutine(pathUpdateHandle);

        ShootingHandler = Shooty();
    }

    public override void ExitState()
    {
        context.vision.onSuspicion -= HandleSusObjects;

        context.parentObj.StopCoroutine(pathUpdateHandle);

        if (hasStartedShooting)
            context.parentObj.StopCoroutine(ShootingHandler);

        hasStartedShooting = false;
    }

    public override void UpdateState()
    {
        if ( target != null)
        {
            LookAtTarget();

            if (isTargetPlayer && !hasStartedShooting)
            {
                hasStartedShooting = true;
                context.parentObj.StartCoroutine(ShootingHandler);
            }
        }

        context.animator.SetFloat("Speed", context.agent.velocity.sqrMagnitude);
    }

    public override GuardBrain.GuardStates GetNextState()
    {
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other){}
    public override void OnTriggerExit(Collider other){}
    public override void OnTriggerStay(Collider other){}

    private void LookAtTarget()
    {
        Vector3 lookPos = target.transform.position - context.parentObj.transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        context.parentObj.transform.rotation = Quaternion.Slerp(context.parentObj.transform.rotation, rotation, 0.2f);
    }

    private IEnumerator UpdatePath()
    {
        while (true)
        {
            if (target != null)
            {
                context.agent.SetDestination(target.transform.position);
            }

            yield return new WaitForSeconds(context.info.pathUpdateDelay);    
        }
    }

    private void HandleSusObjects(List<GameObject> detectedObjs)
    {
        GameObject closest = detectedObjs[0];
        float smallest_distance = Mathf.Infinity;
        float distance = 0f;

        // I hate this entire function but... oh well
        if (isTargetPlayer) return;

        foreach (GameObject obj in detectedObjs)
        {
            if (obj.tag.Equals("Player"))
            {
                target = obj;
                isTargetPlayer = true;
                playerHC = target.GetComponent<HealthComponent>();
                return;
            }

            distance = Vector3.Distance(context.parentObj.transform.position, obj.transform.position);
            if (distance < smallest_distance)
            {
                smallest_distance = distance;
                closest = obj;
            }
        }

        target = closest;
    }

    private IEnumerator Shooty()
    {
        while (true)
        {
            distanceToPlayer = Vector3.Distance(context.parentObj.transform.position, target.transform.position);
            if (distanceToPlayer <= context.agent.stoppingDistance)
            {
                playerHC.health -= context.info.AttackDamage;
                context.audioSource.Play();
            }

            yield return new WaitForSeconds(context.info.AttackSpeed);
        }
    }
}
