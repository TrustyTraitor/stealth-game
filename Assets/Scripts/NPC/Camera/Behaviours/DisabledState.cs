using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabledState : CameraState
{
    public DisabledState(CameraContext context, CameraBrain.CameraStates key) : base(context, key) {}

    public override void EnterState()
    {
        context.vision.isEnabled = false;
    }

    public override void ExitState()
    {
    }

    public override CameraBrain.CameraStates GetNextState()
    {
        if (context.isDisabled == false && context.healthComponent.health > 0) return CameraBrain.CameraStates.Scanning;
        if (context.healthComponent.health < 0) return CameraBrain.CameraStates.Destroyed;

        return CameraBrain.CameraStates.Disabled;
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
