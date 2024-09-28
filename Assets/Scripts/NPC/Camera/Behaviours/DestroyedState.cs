using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedState : CameraState
{
    public DestroyedState(CameraContext context, CameraBrain.CameraStates key) : base(context, key) {}

    public override void EnterState()
    {
        context.vision.isEnabled = false;
    }

    public override void ExitState()
    {
    }

    public override CameraBrain.CameraStates GetNextState()
    {
        if (context.healthComponent.health > 0 && context.isDisabled)
            return CameraBrain.CameraStates.Disabled;
        
        if (context.healthComponent.health > 0) 
            return CameraBrain.CameraStates.Scanning;

        return CameraBrain.CameraStates.Destroyed;
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

    public override void UpdateState()
    {
    }
}
