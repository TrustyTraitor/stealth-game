using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private InteractActionSO interactAction;

    private bool DestroyAfterInteract = false;

    private void Awake()
    {
        DestroyAfterInteract = interactAction.DestroyAfterInteract;
    }

    public void Interaction() 
    {
        interactAction?.Execute();

        if (DestroyAfterInteract) Destroy(gameObject);
    }
}
