using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    /*
    private NPCMovement movement;

    public EnemyReferences enemrefs;

    public Transform[] patrolPoints;

    private int targetPoint;

    public float waitTime = 3f;

    private float StoppingDistance = 0f;
    private float DefaultStoppingDistance;

    private float pathUpdateDeadline = 0;

    private float targetReachedTime = 0f;
    private float currentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<NPCMovement>();

        DefaultStoppingDistance = enemrefs.navMeshAgent.stoppingDistance;

        enemrefs.navMeshAgent.stoppingDistance = StoppingDistance;

        targetPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!movement.isPlayerSeen && Time.time >= pathUpdateDeadline)
        {
            enemrefs.navMeshAgent.stoppingDistance = StoppingDistance;

            pathUpdateDeadline = Time.time + enemrefs.pathUpdateDelay;
            enemrefs.navMeshAgent.SetDestination(patrolPoints[targetPoint].position);

            if (enemrefs.navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete 
                && enemrefs.navMeshAgent.remainingDistance == 0) 
            {
                if (targetReachedTime == 0f)
                    targetReachedTime = Time.time;

                currentTime = Time.time;

                if (currentTime - targetReachedTime >= waitTime)
                    UpdateTarget();
            }

        }
    }

    private void UpdateTarget() 
    {
        targetPoint = (targetPoint + 1) % patrolPoints.Length;

        targetReachedTime = 0f;
    }
    */
}
