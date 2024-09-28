using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraState : BaseState<CameraBrain.CameraStates>
{
    protected CameraContext context;

    public CameraState(CameraContext context, CameraBrain.CameraStates key) : base(key)
    {
        this.context = context;
    }
}

