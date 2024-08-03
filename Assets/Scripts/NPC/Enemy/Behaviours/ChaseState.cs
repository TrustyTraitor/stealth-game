using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class ChaseState : GuardState
{
    private GameObject target;
    private bool isTargetPlayer = false;
    private IEnumerator pathUpdateHandle;

    public ChaseState(GuardContext context, GuardBrain.GuardStates key) : base(context, key) {}

    public override void EnterState()
    {
        context.vision.onSuspicion += HandleSusObjects;

        context.agent.stoppingDistance = 10f;
        context.animator.SetBool("isAlerted", context.isAlerted);

        pathUpdateHandle = UpdatePath();
        context.parentObj.StartCoroutine(pathUpdateHandle);
    }

    public override void ExitState()
    {
        context.vision.onSuspicion -= HandleSusObjects;

        context.parentObj.StopCoroutine(pathUpdateHandle);
    }

    public override void UpdateState()
    {
        if ( target != null)
        {
            LookAtTarget();        
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
                Debug.Log($"UpdatePath: {target.name}");
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

        Debug.Log($"handle sus obj");
        // I hate this entire function but... oh well
        if (isTargetPlayer) return;
        Debug.Log("Here2");
        foreach (GameObject obj in detectedObjs)
        {
            if (obj.tag.Equals("Player"))
            {
                Debug.Log("Player Found");
                target = obj;
                isTargetPlayer = true;
                return;
            }

            distance = Vector3.Distance(context.parentObj.transform.position, obj.transform.position);
            if (distance < smallest_distance)
            {
                smallest_distance = distance;
                closest = obj;
            }
        }

        Debug.Log($"{closest.name}");
        target = closest;
    }
}
