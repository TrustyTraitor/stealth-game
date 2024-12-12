using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CompleteHeist", menuName = "ScriptableObjects/CompleteHeist")]
public class CompleteHeistSO : InteractActionSO
{

    [SerializeField]
    private InventorySO inventory;

    [SerializeField]
    public int req = 500000;

    public override void Execute(GameObject obj = null)
    {
        if (inventory.Money > req)
        {
            obj.SetActive(true);
            inventory.TotalXp += inventory.Money / 10;
            inventory.TotalMoney += inventory.Money;

            inventory.Money = 0;
            inventory.XpEarned = 0;
        }
    }
}
