using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(NPCVisionN))]
public class GuardBrain : StateManager<GuardBrain.GuardStates>
{
    public enum GuardStates
    {
        Idle,
        Patrol,
        Chase
    }

    [SerializeField]
    private NPCInfoSO info;

    [SerializeField]
    private Transform[] patrolPoints;

    public GuardContext context {  get; private set; }
    private NavMeshAgent agent;
    private NPCSuspicionHandler suspicionHandle;
    private Animator animator;
    private NPCVisionN vision;
    private AudioSource audioSource;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        vision = GetComponent<NPCVisionN>();
        audioSource = GetComponent<AudioSource>();

        context = new GuardContext(this, info, agent, animator, patrolPoints, vision, audioSource);
        suspicionHandle = GetComponent<NPCSuspicionHandler>();

        suspicionHandle.onAlertAfterDelay += UpdateIsAlertContext;

        InitStates();
    }

    private void InitStates()
    {
        States.Add(GuardStates.Idle, new IdleState(context, GuardStates.Idle));
        States.Add(GuardStates.Patrol, new PatrolState(context, GuardStates.Patrol));
        States.Add(GuardStates.Chase, new ChaseState(context, GuardStates.Chase));

        CurrentState = States[GuardStates.Idle];
    }

    public void UpdateIsAlertContext()
    {
        context.isAlerted = true;
    }
}
