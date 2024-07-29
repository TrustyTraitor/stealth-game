using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private float interactRange = 2f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Interact")) 
        {
            Collider[] nearbyInteractables = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider c in nearbyInteractables)
                if (c.TryGetComponent<Interactable>(out Interactable interactable))
                {
                    interactable.Interaction();
                }
        }
    }
}
