using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private float interactRange = 5f;

    [SerializeField]
    private Camera Camera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact")) 
        {
            Debug.DrawRay(Camera.transform.position, Camera.transform.forward, Color.red, 10f);
            RaycastHit hit;
            if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, interactRange))
            {
                hit.collider.gameObject.GetComponent<Interactable>()?.Interaction();
            }
        }
    }
}
