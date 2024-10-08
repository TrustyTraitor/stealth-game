using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CompleteHeist", menuName = "ScriptableObjects/CompleteHeist")]
public class CompleteHeistSO : InteractActionSO
{

    [SerializeField]
    private InventorySO inventory;

    public override void Execute(GameObject obj = null)
    {
        if (inventory.Money > 500000)
        {
            obj.SetActive(true);
        }
    }
}
