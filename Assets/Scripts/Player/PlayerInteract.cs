using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private float interactRange = 5f;

    [SerializeField]
    private Camera camera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact")) 
        {
            //Debug.DrawRay(camera.transform.position, camera.transform.forward, Color.red, 10f);
            RaycastHit hit;
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, interactRange))
            {
                hit.collider.gameObject.GetComponent<Interactable>()?.Interaction();
            }
        }
    }
}
