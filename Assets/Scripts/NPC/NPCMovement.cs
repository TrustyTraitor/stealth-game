using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;

[DisallowMultipleComponent]
public class NPCMovement : MonoBehaviour
{
    /*
    public Transform target;

    private EnemyReferences enemyReferences;
    public float shootingDistance;
    private float pathUpdateDeadline;

    public bool isPlayerSeen;
    private bool isPlayerDetected;

    private float firstSeenTime;

    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReferences>();

        enemyReferences.vision.onPlayerDetection += PlayerSeen;
        enemyReferences.vision.onPlayerLost += PlayerNotSeen;
    }

    private void OnDisable()
    {
        enemyReferences.vision.onPlayerDetection -= PlayerSeen;
        enemyReferences.vision.onPlayerLost -= PlayerNotSeen;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (target != null) 
        { 
            bool inRange = Vector3.Distance(transform.position, target.position) <= shootingDistance;

            if (isPlayerSeen) 
            {
                enemyReferences.navMeshAgent.stoppingDistance = shootingDistance;

                if (inRange)
                {
                    LookAtTarget();
                }
                else
                {
                    UpdatePath();
                }
                enemyReferences.animator.SetBool("isShooting", inRange);
            }
            else
            {
                enemyReferences.animator.SetBool("isShooting", false);
            }
            
            
        }
        enemyReferences.animator.SetFloat("speed", enemyReferences.navMeshAgent.desiredVelocity.sqrMagnitude);
    }

    private void LookAtTarget() 
    {
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }

    private void UpdatePath()
    { 
        if (Time.time >= pathUpdateDeadline)
        {
            pathUpdateDeadline = Time.time + enemyReferences.pathUpdateDelay;
            enemyReferences.navMeshAgent.SetDestination(target.position);
        }
    }

    private void PlayerSeen() 
    {
        isPlayerSeen = true;

        //Debug.Log("Seen!");
    }

    private void PlayerNotSeen() 
    {
        //isPlayerSeen = false;
    }
    */
}
