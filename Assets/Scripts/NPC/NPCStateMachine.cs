using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStateMachine : MonoBehaviour
{
    private NPCSuspicionHandler suspicionHandler;

    private bool isAlerted;


    // Start is called before the first frame update
    void Start()
    {
        suspicionHandler = GetComponent<NPCSuspicionHandler>();

        suspicionHandler.onAlertAfterDelay += onAlerted;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onAlerted()
    {
        isAlerted = true;
    }
}
