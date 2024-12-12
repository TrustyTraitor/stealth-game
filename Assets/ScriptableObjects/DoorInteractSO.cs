using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DoorInteractSO", menuName = "ScriptableObjects/Environment/Door")]
public class DoorInteractSO : InteractActionSO
{
    [SerializeField]
    private InventorySO inventory;

    public override void Execute(GameObject obj = null)
    {
        Animator animator = obj.GetComponent<Animator>();
        if (animator != null) 
        {
            bool isOpen = animator.GetBool("isOpen");
            animator.SetBool("isOpen", !isOpen);
        }
    }
}
