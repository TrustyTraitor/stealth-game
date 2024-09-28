using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanningState : CameraState
{
    public ScanningState(CameraContext context, CameraBrain.CameraStates key) : base(context, key) {}

    public override void EnterState()
    {
        context.vision.isEnabled = true;
    }

    public override void ExitState()
    {
        
    }

    public override CameraBrain.CameraStates GetNextState()
    {
        if (context.healthComponent.health <= 0) return CameraBrain.CameraStates.Destroyed;
        if (context.isDisabled) return CameraBrain.CameraStates.Disabled;

        return CameraBrain.CameraStates.Scanning;
    }
    public override void UpdateState()
    {
    }

    public override void OnTriggerEnter(Collider other)
    {
    }

    public override void OnTriggerExit(Collider other)
    {
    }

    public override void OnTriggerStay(Collider other)
    {
    }

}
