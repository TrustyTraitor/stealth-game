using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Assertions;

[DisallowMultipleComponent, RequireComponent(typeof(NPCVisionN))]
public class NPCSuspicionHandler : MonoBehaviour
{
    #region variables

    [SerializeField]
    private NPCInfoSO npcInfoSO;

    // Internal use
    private NPCVisionN vision;
    private float lastDetectTime = 0f;
    private bool susObjSeen = false;

    private IEnumerator DelayedAlertEventHandler;
    private IEnumerator LosingSuspicionHandler;

    private bool isAlerted = false;
    public bool IsAlerted {  
        get { return isAlerted; } 
        private set 
        {
            isAlerted = value;

            if (isAlerted)
                StartCoroutine(DelayedAlertEventHandler);
        } 
    }

    private float suspicion = 0f;
    public float Suspicion {
        get { return suspicion; }
        private set 
        {
            suspicion = Mathf.Clamp(value, 0f, npcInfoSO.maxSuspicion);
            onSuspicionUpdate?.Invoke();
            
            if (suspicion >= npcInfoSO.maxSuspicion) IsAlerted = true;
        }
    }

    #endregion

    #region Events
    // Public events
    public event Action onSuspicionUpdate; // Happens whenever Suspicion is updated, not when suspicion is maxed
    public event Action onAlertAfterDelay; // Alert event after a specified delay

    #endregion

    #region Monobehaviour Buit-ins

    private void Awake()
    {
        DelayedAlertEventHandler = DelayedAlertCoroutine();
        LosingSuspicionHandler = ReduceSuspicion();

    }

    void Start()
    {
        Assert.IsNotNull(npcInfoSO);

        vision = GetComponent<NPCVisionN>();

        vision.onSuspicion += SusDetection;
    }

    void Update()
    {
        if (susObjSeen && Time.time - lastDetectTime  >= npcInfoSO.suspicionResetTime)
        {
            susObjSeen = false;
            StartCoroutine(LosingSuspicionHandler);

            if (LosingSuspicionHandler != null)
                LosingSuspicionHandler = ReduceSuspicion();
        }
    }

    private void OnDisable()
    {
        vision.onSuspicion -= SusDetection;
    }

    #endregion

    // Is subscribed to the NPCVision.OnSuspicion
    public void SusDetection(List<GameObject> detectedObjs)
    {
        ObjectSuspicion objSus;
        lastDetectTime = Time.time;
        susObjSeen = true;

        if (LosingSuspicionHandler != null)
            StopCoroutine(LosingSuspicionHandler);

        foreach (GameObject obj in detectedObjs) 
        {
            objSus = obj.GetComponent<ObjectSuspicion>();
            if (objSus != null) 
            {
                Suspicion += (objSus.GetModSuspicion() * (npcInfoSO.visionUpdateDelay + Time.deltaTime));
            }
        }
    }

    public IEnumerator ReduceSuspicion() 
    {
        while (Suspicion > 0) 
        {
            suspicion /= 2f;
            Suspicion = Mathf.RoundToInt(suspicion);

            yield return new WaitForSeconds(npcInfoSO.suspicionFallOffRate);
        }
        
    }

    // Used to delay when the OnAlertAfterDelay happens
    // Can be cancelled using StopCoroutine(DelayedAlertEventHandler)
    private IEnumerator DelayedAlertCoroutine() 
    {
        yield return new WaitForSeconds(npcInfoSO.alertDelay);

        onAlertAfterDelay?.Invoke();
    }
}
