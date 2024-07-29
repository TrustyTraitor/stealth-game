using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractActionSO : ScriptableObject
{
    [field: SerializeField]
    public bool DestroyAfterInteract { get; protected set; } = false;

    public abstract void Execute();
}
