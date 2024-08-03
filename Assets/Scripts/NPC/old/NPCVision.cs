using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using UnityEngine;

[Tooltip("This code should only detect the player, how the given NPC responds should be in a different behaviour script"), DisallowMultipleComponent]
public class NPCVision : MonoBehaviour
{
    [SerializeField]
    private float visionUpdateDelay = 0.05f;

    [Tooltip("How far away the player/suspcious activity can be seen")]
    public float viewDistance = 20f;

    [Tooltip("The angle at which the player/suspicious activity can be seen")]
    public float viewRadius = 75f; // Change this to viewAngle

    public GameObject playerObject;

    private bool playerIsSeen;
    private bool playerWasSeen;

    /*
    // Event delegate
    public delegate void OnPlayerDetection();
    public event OnPlayerDetection onPlayerDetection;
    
    public delegate void OnPlayerLost();
    public event OnPlayerLost onPlayerLost;
    */

    // New versions of OnPlayerDetection and OnPlayerLost
    public event Action<List<GameObject>> onSuspicion;

    [SerializeField]
    private LayerMask layerMask;

    private Vector3 rayDirection;
    private Vector3 enemyDirection;
    private float trueAngle;
    private bool objInFrontOfEnemy;

    private void Start()
    {
        StartCoroutine(nVisionUpdate());
    }

    private IEnumerator nVisionUpdate()
    {
        while (true)
        {
            DetectionCheck();

            yield return new WaitForSeconds(visionUpdateDelay);
        }
    }

    private void DetectionCheck() 
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, viewDistance, layerMask);
        
        // This may not be needed. If suspcious objects are all on the Suspicious Layer then this filter wont be needed
        //IEnumerable<ObjectSuspicion> susColliders = colliders.Select(collider => collider.gameObject.GetComponent<ObjectSuspicion>()).Where(component => component != null);

        List<GameObject> detectedList = new List<GameObject>();

        // Runs through the array of all Suspicious objects in range.
        // Does a ray cast to ensure it isnt behind a wall
        foreach (var C in colliders)
        {
            rayDirection = C.gameObject.transform.position - transform.position;
            enemyDirection = transform.TransformDirection(Vector3.forward);
            trueAngle = Vector3.Angle(rayDirection, enemyDirection);
            objInFrontOfEnemy = trueAngle <= viewRadius;

            if (objInFrontOfEnemy) 
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, rayDirection, out hit, viewDistance) 
                    && hit.collider.gameObject == C.gameObject)
                {
                    detectedList.Append<GameObject>(C.gameObject);
                }
            }
        }

        if (detectedList.Count > 0)
            onSuspicion?.Invoke(detectedList);
    }

    /*
    // Based on code from this forum thread. Has been modified
    // https://discussions.unity.com/t/detect-player-in-range-of-enemy/687
    private IEnumerator VisionUpdate() 
    {
        for(;;) 
        {
            float viewDistanceSquared = viewDistance * viewDistance;
            rayDirection = playerObject.transform.position - transform.position;
            enemyDirection = transform.TransformDirection(Vector3.forward);
            trueAngle = Vector3.Angle(rayDirection, enemyDirection);
            bool playerInFrontOfEnemy = trueAngle <= viewRadius;
            bool playerCloseToEnemy = rayDirection.sqrMagnitude < viewDistanceSquared;

            if (playerInFrontOfEnemy && playerCloseToEnemy)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, rayDirection, out hit, viewDistance) && hit.collider.gameObject == playerObject)
                {
                    playerIsSeen = true;
                    playerWasSeen = true;

                    // Enemy sees player
                    if (onPlayerDetection != null)
                    {
                        onPlayerDetection();
                    }
                }
                else
                {
                    // Cant see player bc of obstruction
                    playerIsSeen = false;
                }
            }
            else
            {
                // Player cannot be seen, due to angle or distance
                playerIsSeen = false;
            }

            // If the player was spotted but line of sight was lost
            if (playerWasSeen && !playerIsSeen) 
            { 
                if (onPlayerLost != null)
                {
                    onPlayerLost();
                    playerWasSeen = false; // prevents the event from happening repeatedly
                }
            }

            yield return new WaitForSeconds(visionUpdateDelay);
        }
        
    }
    */
}
