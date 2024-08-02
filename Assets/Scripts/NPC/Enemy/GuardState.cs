using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GuardState : BaseState<GuardBrain.GuardStates>
{
    protected GuardContext context;

    public GuardState(GuardContext context, GuardBrain.GuardStates key) : base(key)
    {
        this.context = context;
    }
}

