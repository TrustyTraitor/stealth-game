using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardContext
{
    public MonoBehaviour parentObj {  get; private set; }
    public bool isAlerted = false;
    public NPCInfoSO info {  get; private set; }
    public NavMeshAgent agent { get; private set; }

    public Transform[] patrolPoints { get; private set; }

    public GuardContext(MonoBehaviour gameObject, NPCInfoSO info, NavMeshAgent agent, Transform[] patrolPoints)
    {
        this.info = info;
        this.agent = agent;
        this.patrolPoints = patrolPoints;
        this.parentObj = gameObject;
    }
}
