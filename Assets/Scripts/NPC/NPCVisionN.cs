using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using UnityEngine;
using JetBrains.Annotations;
using UnityEngine.Assertions;
using Unity.VisualScripting;

[Tooltip("Detects objects in the given npcInfoSO.layerMask"), DisallowMultipleComponent]
public class NPCVisionN : MonoBehaviour
{
    #region Variables

    [SerializeField, Tooltip("The transform of where the NPC eyes are located")]
    private Transform eyeTransform;

    [SerializeField]
    private NPCInfoSO npcInfoSO;

    // Purely internal use. Put here so they are not reinitialized on vision update
    private Vector3 rayDirection;
    private Vector3 facingDirection;
    private float trueAngle;
    private bool objInFrontOfNPC;
    private Transform detectionNode;

    #endregion

    #region Events
    // New versions of OnPlayerDetection and OnPlayerLost
    // It is more generic as to show support for detecting non-players
    public event Action<List<GameObject>> onSuspicion;

    #endregion

    #region Monobehaviour Built-ins
    private void Awake()
    {
        Assert.IsNotNull(eyeTransform);
        Assert.IsNotNull(npcInfoSO);
    }

    private void Start()
    {
        StartCoroutine(nVisionUpdate());
    }
    
    #endregion

    private IEnumerator nVisionUpdate()
    {
        while (true)
        {
            DetectionCheck();

            yield return new WaitForSeconds(npcInfoSO.visionUpdateDelay);
        }
    }

    private void DetectionCheck()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, npcInfoSO.viewDistance, npcInfoSO.layerMask);

        List<GameObject> detectedList = new List<GameObject>();

        // Runs through the array of all Suspicious objects in range.
        // Does a ray cast to ensure it isnt behind a wall
        foreach (var C in colliders)
        {
            detectionNode = C.gameObject.GetComponent<ObjectSuspicion>()?.detectionNode.transform;

            rayDirection = detectionNode.position - eyeTransform.position;
            facingDirection = eyeTransform.TransformDirection(Vector3.forward);
            trueAngle = Vector3.Angle(rayDirection, facingDirection);
            objInFrontOfNPC = trueAngle <= npcInfoSO.viewAngle;

            if (objInFrontOfNPC)
            {
                RaycastHit hit;
                if (Physics.Raycast(eyeTransform.position, rayDirection, out hit, npcInfoSO.viewDistance)
                    && hit.collider.gameObject == C.gameObject)
                {
                    detectedList.Add(C.gameObject);
                }

                Debug.DrawRay(eyeTransform.position, rayDirection, Color.red, 0.2f);
            }
        }

        if (detectedList.Count() > 0)
            onSuspicion?.Invoke(detectedList);
    }

}
