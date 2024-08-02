using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private InteractActionSO interactAction;

    [SerializeField, OptionalField]
    private GameObject interactTarget = null;

    private bool DestroyAfterInteract = false;

    private void Awake()
    {
        DestroyAfterInteract = interactAction.DestroyAfterInteract;
    }

    public virtual void Interaction() 
    {
        interactAction?.Execute(interactTarget);        
        if (DestroyAfterInteract) Destroy(gameObject);
    }
}
